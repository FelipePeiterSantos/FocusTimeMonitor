namespace FocusTimeMonitor
{
    partial class rootForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rootForm));
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStartBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuResumeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPauseBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuResetBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRemoveCheckBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editRemoveUncheckBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.listView = new System.Windows.Forms.ListView();
            this.columnWindow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnProcess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalTime = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.filterField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayShowBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.trayStartBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.trayResumeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.trayPauseBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.trayResetBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.trayExitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenBkpFolderBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenu.SuspendLayout();
            this.trayContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenu
            // 
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.editToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(624, 24);
            this.topMenu.TabIndex = 0;
            this.topMenu.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenBtn,
            this.toolStripMenuItem4,
            this.menuStartBtn,
            this.menuResumeBtn,
            this.menuPauseBtn,
            this.menuResetBtn,
            this.toolStripMenuItem2,
            this.menuExitBtn});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
            // 
            // menuStartBtn
            // 
            this.menuStartBtn.Name = "menuStartBtn";
            this.menuStartBtn.Size = new System.Drawing.Size(152, 22);
            this.menuStartBtn.Text = "Start";
            this.menuStartBtn.Click += new System.EventHandler(this.menuStartBtn_Click);
            // 
            // menuResumeBtn
            // 
            this.menuResumeBtn.Name = "menuResumeBtn";
            this.menuResumeBtn.Size = new System.Drawing.Size(152, 22);
            this.menuResumeBtn.Text = "Resume";
            this.menuResumeBtn.Click += new System.EventHandler(this.menuResumeBtn_Click);
            // 
            // menuPauseBtn
            // 
            this.menuPauseBtn.Name = "menuPauseBtn";
            this.menuPauseBtn.Size = new System.Drawing.Size(152, 22);
            this.menuPauseBtn.Text = "Pause";
            this.menuPauseBtn.Click += new System.EventHandler(this.menuPauseBtn_Click);
            // 
            // menuResetBtn
            // 
            this.menuResetBtn.Name = "menuResetBtn";
            this.menuResetBtn.Size = new System.Drawing.Size(152, 22);
            this.menuResetBtn.Text = "Reset";
            this.menuResetBtn.Click += new System.EventHandler(this.menuResetBtn_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // menuExitBtn
            // 
            this.menuExitBtn.Name = "menuExitBtn";
            this.menuExitBtn.Size = new System.Drawing.Size(152, 22);
            this.menuExitBtn.Text = "Exit";
            this.menuExitBtn.Click += new System.EventHandler(this.menuExitBtn_Click);
            // 
            // menuOpenBtn
            // 
            this.menuOpenBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenBkpFolderBtn});
            this.menuOpenBtn.Name = "menuOpenBtn";
            this.menuOpenBtn.Size = new System.Drawing.Size(152, 22);
            this.menuOpenBtn.Text = "Open";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editRemoveCheckBtn,
            this.editRemoveUncheckBtn});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editRemoveCheckBtn
            // 
            this.editRemoveCheckBtn.Name = "editRemoveCheckBtn";
            this.editRemoveCheckBtn.Size = new System.Drawing.Size(179, 22);
            this.editRemoveCheckBtn.Text = "Remove Checked";
            this.editRemoveCheckBtn.Click += new System.EventHandler(this.editRemoveBtn_Click);
            // 
            // editRemoveUncheckBtn
            // 
            this.editRemoveUncheckBtn.Name = "editRemoveUncheckBtn";
            this.editRemoveUncheckBtn.Size = new System.Drawing.Size(179, 22);
            this.editRemoveUncheckBtn.Text = "Remove Unchecked";
            this.editRemoveUncheckBtn.Click += new System.EventHandler(this.editRemoveUncheckBtn_Click);
            // 
            // listView
            // 
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnWindow,
            this.columnProcess,
            this.columnTime});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(0, 24);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(624, 378);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.column_Click);
            // 
            // columnWindow
            // 
            this.columnWindow.Text = "Window";
            this.columnWindow.Width = 320;
            // 
            // columnProcess
            // 
            this.columnProcess.Text = "Process Name";
            this.columnProcess.Width = 172;
            // 
            // columnTime
            // 
            this.columnTime.Text = "Focused Time";
            this.columnTime.Width = 128;
            // 
            // totalTime
            // 
            this.totalTime.AutoSize = true;
            this.totalTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.totalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTime.Location = new System.Drawing.Point(0, 402);
            this.totalTime.Name = "totalTime";
            this.totalTime.Size = new System.Drawing.Size(243, 39);
            this.totalTime.TabIndex = 1;
            this.totalTime.Text = "Total Time: {0}";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.statusLabel.Location = new System.Drawing.Point(381, 402);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(243, 39);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // filterField
            // 
            this.filterField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterField.Location = new System.Drawing.Point(448, 3);
            this.filterField.Name = "filterField";
            this.filterField.Size = new System.Drawing.Size(176, 20);
            this.filterField.TabIndex = 4;
            this.filterField.TextChanged += new System.EventHandler(this.filterField_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(410, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter:";
            // 
            // trayContextMenuStrip
            // 
            this.trayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayShowBtn,
            this.toolStripMenuItem1,
            this.trayStartBtn,
            this.trayResumeBtn,
            this.trayPauseBtn,
            this.trayResetBtn,
            this.toolStripMenuItem3,
            this.trayExitBtn});
            this.trayContextMenuStrip.Name = "trayContextMenuStrip";
            this.trayContextMenuStrip.Size = new System.Drawing.Size(155, 148);
            // 
            // trayShowBtn
            // 
            this.trayShowBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trayShowBtn.Name = "trayShowBtn";
            this.trayShowBtn.Size = new System.Drawing.Size(154, 22);
            this.trayShowBtn.Text = "Show Window";
            this.trayShowBtn.Click += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // trayStartBtn
            // 
            this.trayStartBtn.Name = "trayStartBtn";
            this.trayStartBtn.Size = new System.Drawing.Size(154, 22);
            this.trayStartBtn.Text = "Start";
            this.trayStartBtn.Click += new System.EventHandler(this.menuStartBtn_Click);
            // 
            // trayResumeBtn
            // 
            this.trayResumeBtn.Name = "trayResumeBtn";
            this.trayResumeBtn.Size = new System.Drawing.Size(154, 22);
            this.trayResumeBtn.Text = "Resume";
            this.trayResumeBtn.Click += new System.EventHandler(this.menuResumeBtn_Click);
            // 
            // trayPauseBtn
            // 
            this.trayPauseBtn.Name = "trayPauseBtn";
            this.trayPauseBtn.Size = new System.Drawing.Size(154, 22);
            this.trayPauseBtn.Text = "Pause";
            this.trayPauseBtn.Click += new System.EventHandler(this.menuPauseBtn_Click);
            // 
            // trayResetBtn
            // 
            this.trayResetBtn.Name = "trayResetBtn";
            this.trayResetBtn.Size = new System.Drawing.Size(154, 22);
            this.trayResetBtn.Text = "Reset";
            this.trayResetBtn.Click += new System.EventHandler(this.menuResetBtn_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(151, 6);
            // 
            // trayExitBtn
            // 
            this.trayExitBtn.Name = "trayExitBtn";
            this.trayExitBtn.Size = new System.Drawing.Size(154, 22);
            this.trayExitBtn.Text = "Exit";
            this.trayExitBtn.Click += new System.EventHandler(this.menuExitBtn_Click);
            // 
            // menuOpenBkpFolderBtn
            // 
            this.menuOpenBkpFolderBtn.Name = "menuOpenBkpFolderBtn";
            this.menuOpenBkpFolderBtn.Size = new System.Drawing.Size(152, 22);
            this.menuOpenBkpFolderBtn.Text = "Backup Folder";
            this.menuOpenBkpFolderBtn.Click += new System.EventHandler(this.menuOpenBkpFolderBtn_Click);
            // 
            // rootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.filterField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.totalTime);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.topMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.topMenu;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "rootForm";
            this.Text = "Focus Time Monitor";
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.trayContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStartBtn;
        private System.Windows.Forms.ToolStripMenuItem menuPauseBtn;
        private System.Windows.Forms.ToolStripMenuItem menuResetBtn;
        private System.Windows.Forms.ToolStripMenuItem menuExitBtn;
        private System.Windows.Forms.ToolStripMenuItem menuResumeBtn;
        private System.Windows.Forms.ListView listView;
        public System.Windows.Forms.ColumnHeader columnWindow;
        public System.Windows.Forms.ColumnHeader columnTime;
        private System.Windows.Forms.Label totalTime;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox filterField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip trayContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem trayStartBtn;
        private System.Windows.Forms.ToolStripMenuItem trayResumeBtn;
        private System.Windows.Forms.ToolStripMenuItem trayPauseBtn;
        private System.Windows.Forms.ToolStripMenuItem trayResetBtn;
        private System.Windows.Forms.ToolStripMenuItem trayExitBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem trayShowBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        public System.Windows.Forms.ColumnHeader columnProcess;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRemoveCheckBtn;
        private System.Windows.Forms.ToolStripMenuItem editRemoveUncheckBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuOpenBtn;
        private System.Windows.Forms.ToolStripMenuItem menuOpenBkpFolderBtn;
    }
}

