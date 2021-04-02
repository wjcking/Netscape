
using KCrawler;
using Lv.Docking;
using System;
using System.Text;
using System.Windows.Forms;
namespace Netscape
{
    public partial class CDetails : DockContent
    {
        private int crawlerUrlIndex = 0;
        private int loggerIndex = 0;
   //     private int streamFileIndex = 0;
        private StringBuilder crawlerInfo = new StringBuilder();
        public event StatusEventHandler CrawlerStatusChanged;
        private StatusEventArgs statusArgs = new StatusEventArgs();
        public Downloader Spider { get; set; }
        public CDetails()
        {
            InitializeComponent();
            timer.Interval = KConfig.Interval;

        }
        public int TaskID
        {
            get
            {
                return Spider.CrawlerInfo.ID;
            }
        }

        public TaskInfo CrawlerInfo
        {
            get
            {
                return Spider.CrawlerInfo;
            }
        }
        private void Init()
        {
        
            lvThread.Items.Clear();
            //初始化最后一次记录的个数
            if (Spider.CrawledUrls != null)
                crawlerUrlIndex = Spider.CrawledUrls.Count;
            loggerIndex = Spider.Logger.Log.Count;
            //   streamFileIndex = Downloader.StreamFile.Count;
            TabText = Spider.CrawlerInfo.TaskName;

            lkFolder.AccessibleName = Spider.CrawlerInfo.DownloadFolder;
            int index = 0;
            foreach (CrawlerThread ct in Spider.ThreadCrawlers)
            {
                lvThread.Items.Add(ct.Name);
                lvThread.Items[index].SubItems.Add(ct.CThread.ThreadState.ToString());
                lvThread.Items[index].SubItems.Add(ct.StatusText);
                lvThread.Items[index].SubItems.Add(ct.Url);
                lvThread.Items[index].SubItems.Add(ct.MimeType);
                index++;
            }
            RefreshInfo();
        }

        private void CDetails_Shown(object sender, System.EventArgs e)
        {
            //刷新数据事件
            Leave += delegate
            {
                timer.Stop();
            };
            Enter += delegate
            {
                //滚动输出间隔
                timer.Interval = KConfig.Interval;
                //初始化最后一次记录的个数
                crawlerUrlIndex = Spider.CrawledUrls.Count;
                loggerIndex = Spider.Logger.Log.Count;
                //初始化配置值
                RefreshInfo();
                if (!cbStopOutput.Checked)
                timer.Start();
            };
            Init();
            timer.Start();
        }

        private void CDetails_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            timer.Stop();
            Hide();
            e.Cancel = true;
        }
        //点击，焦点 但不在定时器里面
        private void RefreshInfo()
        {
            try
            {
                txtOutput.AppendLine(Spider.TotalCountInfo);
                StringBuilder sets = new StringBuilder();
                sets.Append(R.CDetails_EntranceURL + Spider.CrawlerInfo.EntranceURL).Append(" "); 
                sets.Append(R.CDetails_DownloadFolder + Spider.CrawlerInfo.DownloadFolder).Append(" ");
                lbSettings.Text = sets.ToString();
                tabDetail.Text = R.CDetails_TaskDetail + (String.IsNullOrEmpty(Spider.TotalCountInfo) ? String.Empty : "[" + Spider.TotalCountInfo + "]");
                txtOutput.AppendLine(CK.ColorStart, Spider.Logger.LogCountText);
                txtOutput.AppendLine(Spider.UrlsQueueFrontier.QueueTotal);
                if (Spider.FilePool.Count != 0)
                    tpDownload.Text = R.CDetails_FileTotals + Spider.FilePool.Count.ToString();
            }
            catch (Exception exp)
            {
                txtOutput.AppendLine(System.Drawing.Color.Red, string.Format(CK.BracketsAndInfo, DateTime.Now, exp.Message));
            }
        }

