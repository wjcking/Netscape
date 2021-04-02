
namespace KCrawler
{
    using System.Threading;
    using System;

    public partial class CrawlerThread
    {
        public event CrawlerStatusChangedEventHandler StatusChanged;
        public ManualResetEvent manualEvent = new ManualResetEvent(true);

        private Thread cthread;
        public CrawlerThread(Downloader d)
        {
            cthread = new Thread(DoWork);
            this.Downloader = d;

        }

        private string mimeType;

        public string MimeType
        {
            get { return mimeType; }
            set { mimeType = value; }
        }


        /// <summary>
        /// 当前线程消息用于判断状态
        /// </summary>
        public Thread CThread
        {
            get
            {

                return cthread;
            }
        }
        public string Name
        {
            get;
            set;
        }

        public CrawlerStatusType Status
        {
            get;
            private set;
        }

        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case CrawlerStatusType.Fetch:
                        return R.CrawlerStatusType_Fetch;
                    case CrawlerStatusType.Parse:
                        return R.CrawlerStatusType_Parse;
                    case CrawlerStatusType.Save:
                        return R.CrawlerStatusType_Save;
                    case CrawlerStatusType.Sleep:
                        return R.CrawlerStatusType_Sleep;
                }

                return Status.ToString();
            }
        }
        public string Url
        {
            get;
            set;
        }

        private Downloader Downloader
        {
            get;
            set;
        }

        internal void Start()
        {
            cthread.Start();
        }

        internal void Abort()
        {
            //清空excel配置文件哈希表缓存

            cthread.Abort();
        }

        internal void Suspend()
        {
            if (cthread.IsAlive)
                manualEvent.Reset();
        }

        internal void Resume()
        {
            if (cthread.IsAlive)
                manualEvent.Set();
        }

        public void DoWork()
        {
            try
            {

                if (null == Downloader.UrlsQueueFrontier)
                    return;

                while (true)
                {
     
                    if (Downloader.UrlsQueueFrontier.Count > 0)
                    {
                        try
                        {
                            //加休眠缓和cpu
                            manualEvent.WaitOne(-1);
                            // 从队列中获取URL
                            string url = (string)Downloader.UrlsQueueFrontier.Dequeue();
                            // 获取页面
                            //如果不保存文件则直接添加到url列表,
                            if (!Utility.IsGoodUri(ref url))
                                continue;

                            Fetch(url);
                            Thread.Sleep(50);
                        }
                        catch (InvalidOperationException ioe)
                        {
                            SleepWhenQueueIsEmpty();
                            Downloader.Logger.Error(ioe.Message);
                        }
                    }
                    else
                    {
                        SleepWhenQueueIsEmpty();
                    }


                }
            }
            catch (ThreadAbortException tae)
            { 
                Downloader.Logger.Error(tae.Message);
            }
        }


        // 为避免挤占CPU, 队列为空时睡觉. 
        private void SleepWhenQueueIsEmpty()
        {
            Status = CrawlerStatusType.Sleep;
            Url = string.Empty;
            StatusChanged(this, null);
            Thread.Sleep(Downloader.CrawlerInfo.ThreadSleepTimeWhenQueueIsEmpty * 1000);
        }


    }

}
