using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace KCrawler
{
    public class ClientRequest
    {
        private const double KBCount = 1024;
        private const double MBCount = KBCount * 1024;
        private const double GBCount = MBCount * 1024;
        private const double TBCount = GBCount * 1024;


   //     private string taskID;
        public List<DownloadInfo> FilePool { get; set; }
        private WebClient client = null;

        public ClientRequest()
        {
            //         this.taskID = taskID;
            FilePool = new List<DownloadInfo>();
            client = new WebClient();
        }
        public void AddUrl(DownloadInfo d)
        {
            if (d.Uri == null)
                return;
            client.DownloadFileAsync(d.Uri, d.SavePath + d.FileName, d);
            //client.DownloadFileCompleted += client_DownloadFileCompleted;
            //client.DownloadProgressChanged += client_DownloadProgressChanged;
        //    FilePool.Add(d);
         //   ThreadPool.QueueUserWorkItem(ToString());
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            DownloadInfo d = (DownloadInfo)e.UserState;
            d.Progress = e.ProgressPercentage + "%";
            double secondCount = (DateTime.Now - d.StartTime).TotalSeconds;
            d.Speed = GetAutoSizeString(Convert.ToDouble(e.BytesReceived / secondCount), 2) + "/s";

        }

        private void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
           
            DownloadInfo d = (DownloadInfo)e.UserState;
            FilePool.Remove(d);
        }

        /// <summary>
        /// 得到适应大小
        /// </summary>
        /// <param name="size">字节大小</param>
        /// <param name="roundCount">保留小数(位)</param>
        /// <returns></returns>
        public static string GetAutoSizeString(double size, int roundCount)
        {
            if (KBCount > size)
                return Math.Round(size, roundCount) + "B";
            else if (MBCount > size)
                return Math.Round(size / KBCount, roundCount) + "KB";
            else if (GBCount > size)
                return Math.Round(size / MBCount, roundCount) + "MB";
            else if (TBCount > size)
                return Math.Round(size / GBCount, roundCount) + "GB";
            else
                return Math.Round(size / TBCount, roundCount) + "TB";
        }


    }
}
