using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using KCrawler;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace Netscape
{

    /// <summary>
    /// web浏览器，网络提交，盘等
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(true)]
    public class InteropPlus
    {

        private static string requestPage = "http://www.easyfound.com.cn/Request/Param.aspx";
        private const string HTTP_PREFIX = "http://";
        private const string HTTPS_PREFIX = "https://";
        internal readonly static string TaskFolder;
        private const string KSpider_Path = "KSpiderSaved\\";

        static InteropPlus()
        {

            if (Directory.Exists(KConfig.SpiderPool))
            {
                TaskFolder = KConfig.SpiderPool;
                return;
            }

            List<string> fixedDisk = new List<string>();
            DriveInfo[] drivers = DriveInfo.GetDrives();

            foreach (DriveInfo driver in drivers)
            {
                if (driver.DriveType == DriveType.Fixed)
                    fixedDisk.Add(driver.Name);
            }

            TaskFolder = fixedDisk.Count == 1 ? fixedDisk[0] + KSpider_Path : fixedDisk[1] + KSpider_Path;
            KConfig.SpiderPool = TaskFolder;
        }

        internal static void Redirect(   string  url)
        {
            try
            {
                Process.Start(url);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        internal static void Redirect(ref TextBox url)
        {
          Process.Start(url.Text);
        }
        internal static void BindFolder(ref TextBox t)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() != DialogResult.OK)
                    return;

                t.Text = folder.SelectedPath;
            }
        }

        //线程调用
        public static void Send(object o)
        {
            try
            {
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                    return;
                TaskInfo crawlerInfo = o as TaskInfo;
                WebClient webClient = new WebClient();
                NameValueCollection VarPost = new NameValueCollection();

                VarPost.Add("type", "CrawlerTask");
                VarPost.Add("ComputerName", SystemInformation.ComputerName);
                VarPost.Add("taskname", crawlerInfo.TaskName);
                VarPost.Add("EntranceURL", crawlerInfo.EntranceURL);
                VarPost.Add("IsInternal", crawlerInfo.IsInternal.ToString());
                VarPost.Add("urlkeywords", crawlerInfo.UrlKeywordText);
                VarPost.Add("keywords", crawlerInfo.HtmlKeywordText);
                VarPost.Add("Category", crawlerInfo.Category);


                byte[] byRemoteInfo = webClient.UploadValues(requestPage, "POST", VarPost);

                string result = System.Text.Encoding.UTF8.GetString(byRemoteInfo);
            }
            catch (Exception e)
            {
                Log("[VarPostSend]"+e.Message);
            }
        }

        internal static void Log(string log)
        {
            const string Error_Log = "error.log";
            if (!File.Exists(Error_Log))
                File.Create(Error_Log);
            //日志
            using (StreamWriter writer = new StreamWriter(new FileStream(Error_Log, FileMode.OpenOrCreate)))
            {
                writer.WriteLine(String.Format(CK.BracketsAndInfo, DateTime.Now.ToString(), log));
            }
        }

        #region javascript 调用发送留言
        protected void postMessage(string userName, string message)
        {

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("请输入署名");
                return;
            }

            if (message.Length < 10)
            {
                MessageBox.Show("提交信息必须超过10个字符");
                return;
            }
            string postResult = InteropPlus.PostMessage(userName, message);

            MessageBox.Show(postResult);
        }

        public int addJsonTask(string jsonTask)
        {
            var d = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonTask);
            TaskInfo ti = new TaskInfo();
            ti.EntranceURL = d["EntranceURL"];

            if (!Uri.IsWellFormedUriString(ti.EntranceURL, UriKind.Absolute))
            {
                ti.EntranceURL = Uri.UriSchemeHttp + Uri.SchemeDelimiter+ ti.EntranceURL;
                if (!Uri.IsWellFormedUriString(ti.EntranceURL, UriKind.Absolute))
                {
                    MessageBox.Show(R.Empty_Url, ti.Description, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
            }

            ti.Category = d["Category"];
            ti.Description = d["Desc"];

            if (ti.Category.ToLower() == "jpg")
                ti.MinFileSize = KConfig.GetMinKB(ti.Category, 50);
            else
                ti.MinFileSize = KConfig.GetMinKB(ti.Category);

            Uri u = new Uri(ti.EntranceURL);
            ti.TaskName = String.Format(CK.BraceAndInfo, ti.Domain, ti.Description);
            ti.ThreadCount = 5;
            ti.ThreadSleepTimeWhenQueueIsEmpty = 2;
            ti.ConnectionTimeout = 40;
            ti.DownloadFolder = TaskFolder + ti.TaskName;
            ti.IsInternal = true;
            ti.IsAddUkey = true;
            ti.IsFilterAllMime = true;
            ti.NotSave = false;
            ti.Unicode = String.Empty;
            ti.IsPreference = false;
            ti.ID = TaskDao.AddTask(ti);
            PreferenceDao.UpdatePreference(ti);
            Cache.ClearTaskList();
            return ti.ID;
        }

        public static string PostMessage(string userName, string message)
        {
            WebClient webClient = new WebClient();
            NameValueCollection VarPost = new NameValueCollection();

            VarPost.Add("type", "clientmessage");
            VarPost.Add("username", userName);
            VarPost.Add("category", "crawler");
            VarPost.Add("message", message);

            byte[] byRemoteInfo = webClient.UploadValues(requestPage, "POST", VarPost);
            string remoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);

            return remoteInfo;
        }
        #endregion
    }
}
