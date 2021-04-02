
using KCrawler;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Netscape
{
    public partial class TaskContextMenu : ContextMenuStrip
    {
        public event TaskMenuHandler ClickedTask;

        public int TaskID { get; set; }
        public TaskContextMenu()
        {
            InitializeComponent();
        }

        public TaskContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            tsmClearTask.Click += Menu_Click;
            tsmExportTask.Click += Menu_Click;
            tsmCloseWnd.Click += Menu_Click;
            tsmCloseAllButThis.Click += Menu_Click;
            tsmCloseAll.Click += Menu_Click;

        }

        //根据运行状态显示菜单项
        internal void ChangeMenuStrip(DownloaderStatus ds)
        {
            tsmStart.Enabled = true;
            tsmStop.Enabled = true;
            //      tsmPause.Enabled = true;
            switch (ds)
            {
                case DownloaderStatus.Running:
                    tsmStart.Enabled = false;
                    break;
                case DownloaderStatus.Paused:
                    tsmPause.Enabled = false;
                    break;
                case DownloaderStatus.Stopped:
                    tsmStop.Enabled = false;
                    tsmPause.Enabled = false;
                    break;
            }
        }


        private void Export()
        {
            Task.ThreadProc(Task.GetSpiderView(TaskID).Spider.Dump);
            if (MessageBox.Show(R.CTask_ExportedInfo, Task.GetSpiderView(TaskID).CrawlerInfo.TaskName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Process.Start(Task.GetSpiderView(TaskID).CrawlerInfo.DownloadFolder);
        }
        private void Menu_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            if (ClickedTask != null)
                ClickedTask(tsm, e);

            switch (tsm.Name)
            {
                case "tsmIni":
                    KGeneral.GetInstance();
                    break;
            }

            if (TaskID == 0)
                return;

            switch (tsm.Name)
            {
                case "tsmDownloadFolder":
                    if (System.IO.Directory.Exists(Task.GetSpiderView(TaskID).CrawlerInfo.DownloadFolder))
                        Process.Start(Task.GetSpiderView(TaskID).CrawlerInfo.DownloadFolder);
                    break;
                //case "tsmDeleteTask":
                //    DeleteTask();
                //    break;
                case "tsmTask":
                    ACrawler acrawler = new ACrawler(TaskID);
                    acrawler.Show();
                    break;
                case "tsmPause":
                    Task.GetSpiderView(TaskID).Spider.Suspend();
                    break;
                case "tsmStop":
                    Task.ThreadProc(Task.GetSpiderView(TaskID).Spider.Abort);
                    break;
                case "tsmClearTask":
                    if (MessageBox.Show(R.CTask_ClearTask + Task.GetSpiderView(TaskID).CrawlerInfo.TaskName, TaskID.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Task.GetSpiderView(TaskID).Spider.Clear();
                    break;
                case "tsmExportTask":
                    Export();
                    break;

            }
        }

        internal void ChangeMenuStrip(Type type)
        {
            if (type == typeof(CDetails))
            {
                tsmDeleteTask.Visible = false;
                tsmCloseAllButThis.Visible = true;
                tsmCloseWnd.Visible = true;
                tsmCloseAll.Visible = true;
                sepCDetails.Visible = true;
            }
        }
    }
}
