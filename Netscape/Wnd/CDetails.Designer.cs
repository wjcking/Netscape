namespace Netscape
{
    partial class CDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CDetails));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lnkHandle = new Netscape.Link(this.components);
            this.lkFolder = new Netscape.Link(this.components);
            this.lbSettings = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.txtOutput = new Netscape.RichTextAdvanced(this.components);
            this.cbStopOutput = new System.Windows.Forms.CheckBox();
            this.tabBottom = new System.Windows.Forms.TabControl();
            this.tpThread = new System.Windows.Forms.TabPage();
            this.lvThread = new Netscape.ListViewAdvanced(this.components);
            this.hThreadID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hThreadState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hMimeType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpDownload = new System.Windows.Forms.TabPage();
            this.txtStreamFiles = new Netscape.TextboxAdvanced(this.components);
            this.tabDetail = new System.Windows.Forms.TabPage();
            this.txtOverview = new Netscape.TextboxAdvanced(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuCDetails = new Netscape.TaskContextMenu(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabBottom.SuspendLayout();
            this.tpThread.SuspendLayout();
            this.tpDownload.SuspendLayout();
            this.tabDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lnkHandle);
            this.splitContainer1.Panel1.Controls.Add(this.lkFolder);
            this.splitContainer1.Panel1.Controls.Add(this.lbSettings);
            this.splitContainer1.Panel1.Controls.Add(this.lbTitle);
            this.splitContainer1.Panel1.Controls.Add(this.txtOutput);
            this.splitContainer1.Panel1.Controls.Add(this.cbStopOutput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabBottom);
            this.splitContainer1.Size = new System.Drawing.Size(600, 481);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 0;
            // 
            // lnkHandle
            // 
            this.lnkHandle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkHandle.AutoSize = true;
            this.lnkHandle.LinkColor = System.Drawing.Color.Black;
            this.lnkHandle.Location = new System.Drawing.Point(320, 13);
            this.lnkHandle.Name = "lnkHandle";
            this.lnkHandle.Size = new System.Drawing.Size(107, 12);
            this.lnkHandle.TabIndex = 4;
            this.lnkHandle.TabStop = true;
            this.lnkHandle.Text = "导出日志和Url地址";
            this.lnkHandle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHandle_LinkClicked);
            // 
            // lkFolder
            // 
            this.lkFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lkFolder.AutoSize = true;
            this.lkFolder.LinkColor = System.Drawing.Color.Black;
            this.lkFolder.Location = new System.Drawing.Point(433, 13);
            this.lkFolder.Name = "lkFolder";
            this.lkFolder.Size = new System.Drawing.Size(77, 12);
            this.lkFolder.TabIndex = 4;
            this.lkFolder.TabStop = true;
            this.lkFolder.Text = "打开保存目录";
            this.lkFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkFolder_LinkClicked);
            // 
            // lbSettings
            // 
            this.lbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSettings.AutoSize = true;
            this.lbSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbSettings.Location = new System.Drawing.Point(13, 260);
            this.lbSettings.Name = "lbSettings";
            this.lbSettings.Size = new System.Drawing.Size(53, 12);
            this.lbSettings.TabIndex = 3;
            this.lbSettings.Text = "欢迎使用";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTitle.Location = new System.Drawing.Point(12, 12);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(53, 12);
            this.lbTitle.TabIndex = 3;
            this.lbTitle.Text = "欢迎使用";
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutput.ForeColor = System.Drawing.Color.Lime;
            this.txtOutput.Location = new System.Drawing.Point(12, 34);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(576, 221);
            this.txtOutput.TabIndex = 2;
            this.txtOutput.Text = "抓取信息输出窗口\n右上角：点击”打开保存目录“可以查看已下载文件选择停止输出则停止滚动\n选项卡：文件类型显示下载地址可复制到下载工具批量下载（如迅雷、快车等）”任" +
    "务细节“则查看相关规则\n\n";
            // 
            // cbStopOutput
            // 
            this.cbStopOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStopOutput.AutoSize = true;
            this.cbStopOutput.Location = new System.Drawing.Point(516, 12);
            this.cbStopOutput.Name = "cbStopOutput";
            this.cbStopOutput.Size = new System.Drawing.Size(72, 16);
            this.cbStopOutput.TabIndex = 1;
            this.cbStopOutput.Text = "停止输出";
            this.cbStopOutput.UseVisualStyleBackColor = true;
            this.cbStopOutput.CheckedChanged += new System.EventHandler(this.cbStopOutput_CheckedChanged);
            // 
            // tabBottom
            // 
            this.tabBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBottom.Controls.Add(this.tpThread);
            this.tabBottom.Controls.Add(this.tpDownload);
            this.tabBottom.Controls.Add(this.tabDetail);
            this.tabBottom.Location = new System.Drawing.Point(8, 5);
            this.tabBottom.Name = "tabBottom";
            this.tabBottom.SelectedIndex = 0;
            this.tabBottom.Size = new System.Drawing.Size(580, 180);
            this.tabBottom.TabIndex = 0;
            this.tabBottom.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabBottom_Selected);
            // 
            // tpThread
            // 
            this.tpThread.Controls.Add(this.lvThread);
            this.tpThread.Location = new System.Drawing.Point(4, 22);
            this.tpThread.Name = "tpThread";
            this.tpThread.Padding = new System.Windows.Forms.Padding(3);
            this.tpThread.Size = new System.Drawing.Size(572, 154);
            this.tpThread.TabIndex = 0;
            this.tpThread.Text = "队列消息";
            this.tpThread.UseVisualStyleBackColor = true;
            // 
            // lvThread
            // 
            this.lvThread.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hThreadID,
            this.hThreadState,
            this.hStatus,
            this.hUrl,
            this.hMimeType});
            this.lvThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvThread.FullRowSelect = true;
            this.lvThread.GridLines = true;
            this.lvThread.Location = new System.Drawing.Point(3, 3);
            this.lvThread.Name = "lvThread";
            this.lvThread.Size = new System.Drawing.Size(566, 148);
            this.lvThread.TabIndex = 3;
            this.lvThread.UseCompatibleStateImageBehavior = false;
            this.lvThread.View = System.Windows.Forms.View.Details;
            // 
            // hThreadID
            // 
            this.hThreadID.Text = "队列ID";
            this.hThreadID.Width = 54;
            // 
            // hThreadState
            // 
            this.hThreadState.Text = "队列状态";
            this.hThreadState.Width = 70;
            // 
            // hStatus
            // 
            this.hStatus.Text = "执行状态";
            this.hStatus.Width = 71;
            // 
            // hUrl
            // 
            this.hUrl.Text = "队列中URL";
            this.hUrl.Width = 351;
            // 
            // hMimeType
            // 
            this.hMimeType.Text = "文件类型";
            this.hMimeType.Width = 100;
            // 
            // tpDownload
            // 
            this.tpDownload.Controls.Add(this.txtStreamFiles);
            this.tpDownload.Location = new System.Drawing.Point(4, 22);
            this.tpDownload.Name = "tpDownload";
            this.tpDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tpDownload.Size = new System.Drawing.Size(572, 154);
            this.tpDownload.TabIndex = 1;
            this.tpDownload.Text = "文件类型";
            this.tpDownload.UseVisualStyleBackColor = true;
            // 
            // txtStreamFiles
            // 
            this.txtStreamFiles.AllowDrop = true;
            this.txtStreamFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStreamFiles.Location = new System.Drawing.Point(3, 3);
            this.txtStreamFiles.Multiline = true;
            this.txtStreamFiles.Name = "txtStreamFiles";
            this.txtStreamFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStreamFiles.Size = new System.Drawing.Size(566, 148);
            this.txtStreamFiles.TabIndex = 0;
            this.txtStreamFiles.WordWrap = false;
            // 
            // tabDetail
            // 
            this.tabDetail.AutoScroll = true;
            this.tabDetail.Controls.Add(this.txtOverview);
            this.tabDetail.Location = new System.Drawing.Point(4, 22);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetail.Size = new System.Drawing.Size(572, 154);
            this.tabDetail.TabIndex = 2;
            this.tabDetail.Text = "任务细节";
            this.tabDetail.UseVisualStyleBackColor = true;
            // 
            // txtOverview
            // 
            this.txtOverview.AllowDrop = true;
            this.txtOverview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOverview.Location = new System.Drawing.Point(3, 3);
            this.txtOverview.Multiline = true;
            this.txtOverview.Name = "txtOverview";
            this.txtOverview.ReadOnly = true;
            this.txtOverview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOverview.Size = new System.Drawing.Size(566, 148);
            this.txtOverview.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Interval = 250;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // menuCDetails
            // 
            this.menuCDetails.Name = "taskContextMenu";
            this.menuCDetails.Size = new System.Drawing.Size(242, 214);
            this.menuCDetails.TaskID = 0;
            this.menuCDetails.ClickedTask += new Netscape.TaskMenuHandler(this.taskContextMenu_ClickedTask);
            this.menuCDetails.Opening += new System.ComponentModel.CancelEventHandler(this.taskContextMenu_Opening);
            // 
            // CDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 481);
            this.ContextMenuStrip = this.menuCDetails;
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CDetails";
            this.TabPageContextMenuStrip = this.menuCDetails;
            this.TabText = "CrawlerDetails";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CDetails_FormClosing);
            this.Shown += new System.EventHandler(this.CDetails_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabBottom.ResumeLayout(false);
            this.tpThread.ResumeLayout(false);
            this.tpDownload.ResumeLayout(false);
            this.tpDownload.PerformLayout();
            this.tabDetail.ResumeLayout(false);
            this.tabDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabBottom;
        private System.Windows.Forms.TabPage tpThread;
        private System.Windows.Forms.TabPage tpDownload;
        private ListViewAdvanced lvThread;
        private System.Windows.Forms.CheckBox cbStopOutput;
        private RichTextAdvanced txtOutput;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ColumnHeader hThreadID;
        private System.Windows.Forms.ColumnHeader hStatus;
        private System.Windows.Forms.ColumnHeader hUrl;
        private System.Windows.Forms.ColumnHeader hMimeType;
        private System.Windows.Forms.ColumnHeader hThreadState;
        private System.Windows.Forms.Label lbSettings;
        private Link lkFolder;
        private TaskContextMenu menuCDetails;
        private System.Windows.Forms.TabPage tabDetail;

        private TextboxAdvanced txtStreamFiles;
        private TextboxAdvanced txtOverview;
        private Link lnkHandle;

    }
}