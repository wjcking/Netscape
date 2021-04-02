
namespace Netscape
{
    using KCrawler;
    using Lv.Docking;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public partial class CTask : DockContent
    {
        public event CTaskLivtViewHandler DownloaderSelected;
        public event StatusEventHandler CrawlerStatusChanged;
        private StatusEventArgs statusArgs = new StatusEventArgs();
        private StringBuilder sets = new StringBuilder();
        private static List<TaskInfo> taskList;
        
        public CTask()
        {
            InitializeComponent();
            Init();
        }
        //更新任务后，Ctask缓存列表更新
        internal static void UpdateCTask(ref TaskInfo ti)
        {
            if (null == taskList)
                return;

            for(int i=0;i<taskList.Count;i++)
            {
                if (taskList[i].ID == ti.ID)
                {
                    taskList[i] = ti;
                    return;
                }
            }
        }

        private void Init()
        {
            lvTask.Items.Clear();
            int index;
            taskList = TaskCache.GetTaskList();
            for (int i = 0; i < taskList.Count; i++)
            {
                index = i + 1;
                lvTask.Items.Add(taskList[i].MinKB);

                lvTask.Items[i].SubItems.Add(taskList[i].TaskName);
                lvTask.Items[i].SubItems.Add(DownloaderStatus.Stopped.ToString());            
                lvTask.Items[i].ToolTipText = (taskList[i].DownloadFolder);
                //    if (taskList[i].IsInternal)
                lvTask.Items[i].SubItems.Add(taskList[i].IsInternal.ToString());
                //    if (taskList[i].NotSave)
                lvTask.Items[i].SubItems.Add(taskList[i].NotSave.ToString());
            }
        }
        public void RefreshData()
        {
            
            //任务缓存移除后重置listview
            if (!Cache.KCache.Contains(TaskCache.C_TaskList))
            {
                Init();
                return;
            }
            for (int i = 0; i < lvTask.Items.Count; i++)
            {
                lvTask.Items[i].Text = taskList[i].MinKB;
                lvTask.Items[i].SubItems[1].Text = taskList[i].TaskName;
                if (taskList[i].IsLunched )
                    lvTask.Items[i].SubItems[2].Text = Task.GetSpiderView(taskList[i].ID).Spider.StatusText;
                lvTask.Items[i].SubItems[3].Text = taskList[i].IsInternal ? R.CTasK_IsInternal : String.Empty; lvTask.Items[i].SubItems[3].Text = taskList[i].IsInternal ? R.CTasK_IsInternal : String.Empty;
                lvTask.Items[i].SubItems[4].Text = taskList[i].NotSave ? R.CTasK_AreOnlyLinks : String.Empty;
            }

            //每2分钟保存一次爬去数据
            if (DateTime.Now.Minute % 2 == 0 && DateTime.Now.Second % 59 == 0)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Task.ThreadQueueSave));
        
                ThreadPool.QueueUserWorkItem(new WaitCallback(Task.WriteXmlFile));
                Thread.Sleep(750);
        
            }
        }
        private void CTask_Shown(object sender, EventArgs e)
        {
            timerStatus.Start();
        }


        private void Start()
        {
            if (lvTask.SelectedIndices.Count <= 0)
                return;

            int index = lvTask.SelectedIndices[0];
            taskList[index].IsLunched = true;
            CDetails cd = Task.GetSpiderView(taskList[index].ID);

            //如果已经启动则跳出
            if (cd.Spider.Status == DownloaderStatus.Running)
            {
                if (DownloaderSelected != null)
                    DownloaderSelected(this, new CTaskEventArgs(cd));
                return;
            }

            //如果暂停则恢复
            if (cd.Spider.Status == DownloaderStatus.Paused)
            {
                if (DownloaderSelected != null)
                    DownloaderSelected(this, new CTaskEventArgs(cd));
                cd.Spider.Resume();
                return;
            }
            //开启任务
            //   lvTask.Items[index].SubItems[2].Text = R.CTask_StartingTask;

            statusArgs.Start(R.CTask_StartingTask);
            if (CrawlerStatusChanged != null)
                CrawlerStatusChanged(null, statusArgs);

            Thread threadStartTask = new Thread(new ThreadStart(Task.GetSpiderView(taskList[index].ID).Spider.Start));
            threadStartTask.Start();
            while (true)
            {
                if (!threadStartTask.IsAlive)
                {
                    statusArgs.Done(R.CDetails_Done);
                    if (DownloaderSelected != null)
                        DownloaderSelected(this, new CTaskEventArgs(cd));
                    break;
                }
                Application.DoEvents();
                Thread.Sleep(100);
            }

            if (CrawlerStatusChanged != null)
                CrawlerStatusChanged(null, statusArgs);
        }


        private void lvTask_DoubleClick(object sender, EventArgs e)
        {
            Start();
        }
        private void taskContextMenu_MenuItemClicked(object sender, EventArgs e)
        {
            if (lvTask.SelectedIndices.Count <= 0)
            {
                MessageBox.Show(R.CTask_NullTaskSelected);
                return;
            }
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;

            if (tsm == null)
                return;

            switch (tsm.Name)
            {
                case "tsmStart":
                    Start();
                    break;
                case "tsmDeleteTask":
                    DeleteTask();
                    return;
            }
        }

      
        //刷新事件
        private void timerStatus_Tick(object sender, EventArgs e)
        {
            RefreshData();
   
        }
        //这里控制快捷菜单，根据任务id
        private void taskContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (lvTask.SelectedIndices.Count <= 0)
                return;
            taskContextMenu.TaskID = taskList[lvTask.SelectedIndices[0]].ID;
            taskContextMenu.ChangeMenuStrip(Task.GetSpiderView(taskContextMenu.TaskID).Spider.Status);

        }

        private void lvTask_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Delete)
                return;
            if (lvTask.SelectedIndices.Count <= 0)
                return;
            DeleteTask();
        }
        private void DeleteTask()
        {
            DialogResult dr = MessageBox.Show(R.CTask_ConfirmRemoveTask, String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == System.Windows.Forms.DialogResult.No)
                return;
            Task.GetSpiderView(taskList[lvTask.SelectedIndices[0]].ID).Spider.Abort();
            TaskDao.DeleteTask(taskList[lvTask.SelectedIndices[0]].ID);
            //清缓存
            Cache.ClearTaskList();
            Task.GetSpiderView(taskList[lvTask.SelectedIndices[0]].ID).Close();
            Init();
        }
        //主窗体任务栏
        private void lvTask_MouseClick(object sender, MouseEventArgs e)
        {
            if (lvTask.SelectedIndices.Count <= 0)
                return;
            int index = lvTask.SelectedIndices[0];

            sets.AppendFormat("[{0}]", taskList[index].TaskName);
            sets.Append(R.CDetails_EntranceURL + taskList[index].EntranceURL).Append(" "); ;

            if (!string.IsNullOrEmpty(taskList[index].Unicode))
                sets.Append(R.CDetails_Unicode + taskList[index].Unicode).Append(" ");

            sets.Append(R.CDetails_DownloadFolder + taskList[index].DownloadFolder).Append(" ");
            statusArgs.Info(sets.ToString());
            sets.Remove(0, sets.Length);
            if (CrawlerStatusChanged != null)
                CrawlerStatusChanged(null, statusArgs);
        }

    }
}
