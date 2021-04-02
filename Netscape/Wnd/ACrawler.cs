using System;
using System.Windows.Forms;
using KCrawler;
using System.Threading;
using System.IO;

namespace Netscape
{   
    public partial class ACrawler : Form
    {
        private string previousUrl;
        private TaskInfo taskInfo;
        //新建
        public ACrawler()
        {
            InitializeComponent();
        }

        //access 整形taskid
        public ACrawler(int taskid)
        {
            InitializeComponent();
            if (null == taskInfo)
            {
                taskInfo = TaskDao.GetTaskInfo(taskid);
                ucCookies1.TaskID = taskInfo.ID;
                ucPriority.TaskID = taskInfo.ID;
                //如果设置优先级，偏好为默认
                ucPriority.PriorityLevelClicked += delegate { taskInfo.Category = string.Empty; listPreference.SelectedIndex = 0; };
                ucFilter.TaskID = taskInfo.ID;
                ucUrlKeyword1.TaskID = taskInfo.ID;
                ucHtmlKeywords1.TaskID = taskInfo.ID;
                ucExtract1.TaskID = taskInfo.ID;
                listPreference.SelecteMCate(taskInfo.Category);
            }
            InitializeTask();
        }
        //初始化
        private void ACrawler_Shown(object sender, EventArgs e)
        {
            //清空task=0
            TaskDao.DeleteTask(false, 0);
            listPreference.SelectionMode = SelectionMode.One;
            listPreference.BindMimeCategory();

            if (null != taskInfo)
            {
                listPreference.SelecteMCate(taskInfo.Category);                
            }
            else
            {
                numMinFileSize.Value = KConfig.GetMinKB(String.Empty);
            }

            lbFolder.Text = R.ACrawler_DownloadFolderInfo + InteropPlus.TaskFolder;
            chkFilterAll.Checked = KConfig.IsFilterAll;
            chkInsertUKey.Checked = KConfig.IsAddUrlKeyword;
            lbKeyword.Text += PFCache.LabelForMCate;
        }

        private void ACrawler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (taskInfo == null)
                TaskDao.DeleteTask(false, 0);
        }


        //access数据
        private void InitializeTask()
        {

            Text = taskInfo.ID.ToString() + " " + taskInfo.TaskName;
            //替换回来
            previousUrl = txtUrl.Text = taskInfo.EntranceURL.Replace(",", "\r\n");
            drpUnicode.Text = taskInfo.Unicode;
            txtTaskName.Text = taskInfo.TaskName.Trim();

            threadsCount.Value = taskInfo.ThreadCount;
            sleepTime.Value = taskInfo.ThreadSleepTimeWhenQueueIsEmpty;
            connectionTimeout.Value = taskInfo.ConnectionTimeout;
            txtDownloadFolder.Text = taskInfo.DownloadFolder;

            cbInternal.Checked = taskInfo.IsInternal;
            cbNotSave.Checked = taskInfo.NotSave;
            txtDescription.Text = taskInfo.Description;
            numMinFileSize.Value = taskInfo.MinFileSize;
        }

        private void AddTaskInfo()
        {
            errorProvider.Clear();
            if (string.IsNullOrEmpty(txtTaskName.Text))
            {
                errorProvider.SetError(txtTaskName, R.Empty_TaskName);
                txtTaskName.Focus();
                return;
            }
            tabControlSettings.SelectedTab = tabBasic;
            //入口地址判断
            try
            {
                Uri uri = new Uri(txtUrl.Text);
            }
            catch (Exception eUrl)
            {
                errorProvider.SetError(txtUrl, eUrl.Message);
                txtUrl.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDownloadFolder.Text))
            {
                txtDownloadFolder.Text = InteropPlus.TaskFolder + txtTaskName.Text;
                try
                {
                    if (!Directory.Exists(txtDownloadFolder.Text))
                        Directory.CreateDirectory(txtDownloadFolder.Text);
                }
                catch (Exception exp)
                {
                    errorProvider.SetError(txtDownloadFolder, exp.Message);
            
                    return;
                }
            }

