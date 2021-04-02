namespace Netscape
{
    partial class KMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTaskFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.上的ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNewTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmLaunch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPause = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSysCfg = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTaskView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmActivedTaskWnd = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmKingsure = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnNewTask = new System.Windows.Forms.ToolStripButton();
            this.btnStartPage = new System.Windows.Forms.ToolStripButton();
            this.btnLaunch = new System.Windows.Forms.ToolStripButton();
            this.btnPause = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnIni = new System.Windows.Forms.ToolStripButton();
            this.tsmExport = new System.Windows.Forms.ToolStripButton();
            this.btnDB = new System.Windows.Forms.ToolStripButton();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ntsmNewTask = new System.Windows.Forms.ToolStripMenuItem();
            this.ntsmLaunch = new System.Windows.Forms.ToolStripMenuItem();
            this.ntsmPause = new System.Windows.Forms.ToolStripMenuItem();
            this.ntsmStop = new System.Windows.Forms.ToolStripMenuItem();
            this.ntsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel = new Lv.Docking.DockPanel();
            this.statusBottom = new Netscape.StatusBar(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTop,
            this.上的ToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.视图VToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(930, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuTop
            // 
            this.MenuTop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmTaskFolder,
            this.tsmDB,
            this.tsmExit});
            this.MenuTop.Name = "MenuTop";
            this.MenuTop.Size = new System.Drawing.Size(58, 21);
            this.MenuTop.Text = "文件(&F)";
            this.MenuTop.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // tsmTaskFolder
            // 
            this.tsmTaskFolder.Name = "tsmTaskFolder";
            this.tsmTaskFolder.Size = new System.Drawing.Size(148, 22);
            this.tsmTaskFolder.Text = "打开下载路径";
            this.tsmTaskFolder.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // tsmDB
            // 
            this.tsmDB.Name = "tsmDB";
            this.tsmDB.Size = new System.Drawing.Size(148, 22);
            this.tsmDB.Text = "系统数据库";
            this.tsmDB.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(148, 22);
            this.tsmExit.Text = "退出系统";
            this.tsmExit.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // 上的ToolStripMenuItem
            // 
            this.上的ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNewTask,
            this.toolStripMenuItem1,
            this.tsmLaunch,
            this.tsmPause,
            this.tsmStop,
            this.toolStripMenuItem2,
            this.tsmSysCfg});
            this.上的ToolStripMenuItem.Name = "上的ToolStripMenuItem";
            this.上的ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.上的ToolStripMenuItem.Text = "任务(&C)";
            // 
            // tsmNewTask
            // 
            this.tsmNewTask.Name = "tsmNewTask";
            this.tsmNewTask.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmNewTask.Size = new System.Drawing.Size(189, 22);
            this.tsmNewTask.Text = "新建任务(&N)";
            this.tsmNewTask.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 6);
            // 
            // tsmLaunch
            // 
            this.tsmLaunch.Name = "tsmLaunch";
            this.tsmLaunch.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmLaunch.Size = new System.Drawing.Size(189, 22);
            this.tsmLaunch.Text = "开始所有任务";
            this.tsmLaunch.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // tsmPause
            // 
            this.tsmPause.Name = "tsmPause";
            this.tsmPause.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tsmPause.Size = new System.Drawing.Size(189, 22);
            this.tsmPause.Text = "暂停所有任务";
            this.tsmPause.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // tsmStop
            // 
            this.tsmStop.Name = "tsmStop";
            this.tsmStop.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.tsmStop.Size = new System.Drawing.Size(189, 22);
            this.tsmStop.Text = "停止所有任务";
            this.tsmStop.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(186, 6);
            // 
            // tsmSysCfg
            // 
            this.tsmSysCfg.Name = "tsmSysCfg";
            this.tsmSysCfg.Size = new System.Drawing.Size(189, 22);
            this.tsmSysCfg.Text = "系统参数配置";
            this.tsmSysCfg.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            this.工具TToolStripMenuItem.Visible = false;
            // 
            // 视图VToolStripMenuItem
            // 
            this.视图VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmStart,
            this.tsmToolbar,
            this.tsmStatusBar,
            this.tsmTaskView,
            this.tsmActivedTaskWnd});
            this.视图VToolStripMenuItem.Name = "视图VToolStripMenuItem";
            this.视图VToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.视图VToolStripMenuItem.Text = "视图(&V)";
            // 
            // tsmStart
            // 
            this.tsmStart.Name = "tsmStart";
            this.tsmStart.Size = new System.Drawing.Size(184, 22);
            this.tsmStart.Text = "起始页(&S)";
            this.tsmStart.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // tsmToolbar
            // 
            this.tsmToolbar.Checked = true;
            this.tsmToolbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmToolbar.Name = "tsmToolbar";
            this.tsmToolbar.Size = new System.Drawing.Size(184, 22);
            this.tsmToolbar.Text = "工具栏(&T)";
            this.tsmToolbar.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // tsmStatusBar
            // 
            this.tsmStatusBar.Checked = true;
            this.tsmStatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmStatusBar.Name = "tsmStatusBar";
            this.tsmStatusBar.Size = new System.Drawing.Size(184, 22);
            this.tsmStatusBar.Text = "状态栏(L)";
            this.tsmStatusBar.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // tsmTaskView
            // 
            this.tsmTaskView.Name = "tsmTaskView";
            this.tsmTaskView.Size = new System.Drawing.Size(184, 22);
            this.tsmTaskView.Text = "显示任务列表";
            this.tsmTaskView.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // tsmActivedTaskWnd
            // 
            this.tsmActivedTaskWnd.Name = "tsmActivedTaskWnd";
            this.tsmActivedTaskWnd.Size = new System.Drawing.Size(184, 22);
            this.tsmActivedTaskWnd.Text = "显示已隐藏任务界面";
            this.tsmActivedTaskWnd.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmKingsure,
            this.tsmHelp});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // tsmKingsure
            // 
            this.tsmKingsure.Name = "tsmKingsure";
            this.tsmKingsure.Size = new System.Drawing.Size(124, 22);
            this.tsmKingsure.Text = "访问官网";
            this.tsmKingsure.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // tsmHelp
            // 
            this.tsmHelp.Name = "tsmHelp";
            this.tsmHelp.Size = new System.Drawing.Size(124, 22);
            this.tsmHelp.Text = "帮助";
            this.tsmHelp.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // toolbar
            // 
            this.toolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewTask,
            this.btnStartPage,
            this.btnLaunch,
            this.btnPause,
            this.btnStop,
            this.btnIni,
            this.tsmExport,
            this.btnDB});
            this.toolbar.Location = new System.Drawing.Point(0, 25);
            this.toolbar.Name = "toolbar";
            this.toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolbar.Size = new System.Drawing.Size(930, 31);
            this.toolbar.TabIndex = 10;
            this.toolbar.Text = "toolBarMain";
            // 
            // btnNewTask
            // 
            this.btnNewTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewTask.Image = ((System.Drawing.Image)(resources.GetObject("btnNewTask.Image")));
            this.btnNewTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.Size = new System.Drawing.Size(28, 28);
            this.btnNewTask.Text = "新建任务";
            this.btnNewTask.ToolTipText = "新建任务";
            this.btnNewTask.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // btnStartPage
            // 
            this.btnStartPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartPage.Image = ((System.Drawing.Image)(resources.GetObject("btnStartPage.Image")));
            this.btnStartPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartPage.Name = "btnStartPage";
            this.btnStartPage.Size = new System.Drawing.Size(28, 28);
            this.btnStartPage.Text = "起始页";
            this.btnStartPage.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // btnLaunch
            // 
            this.btnLaunch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLaunch.Image = ((System.Drawing.Image)(resources.GetObject("btnLaunch.Image")));
            this.btnLaunch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(28, 28);
            this.btnLaunch.Text = "启动所有任务";
            this.btnLaunch.ToolTipText = "启动所有任务";
            this.btnLaunch.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // btnPause
            // 
            this.btnPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
            this.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(28, 28);
            this.btnPause.Text = "暂停所有任务";
            this.btnPause.ToolTipText = "暂停所有任务";
            this.btnPause.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(28, 28);
            this.btnStop.Text = "停止所有任务";
            this.btnStop.ToolTipText = "停止所有任务";
            this.btnStop.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // btnIni
            // 
            this.btnIni.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIni.Image = ((System.Drawing.Image)(resources.GetObject("btnIni.Image")));
            this.btnIni.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIni.Name = "btnIni";
            this.btnIni.Size = new System.Drawing.Size(28, 28);
            this.btnIni.Text = "配置文件";
            this.btnIni.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // tsmExport
            // 
            this.tsmExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmExport.Image = ((System.Drawing.Image)(resources.GetObject("tsmExport.Image")));
            this.tsmExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmExport.Name = "tsmExport";
            this.tsmExport.Size = new System.Drawing.Size(28, 28);
            this.tsmExport.Text = "导出日志 url地址到任务下载目录";
            this.tsmExport.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // btnDB
            // 
            this.btnDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDB.Image = ((System.Drawing.Image)(resources.GetObject("btnDB.Image")));
            this.btnDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(28, 28);
            this.btnDB.Text = "系统数据库，推荐在关闭系统时编辑，请不要修改表结构否则系统可能会崩溃";
            this.btnDB.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "欢迎您使用金蜘蛛";
            this.notifyIcon.BalloonTipTitle = "KSpider";
            this.notifyIcon.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "[KSpider|Netscape]";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ntsmNewTask,
            this.ntsmLaunch,
            this.ntsmPause,
            this.ntsmStop,
            this.ntsmExit});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(164, 114);
            // 
            // ntsmNewTask
            // 
            this.ntsmNewTask.Name = "ntsmNewTask";
            this.ntsmNewTask.Size = new System.Drawing.Size(163, 22);
            this.ntsmNewTask.Text = "新建任务(&N)";
            this.ntsmNewTask.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // ntsmLaunch
            // 
            this.ntsmLaunch.Name = "ntsmLaunch";
            this.ntsmLaunch.Size = new System.Drawing.Size(163, 22);
            this.ntsmLaunch.Text = "启动所有任务(&L)";
            this.ntsmLaunch.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // ntsmPause
            // 
            this.ntsmPause.Name = "ntsmPause";
            this.ntsmPause.Size = new System.Drawing.Size(163, 22);
            this.ntsmPause.Text = "暂停所有任务(&P)";
            this.ntsmPause.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // ntsmStop
            // 
            this.ntsmStop.Name = "ntsmStop";
            this.ntsmStop.Size = new System.Drawing.Size(163, 22);
            this.ntsmStop.Text = "停止所有任务(&S)";
            this.ntsmStop.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // ntsmExit
            // 
            this.ntsmExit.Name = "ntsmExit";
            this.ntsmExit.Size = new System.Drawing.Size(163, 22);
            this.ntsmExit.Text = "退出系统(&Q)";
            this.ntsmExit.Click += new System.EventHandler(this.MenuAndToolbar_Click);
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Location = new System.Drawing.Point(0, 56);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(930, 433);
            this.dockPanel.TabIndex = 14;
            // 
            // statusBottom
            // 
            this.statusBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statusBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBottom.Location = new System.Drawing.Point(0, 489);
            this.statusBottom.Name = "statusBottom";
            this.statusBottom.Size = new System.Drawing.Size(930, 23);
            this.statusBottom.TabIndex = 1;
            this.statusBottom.Text = "就绪";
            this.statusBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 512);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.statusBottom);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "KMain";
            this.ShowInTaskbar = false;
            this.Text = "金速探索(KNetscape)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KMain_FormClosing);
            this.Shown += new System.EventHandler(this.KMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuTop;
        private System.Windows.Forms.ToolStripMenuItem 上的ToolStripMenuItem;
        private StatusBar statusBottom;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton btnPause;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnNewTask;
        private System.Windows.Forms.ToolStripButton btnLaunch;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmNewTask;
        private System.Windows.Forms.ToolStripMenuItem 视图VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmTaskFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmToolbar;
        private System.Windows.Forms.ToolStripMenuItem tsmStatusBar;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmLaunch;
        private System.Windows.Forms.ToolStripMenuItem tsmPause;
        private System.Windows.Forms.ToolStripMenuItem tsmStop;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmKingsure;
        private System.Windows.Forms.ToolStripMenuItem tsmActivedTaskWnd;
        private System.Windows.Forms.ToolStripMenuItem tsmTaskView;
        private System.Windows.Forms.ToolStripMenuItem tsmStart;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem ntsmNewTask;
        private System.Windows.Forms.ToolStripMenuItem ntsmLaunch;
        private System.Windows.Forms.ToolStripMenuItem ntsmPause;
        private System.Windows.Forms.ToolStripMenuItem ntsmStop;
        private System.Windows.Forms.ToolStripMenuItem ntsmExit;
        private System.Windows.Forms.ToolStripButton btnIni;
        private System.Windows.Forms.ToolStripButton tsmExport;
        private Lv.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripButton btnStartPage;
        private System.Windows.Forms.ToolStripButton btnDB;
        private System.Windows.Forms.ToolStripMenuItem tsmDB;
        private System.Windows.Forms.ToolStripMenuItem tsmSysCfg;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;

    }
}

