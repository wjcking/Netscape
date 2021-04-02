
namespace KCrawler
{
    using System.Collections.Generic;
    using System;
    using System.IO;
    using System.Threading;
    using System.Text;
    using System.Xml;

    public delegate void DownloaderStatusChangedEventHandler(object sender, DownloaderStatusChangedEventArgs e);
    public class DownloaderStatusChangedEventArgs : EventArgs
    {

    }

    public partial class Downloader
    {
        public event DownloaderStatusChangedEventHandler StatusChanged;

        //初始化后调用
        private string Path_CacheQueue = "CacheQueue";
        private string Path_CrawledUrl = "CrawlerUrl";
        private string Path_FilePool = "FilePool";
        private string Path_Bloom = "Bloom";
        private string Path_Log = "a";

        public List<string> FileTypes = new List<string>();
        private CrawlerThread[] crawlerThreads;
        private DownloaderStatus systemStatus = DownloaderStatus.Stopped;
        public string BaseEntranceUrl;
        //写日志
        public Logger Logger { get; set; }
        // 为了避免重复下载或陷入爬虫陷阱， 只有未被访问的URL才会被加入到队列中去
        public List<string> CrawledUrls { get; private set; }
        public UrlFrontierQueueManager UrlsQueueFrontier { get; set; }
        public TaskInfo CrawlerInfo { get; set; }
        //布隆过滤器
        internal SimpleBloomFilter BloomFilter { get; private set; }
        public long SavedCount { get; set; }
        //下载文件
        public List<string> FilePool { get; set; }
        public Thread InnerThread { get; private set; }


        public CrawlerThread[] ThreadCrawlers
        {
            get
            {
                return crawlerThreads;
            }
        }

        //初始化一个下载爬虫则相当于获取或建立一个ini section
        //打开保存的数据url
        public Downloader(int taskID)
        {
            CrawlerInfo = TaskCache.GetTaskInfo(taskID);
            CrawlerInfo.IsLunched = true;
            SavedCount = 1;
            Logger = new Logger();
            systemStatus = DownloaderStatus.Stopped;
            if (FilePool == null)
                FilePool = new List<string>();
            Path_CrawledUrl = Path.Combine(CrawlerInfo.DownloadFolder, CrawlerInfo.TaskID + "-CrawlerUrl.sav");
            Path_FilePool = Path.Combine(CrawlerInfo.DownloadFolder, CrawlerInfo.TaskID + "-FilePool.sav");
            Path_CacheQueue = Path.Combine(CrawlerInfo.DownloadFolder, CrawlerInfo.TaskID + "-Queue.sav");
            Path_Bloom = Path.Combine(CrawlerInfo.DownloadFolder, CrawlerInfo.TaskID + "-Bloom.sav");
            Path_Log = Path.Combine(CrawlerInfo.DownloadFolder, CrawlerInfo.TaskID + "-Log.sav");

        }
        //用于提取内容
        public Downloader()
        {
            CrawlerInfo = new TaskInfo();
        }
        /// <summary>
        /// 刷新配置信息
        /// </summary>
        public void RefreshTaskInfo()
        {
            if (CrawlerInfo == null)
                return;
            CrawlerInfo = TaskCache.GetTaskInfo(CrawlerInfo.ID);
        }
        //公开方法，用于dump
        public void Restore()
        {
            try
            {
                //队列
                object o = SerialUnit.Open(Path_CacheQueue);
                if (o != null)
                    UrlsQueueFrontier = o as UrlFrontierQueueManager;
                else
                    UrlsQueueFrontier = new UrlFrontierQueueManager();
                //如果队列里面没有url则重新开始，就算是爬虫地址或布隆过滤器已经存在
                if (UrlsQueueFrontier.Count == 0)
                    Clear();
                o = SerialUnit.Open(Path_CrawledUrl);
                if (o != null)
                    CrawledUrls = o as List<string>;

                else
                    CrawledUrls = new List<string>();
                //压缩文件 
                o = SerialUnit.Open(Path_FilePool);
                if (o != null)
                    FilePool = o as List<string>;
                else
                    FilePool = new List<string>();

                o = SerialUnit.Open(Path_Bloom);
                //布隆过滤器
                if (o != null)
                    BloomFilter = o as SimpleBloomFilter;
                else
                    BloomFilter = new SimpleBloomFilter();
                o = SerialUnit.Open(Path_Log);
                //日志
                if (o != null && o is List<LogInfo>)
                {
                    Logger.Log = o as List<LogInfo>;
                    SavedCount = Logger.GetCount(LogLevel.Saved);
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }

        }
        // 通常爬虫是从一系列种子(Seed)网页开始,然后使用这些网页中的链接去获取其他页面.
        public void InitSeeds(string[] seeds)
        {
            if (UrlsQueueFrontier == null)
                return;
            // 使用种子URL进行队列初始化
            if (UrlsQueueFrontier.Count > 0)
                return;
            foreach (string s in seeds)
                UrlsQueueFrontier.Enqueue(s);
        }
        public void Start()
        {

            //初始化，resume和abort刷新
            BaseEntranceUrl = CrawlerInfo.Domain;

            if (systemStatus == DownloaderStatus.Running)
                return;
            if (systemStatus == DownloaderStatus.Paused)
            {
                Resume();
                return;
            }
            //还原文件文件
            Restore();
            //起始种子地址

            InitSeeds(new string[] { CrawlerInfo.EntranceURL });
            crawlerThreads = new CrawlerThread[CrawlerInfo.ThreadCount];
            systemStatus = DownloaderStatus.Running;

            for (int i = 0; i < crawlerThreads.Length; i++)
            {
                CrawlerThread crawler = new CrawlerThread(this);
                crawler.Name = i.ToString();
                crawler.StatusChanged += new CrawlerStatusChangedEventHandler(CrawlerStatusChanged);
                crawler.Start();

                crawlerThreads[i] = crawler;
            }
        }
        /// <summary>
        /// 如果队列为空并且线程都在睡眠则为停止，另外在线程控制函数中操作
        /// </summary>
        public DownloaderStatus Status
        {
            get
            {
                if (null == UrlsQueueFrontier)
                    return DownloaderStatus.Stopped;

                if (systemStatus == DownloaderStatus.Running)
                {
                    if (UrlsQueueFrontier.Count > 0)
                        return DownloaderStatus.Running;

                    foreach (CrawlerThread ct in crawlerThreads)
                    {
                        if (ct.CThread.ThreadState != ThreadState.WaitSleepJoin)
                            return DownloaderStatus.Running;

                        systemStatus = DownloaderStatus.Stopped;
                        Dump("Done");
                        WriteXmlFile();
                        ClearXmlApplender();
                        // 队列为空并且都waitsleepjoin
                        Abort();
                        return DownloaderStatus.Stopped;
                    }
                }

                return systemStatus;
            }
        }
        //状态文字输出
        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case DownloaderStatus.Stopped:
                        return R.DownloaderStatus_Stopped;
                    case DownloaderStatus.Paused:
                        return R.DownloaderStatus_Pause;
                    case DownloaderStatus.Running:
                        return R.DownloaderStatus_Running;
                }
                return systemStatus.ToString();

            }
        }


    }
}
