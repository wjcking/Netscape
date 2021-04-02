using System;

namespace KCrawler
{
    public class CrawleHistroyEntry
    {
        public string Url { get; set; }
        public DateTime Timestamp { get; set; } // 时间戳  
        public long Size { get; set; }
    }
}
