namespace Netscape
{
    partial class TaskContextMenu
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tsmTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPause = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmDownloadFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIni = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClearTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExportTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCloseWnd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCloseAllButThis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.sepCDetails = new System.Windows.Forms.ToolStripSeparator();
            this.SuspendLayout();
            // 
            // tsmTask
            // 
            this.tsmTask.Name = "tsmTask";
            this.tsmTask.Size = new System.Drawing.Size(241, 22);
            this.tsmTask.Text = "编辑任务(&E)";
            this.tsmTask.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
            // 
            // tsmStart
            // 
            this.tsmStart.Name = "tsmStart";
            this.tsmStart.Size = new System.Drawing.Size(241, 22);
            this.tsmStart.Text = "启动(&L)";
            this.tsmStart.Click += new System.EventHandler(this.Menu_Click);
            // 
            // tsmPause
            // 
            this.tsmPause.Name = "tsmPause";
            this.tsmPause.Size = new System.Drawing.Size(241, 22);
            this.tsmPause.Text = "暂停(&P)";
            this.tsmPause.Click += new System.EventHandler(this.Menu_Click);
            // 
            // tsmStop
            // 
            this.tsmStop.Name = "tsmStop";
            this.tsmStop.Size = new System.Drawing.Size(241, 22);
            this.tsmStop.Text = "停止(&S)";
            this.tsmStop.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(238, 6);
            // 
            // tsmDownloadFolder
            // 
            this.tsmDownloadFolder.Name = "tsmDownloadFolder";
            this.tsmDownloadFolder.Size = new System.Drawing.Size(241, 22);
            this.tsmDownloadFolder.Text = "打开下载目录(&F)";
            this.tsmDownloadFolder.Click += new System.EventHandler(this.Menu_Click);
            // 
            // tsmIni
            // 
            this.tsmIni.Name = "tsmIni";
            this.tsmIni.Size = new System.Drawing.Size(241, 22);
            this.tsmIni.Text = "系统配置(&I)";
            this.tsmIni.Click += new System.EventHandler(this.Menu_Click);
            // 
            // tsmDeleteTask
            // 
            this.tsmDeleteTask.Name = "tsmDeleteTask";
            this.tsmDeleteTask.Size = new System.Drawing.Size(241, 22);
            this.tsmDeleteTask.Text = "删除任务";
            this.tsmDeleteTask.Click += new System.EventHandler(this.Menu_Click);
            // 
            // tsmClearTask
            // 
            this.tsmClearTask.Name = "tsmClearTask";
            this.tsmClearTask.Size = new System.Drawing.Size(241, 22);
            this.tsmClearTask.Text = "清除任务记录";
            // 
            // tsmExportTask
            // 
            this.tsmExportTask.Name = "tsmExportTask";
            this.tsmExportTask.Size = new System.Drawing.Size(241, 22);
            this.tsmExportTask.Text = "导出任务记录(日志、Url地址）";
            // 
            // tsmCloseWnd
            // 
            this.tsmCloseWnd.Name = "tsmCloseWnd";
            this.tsmCloseWnd.Size = new System.Drawing.Size(241, 22);
            this.tsmCloseWnd.Text = "关闭窗口(&C)";
            this.tsmCloseWnd.Visible = false;
            // 
            // tsmCloseAllButThis
            // 
            this.tsmCloseAllButThis.Name = "tsmCloseAllButThis";
            this.tsmCloseAllButThis.Size = new System.Drawing.Size(241, 22);
            this.tsmCloseAllButThis.Text = "除此之外全部关闭";
            this.tsmCloseAllButThis.Visible = false;
            // 
            // tsmCloseAll
            // 
            this.tsmCloseAll.Name = "tsmCloseAll";
            this.tsmCloseAll.Size = new System.Drawing.Size(241, 22);
            this.tsmCloseAll.Text = "关闭所有窗口";
            this.tsmCloseAll.Visible = false;
            // 
            // sepCDetails
            // 
            this.sepCDetails.Name = "sepCDetails";
            this.sepCDetails.Size = new System.Drawing.Size(238, 6);
            this.sepCDetails.Visible = false;
            // 
            // TaskContextMenu
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmStart,
            this.tsmPause,
            this.tsmStop,
            this.sepCDetails,
            this.tsmCloseWnd,
            this.tsmCloseAllButThis,
            this.tsmCloseAll,
            this.toolStripSeparator1,
            this.tsmTask,
            this.tsmClearTask,
            this.tsmDeleteTask,
            this.tsmExportTask,
            this.toolStripSeparator2,
            this.tsmDownloadFolder,
            this.tsmIni});
            this.Size = new System.Drawing.Size(242, 286);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmTask;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmStart;
        private System.Windows.Forms.ToolStripMenuItem tsmPause;
        private System.Windows.Forms.ToolStripMenuItem tsmStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmDownloadFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmIni;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteTask;
        private System.Windows.Forms.ToolStripMenuItem tsmClearTask;
        private System.Windows.Forms.ToolStripMenuItem tsmExportTask;
        private System.Windows.Forms.ToolStripMenuItem tsmCloseWnd;
        private System.Windows.Forms.ToolStripMenuItem tsmCloseAllButThis;
        private System.Windows.Forms.ToolStripMenuItem tsmCloseAll;
        private System.Windows.Forms.ToolStripSeparator sepCDetails;
    }
}