            bool isNew = false;
            if (null == taskInfo)
            {
                isNew = true;
                taskInfo = new TaskInfo();
            }
            taskInfo.EntranceURL = txtUrl.Lines.Length == 1 ? txtUrl.Lines[0] : txtUrl.Text.Replace("\r\n", ",");
            taskInfo.ThreadCount = Convert.ToInt32(threadsCount.Value);
            taskInfo.ThreadSleepTimeWhenQueueIsEmpty = Convert.ToInt32(sleepTime.Value);
            taskInfo.ConnectionTimeout = Convert.ToInt32(connectionTimeout.Value);
            taskInfo.DownloadFolder = txtDownloadFolder.Text;
            taskInfo.TaskName = txtTaskName.Text;
            taskInfo.IsInternal = cbInternal.Checked;
            taskInfo.NotSave = cbNotSave.Checked;
            taskInfo.Description = txtDescription.Text;
            taskInfo.MinFileSize = Convert.ToInt32(numMinFileSize.Value);
            if (drpUnicode.SelectedIndex == 0)
                taskInfo.Unicode = string.Empty;
            else
                taskInfo.Unicode = drpUnicode.Text;
            //添加完毕后获得taskid
            if (isNew)
            {
                taskInfo.ID = TaskDao.AddTask(taskInfo);
                TaskCache.ClearTaskList();
            }
            else
            {
                TaskDao.UpdateTask(taskInfo);
                CTask.UpdateCTask(ref taskInfo);
            }
            //更新事先添加好的优先级过滤器cookies
            listPreference.UpdatePreference(ref taskInfo);
            //重置任务列表个数
            CTask.UpdateCTask(ref taskInfo);
            Cache.ClearTaskInfo(taskInfo.ID);
            Task.GetSpiderView(taskInfo.ID).Spider.RefreshTaskInfo();
            //配置文件
            taskInfo.IsFilterAllMime = KConfig.IsFilterAll = chkFilterAll.Checked;
            taskInfo.IsAddUkey = KConfig.IsAddUrlKeyword = chkInsertUKey.Checked;
            KConfig.SetMinFileSize(taskInfo.Category, Convert.ToInt32(numMinFileSize.Value));
            Text = txtTaskName.Text;
            //and send
            if (previousUrl != taskInfo.EntranceURL)
            {
                Thread t = new Thread(new ParameterizedThreadStart(InteropPlus.Send));
                t.Start(taskInfo);
            }

            Close();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "btnFolder":
                    InteropPlus.BindFolder(ref txtDownloadFolder);
                    break;
                case "btnCancel":
                    Close();
                    break;
                case "btnRedirect":
                    InteropPlus.Redirect(ref txtUrl);
                    return;
                case "btnOK":
                    AddTaskInfo();
                    return;
            }
        }

        private void tabBasic_Click(object sender, EventArgs e)
        {
            if (null == tabControlSettings.SelectedTab)
                return;

            switch (tabControlSettings.SelectedTab.Name)
            {
                case "tabBasic":
                    if (null != taskInfo)
                        listPreference.SelecteMCate(taskInfo.Category);
                    return;
                case "tabHttpHeaders":
                    ucCookies1.BindData();
                    return;
                case "tabPriority":
                    ucPriority.BindData();
                    return;
                case "tabFilter":
                    ucFilter.BindData();
                    return;
                case "tabUrlKeywords":
                    ucUrlKeyword1.BindData();
                    return;
                case "tabHtmlKeyword":
                    ucHtmlKeywords1.BindData();
                    return;
                case "tabExtract":

                    ucExtract1.BindData();
                    if (null != taskInfo)
                    ucExtract1.SetUrlAddress(taskInfo.EntranceURL);
                    return;
            }
        }

        private void drpUnicode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucExtract1.Unicode = drpUnicode.Text;
        }


    }
}
