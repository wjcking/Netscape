using System;
using System.Collections.Generic;
using System.Text;

namespace KCrawler
{
 
      
    public enum LogLevel
    {
        Saved = 0,
        Fatal = 1,
        Error = 2,
        Warn = 4,
        Info = 8,
        Debug = 16,
        Trace = 32,
    }
    public enum FrontierQueuePriority : short
    {
        Low = 1,
        BelowNormal = 2,
        Normal = 3,
        AboveNormal = 4,
        High = 5,
    }
    public enum CrawlerStatusType :short
    {
        Sleep = 0,
        Fetch =1,  // FetchWebContent
        Parse=2,  // ParseWebPage
        Save=3,   // SaveToRepository
    }
    public enum DownloaderStatus : short
    {
        Stopped =0,
        Running =1,
        Paused =2
    }
    public enum CrawlerStatusChangedEventType
    {

    }
 
    public delegate void CrawlerStatusChangedEventHandler(object sender, CrawlerStatusChangedEventArgs e);
    public class CrawlerStatusChangedEventArgs : EventArgs
    {
        public CrawlerStatusChangedEventType EventType
        {
            get;
            set;
        }
    }
}
