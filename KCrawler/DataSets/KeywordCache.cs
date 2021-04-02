using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KCrawler
{
    public class KeywordCache : Cache
    {
        public const string CachePrefix = "KeywordCache";
         
        public static List<UrlKeywordInfo> GetUrlKeywordList(int taskID)
        {
            lock (KCache.SyncRoot)
            {
                string cacheName = CachePrefix + "GetUrlKeywordList" + taskID.ToString();

                if (KCache.ContainsKey(cacheName))
                    return KCache[cacheName] as List<UrlKeywordInfo>;
                else
                {
                    var list = KeywordDao.GetUrlKeywordList(taskID);
                    KCache.Add(cacheName, list);
                    return list;
                }
            }
        }

        public static List<HtmlKeywordInfo> GetHtmlKeywordList(int taskID)
        {
            lock (KCache.SyncRoot)
            {
                string cacheName = CachePrefix + "GetHtmlKeywordList" + taskID.ToString();

                if (KCache.ContainsKey(cacheName))
                    return KCache[cacheName] as List<HtmlKeywordInfo>;
                else
                {
                    var list = KeywordDao.GetHtmlKeywordList(taskID);
                    KCache.Add(cacheName, list);
                    return list;
                }
            }
        }
    }
}