        //定时更新
        public void RefreshData()
        {
            try
            {

                lkFolder.AccessibleName = Spider.CrawlerInfo.DownloadFolder;
                crawlerInfo.Append(R.CDetails_QueueCount + Spider.UrlsQueueFrontier.Count).Append(" ");
                crawlerInfo.Append(R.CDetails_CrawledUrl + Spider.CrawledUrls.Count).Append(" ");
                crawlerInfo.Append(R.CDetails_FileTotals + Spider.FilePool.Count).Append(" ");

                lbTitle.Text = crawlerInfo.ToString();
                crawlerInfo.Remove(0, crawlerInfo.Length);
                //修改线程个数后重置
                if (Spider.ThreadCrawlers.Length != lvThread.Items.Count)
                    Init();
                for (int i = 0; i < Spider.ThreadCrawlers.Length; i++)
                {
                    lvThread.Items[i].SubItems[1].Text = Spider.ThreadCrawlers[i].CThread.ThreadState.ToString();
                    lvThread.Items[i].SubItems[2].Text = Spider.ThreadCrawlers[i].StatusText;
                    lvThread.Items[i].SubItems[3].Text = Spider.ThreadCrawlers[i].Url;
                    lvThread.Items[i].SubItems[4].Text = Spider.ThreadCrawlers[i].MimeType;
                }
                //url地址
                if (crawlerUrlIndex < Spider.CrawledUrls.Count && Spider.CrawlerInfo.NotSave)
                {
                    txtOutput.AppendText(String.Format("[{0}] {1} \r\n", crawlerUrlIndex + 1, Spider.CrawledUrls[crawlerUrlIndex]));
                    crawlerUrlIndex++;
                }
                //日志
                if (loggerIndex < Spider.Logger.Log.Count)
                {
                    statusArgs.IsShowOnBallon = false;
                    statusArgs.Info(CrawlerInfo.TaskName + Spider.Logger[loggerIndex].LogOut);

                    txtOutput.AppendLine(Spider.Logger[loggerIndex].Color, Spider.Logger[loggerIndex].LogOut);
                    loggerIndex++;
                    //if (CrawlerStatusChanged != null)
                    //    CrawlerStatusChanged(null, statusArgs);
                }
                //压缩下载文件

                //if (streamFileIndex < Spider.FilePool.Count)
                //{
                //   statusArgs.Info(Downloader.CrawlerSets.TaskName + " " + R.CDetails_FileTotals + Downloader.FilePool.Count);
                //txtStreamFiles.AppendText(Downloader.FilePool[streamFileIndex] + Environment.NewLine);
                //streamFileIndex++;
                //if (CrawlerStatusChanged != null)
                //    CrawlerStatusChanged(null, statusArgs);
                //}

                if (Spider.UrlsQueueFrontier.Count == 0 && Spider.Status == DownloaderStatus.Stopped)
                {

                    timer.Stop();
                    statusArgs.IsShowOnBallon = true;
                    statusArgs.Info(Spider.CrawlerInfo.TaskName + " " + R.CDetails_Done);
                    if (CrawlerStatusChanged != null)
                        CrawlerStatusChanged(null, statusArgs);
                }
            }
            catch (Exception exp)
            {
                txtOutput.AppendLine(System.Drawing.Color.Red, string.Format(CK.BracketsAndInfo, DateTime.Now, exp.Message));
            }
        }
        private void timer_Tick(object sender, System.EventArgs e)
        {

            if (Spider.Status == DownloaderStatus.Stopped || DownloaderStatus.Paused == Spider.Status)
            {
                timer.Stop();
            }
            TabText = CrawlerInfo.TaskName + "[" + Spider.StatusText + "]";
            RefreshData();

        }

        private void taskContextMenu_ClickedTask(object sender, EventArgs e)
        {

            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            switch (tsm.Name)
            {
                case "tsmStart":
                    txtOutput.AppendLine(CK.ColorStart, R.KMain_Progressing);

                    Task.ThreadProc(Spider.Start);
                    TabText = CrawlerInfo.TaskName + "[" + Spider.StatusText + "]";

                    if (!timer.Enabled)
                        timer.Start();
                    return;
                case "tsmCloseWnd":
                    Hide();
                    return;
                case "tsmCloseAllButThis":
                 Task.HideView(  TaskID);
                 return;
                case "tsmCloseAll":
                 Task.HideView();
                    return;
            }

        }

        private void taskContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            menuCDetails.TaskID = Spider.CrawlerInfo.ID;
            menuCDetails.ChangeMenuStrip(Spider.Status);
            menuCDetails.ChangeMenuStrip(this.GetType());
        }

        private void tabBottom_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex < 0)
                return;
            if (e.TabPage != tpThread)
                RefreshInfo();
            if (e.TabPage == tpDownload) 
                txtStreamFiles.Text = Spider.FileTotalUrls; 
            if (e.TabPage == tabDetail)
                txtOverview.Text = Spider.Overview;
        }
        //timer是否停止
        private void cbStopOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStopOutput.Checked)
            {
                RefreshInfo();
                timer.Stop();
            }
            else
                timer.Start();
        }

        private void lnkHandle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Spider.Dump(R.Dump_Type_Export);
            Spider.WriteXmlFile();
            if (MessageBox.Show(R.CTask_ExportedInfo, CrawlerInfo.TaskName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                InteropPlus.Redirect(CrawlerInfo.DownloadFolder);
        }

        private void lkFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

    }
}
