namespace Netscape
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainmenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.buttonResume = new System.Windows.Forms.ToolStripButton();
            this.buttonSuspend = new System.Windows.Forms.ToolStripButton();
            this.buttonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtSeed = new System.Windows.Forms.ToolStripTextBox();
            this.buttonGo = new System.Windows.Forms.ToolStripButton();
            this.tabcontrol = new System.Windows.Forms.TabControl();
            this.tabThreads = new System.Windows.Forms.TabPage();
            this.dataGridThreads = new System.Windows.Forms.DataGridView();
            this.tabErrors = new System.Windows.Forms.TabPage();
            this.listViewErrors = new System.Windows.Forms.ListView();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mainmenu.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.tabcontrol.SuspendLayout();
            this.tabThreads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridThreads)).BeginInit();
            this.tabErrors.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainmenu
            // 
            this.mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainmenu.Location = new System.Drawing.Point(0, 0);
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mainmenu.Size = new System.Drawing.Size(764, 25);
            this.mainmenu.TabIndex = 0;
            this.mainmenu.Text = "mainmenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.fileToolStripMenuItem.Text = "&文件";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.optionsToolStripMenuItem.Text = "&选项";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsToolStripMenuItem.Image")));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "&Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.helpToolStripMenuItem.Text = "&帮助";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // toolbar
            // 
            this.toolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonResume,
            this.buttonSuspend,
            this.buttonStop,
            this.toolStripSeparator1,
            this.buttonSettings,
            this.toolStripSeparator2,
            this.txtSeed,
            this.buttonGo});
            this.toolbar.Location = new System.Drawing.Point(0, 25);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(764, 31);
            this.toolbar.TabIndex = 1;
            this.toolbar.Text = "toolBarMain";
            // 
            // buttonResume
            // 
            this.buttonResume.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonResume.Image = ((System.Drawing.Image)(resources.GetObject("buttonResume.Image")));
            this.buttonResume.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(28, 28);
            this.buttonResume.Text = "buttonStart";
            this.buttonResume.ToolTipText = "Resume";
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // buttonSuspend
            // 
            this.buttonSuspend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSuspend.Image = ((System.Drawing.Image)(resources.GetObject("buttonSuspend.Image")));
            this.buttonSuspend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSuspend.Name = "buttonSuspend";
            this.buttonSuspend.Size = new System.Drawing.Size(28, 28);
            this.buttonSuspend.Text = "buttonPause";
            this.buttonSuspend.ToolTipText = "Suspend";
            this.buttonSuspend.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(28, 28);
            this.buttonStop.Text = "buttonStop";
            this.buttonStop.ToolTipText = "Abort";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // buttonSettings
            // 
            this.buttonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(28, 28);
            this.buttonSettings.Text = "buttonSettings";
            this.buttonSettings.ToolTipText = "Settings";
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // txtSeed
            // 
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(226, 31);
            this.txtSeed.Text = "http://localhost:8080";
            this.txtSeed.ToolTipText = "Please input seed here!";
            // 
            // buttonGo
            // 
            this.buttonGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonGo.Image = ((System.Drawing.Image)(resources.GetObject("buttonGo.Image")));
            this.buttonGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(28, 28);
            this.buttonGo.ToolTipText = "Go!!";
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // tabcontrol
            // 
            this.tabcontrol.Controls.Add(this.tabThreads);
            this.tabcontrol.Controls.Add(this.tabErrors);
            this.tabcontrol.Controls.Add(this.tabLogs);
            this.tabcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcontrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabcontrol.Location = new System.Drawing.Point(0, 56);
            this.tabcontrol.Margin = new System.Windows.Forms.Padding(2);
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.SelectedIndex = 0;
            this.tabcontrol.Size = new System.Drawing.Size(764, 483);
            this.tabcontrol.TabIndex = 3;
            // 
            // tabThreads
            // 
            this.tabThreads.Controls.Add(this.dataGridThreads);
            this.tabThreads.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabThreads.Location = new System.Drawing.Point(4, 24);
            this.tabThreads.Margin = new System.Windows.Forms.Padding(2);
            this.tabThreads.Name = "tabThreads";
            this.tabThreads.Padding = new System.Windows.Forms.Padding(2);
            this.tabThreads.Size = new System.Drawing.Size(756, 455);
            this.tabThreads.TabIndex = 0;
            this.tabThreads.Text = "Threads";
            this.tabThreads.UseVisualStyleBackColor = true;
            // 
            // dataGridThreads
            // 
            this.dataGridThreads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridThreads.Location = new System.Drawing.Point(2, 2);
            this.dataGridThreads.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridThreads.Name = "dataGridThreads";
            this.dataGridThreads.ReadOnly = true;
            this.dataGridThreads.RowTemplate.Height = 27;
            this.dataGridThreads.Size = new System.Drawing.Size(752, 451);
            this.dataGridThreads.TabIndex = 0;
            // 
            // tabErrors
            // 
            this.tabErrors.Controls.Add(this.listViewErrors);
            this.tabErrors.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabErrors.Location = new System.Drawing.Point(4, 24);
            this.tabErrors.Margin = new System.Windows.Forms.Padding(2);
            this.tabErrors.Name = "tabErrors";
            this.tabErrors.Padding = new System.Windows.Forms.Padding(2);
            this.tabErrors.Size = new System.Drawing.Size(756, 455);
            this.tabErrors.TabIndex = 1;
            this.tabErrors.Text = "Errors";
            this.tabErrors.UseVisualStyleBackColor = true;
            // 
            // listViewErrors
            // 
            this.listViewErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewErrors.Location = new System.Drawing.Point(2, 2);
            this.listViewErrors.Margin = new System.Windows.Forms.Padding(2);
            this.listViewErrors.Name = "listViewErrors";
            this.listViewErrors.Size = new System.Drawing.Size(752, 451);
            this.listViewErrors.TabIndex = 0;
            this.listViewErrors.UseCompatibleStateImageBehavior = false;
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.txtOutput);
            this.tabLogs.Location = new System.Drawing.Point(4, 24);
            this.tabLogs.Margin = new System.Windows.Forms.Padding(2);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Size = new System.Drawing.Size(756, 455);
            this.tabLogs.TabIndex = 2;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(756, 455);
            this.txtOutput.TabIndex = 4;
            this.txtOutput.Text = "";
            this.txtOutput.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtOutput_LinkClicked);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 300;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 539);
            this.Controls.Add(this.tabcontrol);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.mainmenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainmenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Web Crawler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mainmenu.ResumeLayout(false);
            this.mainmenu.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.tabcontrol.ResumeLayout(false);
            this.tabThreads.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridThreads)).EndInit();
            this.tabErrors.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainmenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.TabControl tabcontrol;
        private System.Windows.Forms.TabPage tabThreads;
        private System.Windows.Forms.TabPage tabErrors;
        private System.Windows.Forms.DataGridView dataGridThreads;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton buttonResume;
        private System.Windows.Forms.ToolStripButton buttonSuspend;
        private System.Windows.Forms.ToolStripButton buttonStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox txtSeed;
        private System.Windows.Forms.ToolStripButton buttonGo;
        private System.Windows.Forms.TabPage tabLogs;

        private System.Windows.Forms.ListView listViewErrors;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Timer timer;
    }
}

