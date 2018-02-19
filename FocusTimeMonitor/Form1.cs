using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace FocusTimeMonitor
{
    public partial class rootForm : Form{

        [StructLayout(LayoutKind.Sequential)]
        public struct LASTINPUTINFO{
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        public struct ListInfo {
            public bool check;
            public string name;
            public string process;
            public int time;
        }

        private Timer updateTimer;

        private bool isRunning;
        private bool isPaused;
        private bool isFiltering;

        private bool sortWindowDescending;
        private bool sortTimeDescending;

        private string labelFormatTotalTime;

        private List<ListInfo> listHandle;
        private List<ListInfo> filterListHandle;
        private int totalTimeCount;
        private string windowName;
        private string processName;
        private int lastWidthSize;
        private string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"/FocusTimeMonitor";
        private bool backupRedundance;
        private string backupFormat = "{0} // {1} // {2} // {3}";
        private uint lastInput;

        private NotifyIcon trayIcon;

        public rootForm(){
            InitializeComponent();
            isRunning = true;
            isPaused = false;
            isFiltering = false;
            filterField.Text = "";
            sortWindowDescending = true;
            sortTimeDescending = true;
            listHandle = new List<ListInfo>();
            filterListHandle = new List<ListInfo>();
            labelFormatTotalTime = totalTime.Text;
            windowName = "";
            trayIcon = new NotifyIcon() {
                Icon = this.Icon,
                Visible = false,
            };
            trayIcon.MouseDoubleClick += trayIcon_DoubleClick;
            trayIcon.ContextMenuStrip = trayContextMenuStrip;

            if(!Directory.Exists(documentsPath)){
                Directory.CreateDirectory(documentsPath);
            }

            totalTime.Text = string.Format(labelFormatTotalTime, TimeFormat(0));
            updateTimer = new Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += new EventHandler(TimerTick);
            if (isRunning) updateTimer.Start();
            columnWindow.Width = this.Width / 2;
            columnProcess.Width = this.Width - 20 - columnWindow.Width - 128;
            columnTime.Width = 128;
            UpdateMenuBtns();
        }

        public static int GetInactiveTime(){
            LASTINPUTINFO info = new LASTINPUTINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);
            GetLastInputInfo(ref info);
            return (int)((Environment.TickCount - info.dwTime) / 1000);
        }

        private void TimerTick(object sender, EventArgs e) {
            windowName = ReturnWindowName();
            processName = ReturnProcessName();
            totalTimeCount = 0;
            bool newToList = true;

            for (int i = 0; i < listHandle.Count; i++){
                if(listHandle[i].name.CompareTo(windowName) == 0) {
                    ListInfo info = listHandle[i];
                    info.time++;
                    listHandle[i] = info;
                    newToList = false;
                }

                if(isFiltering) {
                    for (int j = 0; j < filterListHandle.Count; j++){
                        if(filterListHandle[j].name.Contains(listHandle[i].name)) {
                            if(listView.Items[j].SubItems[2].Text != TimeFormat(listHandle[i].time)) {
                                listView.Items[j].SubItems[2].Text = TimeFormat(listHandle[i].time);
                            }
                            
                            if(listView.Items[j].Checked != listHandle[i].check) {
                                ListInfo info = listHandle[i];
                                info.check = listView.Items[j].Checked;
                                listHandle[i] = info;
                            }
                        }
                    }
                }
                else {
                    if(listHandle[i].name.CompareTo(windowName) == 0) {
                        listView.Items[i].SubItems[2].Text = TimeFormat(listHandle[i].time);
                    }

                    if(listView.Items[i].Checked != listHandle[i].check) {
                        ListInfo info = listHandle[i];
                        info.check = listView.Items[i].Checked;
                        listHandle[i] = info;
                    }
                }
            }

            if(newToList) {
                listHandle.Add(new ListInfo() {check = false, name = windowName, process = processName, time = 1});
                if(isFiltering) {
                    if(windowName.ToLower().Contains(filterField.Text.ToLower())) {
                        filterListHandle.Add(new ListInfo() {check = false, name = windowName, process = processName, time = 1});
                        ListViewItem item = new ListViewItem(windowName);
                        item.Checked = false;
                        item.SubItems.Add(processName);
                        item.SubItems.Add(TimeFormat(1));
                        listView.Items.Add(item);
                    }
                }
                else {
                    ListViewItem item = new ListViewItem(windowName);
                    item.Checked = false;
                    item.SubItems.Add(processName);
                    item.SubItems.Add(TimeFormat(1));
                    listView.Items.Add(item);
                }
            }

            foreach (ListInfo item in listHandle){
                if(item.check) {
                    totalTimeCount += item.time;
                }
            }

            if(DateTime.Now.Second % 60 == 0){
                SaveBackup();
            }

            totalTime.Text = string.Format(labelFormatTotalTime,TimeFormat(totalTimeCount));
        }

        private void menuStartBtn_Click(object sender, EventArgs e){
            isRunning = true;
            isPaused = false;
            updateTimer.Start();
            UpdateMenuBtns();
        }

        private void menuResetBtn_Click(object sender, EventArgs e){
            isRunning = false;
            isPaused = false;
            updateTimer.Stop();
            listView.Items.Clear();
            listHandle.Clear();
            UpdateMenuBtns();
        }

        private void menuResumeBtn_Click(object sender, EventArgs e){
            isRunning = true;
            isPaused = false;
            updateTimer.Start();
            UpdateMenuBtns();
        }

        private void menuPauseBtn_Click(object sender, EventArgs e){
            isRunning = false;
            isPaused = true;
            updateTimer.Stop();
            UpdateMenuBtns();
        }

        private void menuExitBtn_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void editRemoveBtn_Click(object sender, EventArgs e) {
            RemoveFromList(false);
        }

        private void editRemoveUncheckBtn_Click(object sender, EventArgs e){
            RemoveFromList(true);
        }

        private void column_Click (object sender, ColumnClickEventArgs e) {
            
            if (e.Column == 0) {
                sortWindowDescending = !sortWindowDescending;
                if(sortWindowDescending) {
                    listHandle.Sort((s1, s2) => s2.name.CompareTo(s1.name));
                }
                else {
                    listHandle.Sort((s1, s2) => s1.name.CompareTo(s2.name));
                }
                
            }
            else if(e.Column == 1) {
                sortTimeDescending = !sortTimeDescending;
                if(sortTimeDescending) {
                    listHandle.Sort((s1, s2) => s2.process.CompareTo(s1.process));
                }
                else {
                    listHandle.Sort((s1, s2) => s1.process.CompareTo(s2.process));
                }
            }
            else {
                sortTimeDescending = !sortTimeDescending;
                if(sortTimeDescending) {
                    listHandle.Sort((s1, s2) => s2.time.CompareTo(s1.time));
                }
                else {
                    listHandle.Sort((s1, s2) => s1.time.CompareTo(s2.time));
                }
            }
            if(isFiltering) {
                filterListHandle.Clear();
                listView.Items.Clear();
                foreach (ListInfo item in listHandle){
                    if(item.name.ToLower().Contains(filterField.Text.ToLower())) {
                        filterListHandle.Add(new ListInfo() {check = item.check, name = item.name, process = item.process, time = item.time});
                        ListViewItem addToListColumns = new ListViewItem(item.name);
                        addToListColumns.Checked = item.check;
                        addToListColumns.SubItems.Add(item.process);
                        addToListColumns.SubItems.Add(TimeFormat(item.time));
                        listView.Items.Add(addToListColumns);
                    }
                }
            }
            else {
                UpdateList();
            }
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            trayIcon.Visible = false;
            this.Show();
        }

        private void filterField_TextChanged(object sender, EventArgs e) {
            if(string.IsNullOrEmpty(filterField.Text)) {
                isFiltering = false;
                UpdateList();
            }
            else {
                isFiltering = true;
                listView.Items.Clear();
                filterListHandle.Clear();
                foreach (ListInfo item in listHandle){
                    if(item.name.ToLower().Contains(filterField.Text.ToLower())) {
                        filterListHandle.Add(new ListInfo() {check = item.check, name = item.name, time = item.time});
                        ListViewItem addToListColumns = new ListViewItem(item.name);
                        addToListColumns.Checked = item.check;
                        addToListColumns.SubItems.Add(item.process);
                        addToListColumns.SubItems.Add(TimeFormat(item.time));
                        listView.Items.Add(addToListColumns);
                    }
                }
            }
        }

        private void UpdateMenuBtns() {
            if(isRunning) {
                menuStartBtn.Visible = false;
                menuStartBtn.Enabled = false;
                menuResumeBtn.Visible = true;
                menuResumeBtn.Enabled = false;
                menuPauseBtn.Enabled = true;
                menuResetBtn.Enabled = true;

                trayStartBtn.Visible = false;
                trayStartBtn.Enabled = false;
                trayResumeBtn.Visible = true;
                trayResumeBtn.Enabled = false;
                trayPauseBtn.Enabled = true;
                trayResetBtn.Enabled = true;

                statusLabel.Text = "Running";
                statusLabel.ForeColor = Color.Green;
                trayIcon.Text = this.Text + " - " + statusLabel.Text;
            }
            else if(isPaused) {
                menuStartBtn.Visible = false;
                menuResumeBtn.Visible = true;
                menuResumeBtn.Enabled = true;
                menuPauseBtn.Enabled = false;
                menuResetBtn.Enabled = true;

                trayStartBtn.Visible = false;
                trayResumeBtn.Visible = true;
                trayResumeBtn.Enabled = true;
                trayPauseBtn.Enabled = false;
                trayResetBtn.Enabled = true;

                statusLabel.Text = "Paused";
                statusLabel.ForeColor = Color.Black;
                trayIcon.Text = this.Text + " - " + statusLabel.Text;
            }
            else {
                menuStartBtn.Visible = true;
                menuStartBtn.Enabled = true;
                menuResumeBtn.Visible = false;
                menuPauseBtn.Enabled = false;
                menuResetBtn.Enabled = false;

                trayStartBtn.Visible = true;
                trayStartBtn.Enabled = true;
                trayResumeBtn.Visible = false;
                trayPauseBtn.Enabled = false;
                trayResetBtn.Enabled = false;

                statusLabel.Text = "Stopped";
                statusLabel.ForeColor = Color.Red;
                trayIcon.Text = this.Text + " - " + statusLabel.Text;
            }
        }

        private void SaveBackup(){
            string backupFile = "/backup_"+(backupRedundance ? 1:0)+".txt";
            if (!File.Exists(documentsPath + backupFile)){
                CreateBackupFile(documentsPath + backupFile);
            }
            else{
                File.Delete(documentsPath + backupFile);
                CreateBackupFile(documentsPath + backupFile);
            }
            backupRedundance = !backupRedundance;
        }

        private void CreateBackupFile(string path){
            using (StreamWriter sw = File.CreateText(path)) {
                sw.WriteLine(string.Format(backupFormat,"#Actived","Window Name","Process Name","Focused Time"));
                sw.WriteLine("\n");
                int totalSec = 0;
                int totalSecChecked = 0;
                TimeSpan timeFormat = new TimeSpan();
                foreach (ListInfo item in listHandle){
                    timeFormat = TimeSpan.FromSeconds(item.time);
                    sw.WriteLine(string.Format(backupFormat,item.check ? "Check":"Uncheck",item.name,item.process,timeFormat));
                    if(item.check){
                        totalSecChecked += item.time;
                    }
                    totalSec += item.time;
                }
                sw.WriteLine("\n");
                timeFormat = TimeSpan.FromSeconds(totalSecChecked);
                sw.WriteLine("Total Time Checked: "+timeFormat);
                timeFormat = TimeSpan.FromSeconds(totalSec);
                sw.WriteLine("Total Time: "+timeFormat);
                sw.WriteLine("\n");
                sw.WriteLine("Saved at "+DateTime.Now);
                sw.Dispose();
            }
        }

        private void UpdateList() {
            listView.Items.Clear();
            foreach (ListInfo item in listHandle){
                ListViewItem addToListColumns = new ListViewItem(item.name);
                addToListColumns.Checked = item.check;
                addToListColumns.SubItems.Add(item.process);
                addToListColumns.SubItems.Add(TimeFormat(item.time));
                listView.Items.Add(addToListColumns);
            }
        }

        private string TimeFormat(int time) {
            string hnd = "";
            if(time >= 3600){
                hnd += (time / 3600)+"h ";
            }
            if(time >= 60) {
                hnd += ((time / 60)%60).ToString("00")+"m ";
            }
            if(time < 10) {
                hnd += (time % 60).ToString("0") + "s";
            }
            else {
                hnd += (time % 60).ToString("00") + "s";
            }
            
            return hnd;
        }

        private string ReturnWindowName() {
            if(GetInactiveTime() > 60) {
                return "Idle";
            }

            IntPtr handle = GetForegroundWindow();

            if(handle == null) {
                return "No Name";
            }

            int length = GetWindowTextLength(handle);
            StringBuilder builder = new StringBuilder(length + 1);

            GetWindowText(handle, builder, (int)builder.Capacity);

            if(string.IsNullOrEmpty(builder.ToString())) {
                return "No Name";
            }
            else {
                return builder.ToString();
            }
        }

        private string ReturnProcessName() {

            if(GetInactiveTime() > 60) {
                return "Inactivity";
            }

            IntPtr handle = GetForegroundWindow();

            if(handle == null) {
                return "No Name";
            }

            uint pID = 0;
            GetWindowThreadProcessId(handle,out pID);
            Process p = Process.GetProcessById((int)pID);

            if(string.IsNullOrEmpty(p.ProcessName)) {
                return "No Name";
            }
            else {
                return p.ProcessName;
            }
        }

        private void RemoveFromList(bool isCheck) {
            List<ListInfo> removeListHandle = new List<ListInfo>();
            foreach (ListInfo item in listHandle){
                if(item.check == isCheck) {
                    removeListHandle.Add(new ListInfo() {check = item.check, name = item.name, process = item.process, time = item.time});
                }
            }

            listHandle = removeListHandle;
            UpdateList();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if(this.WindowState == FormWindowState.Minimized) {
                this.ShowInTaskbar = false;
                trayIcon.Visible = true;
                this.Hide();
            }
            else {
                columnWindow.Width = this.Width / 2;
                columnProcess.Width = this.Width - 20 - columnWindow.Width - 128;
                columnTime.Width = 128;
            }
        }

        private void menuOpenBkpFolderBtn_Click(object sender, EventArgs e){
            Process.Start(documentsPath);
        }
    }
}
