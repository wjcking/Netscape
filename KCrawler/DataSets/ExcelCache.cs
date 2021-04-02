using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KCrawler
{
    public class ExcelCache
    {

        //public const string CachePrefix = "";
        private const string Cache_FileTypeMime = "FileTypeMime";
        public readonly static Hashtable Cache = Hashtable.Synchronized(new Hashtable());
        private const string cacheName = "Unicode";

        public static List<string> Unicode
        {
            get
            {
                if (Cache.ContainsKey(cacheName))
                    return Cache[cacheName] as List<string>;
                else
                {

                    Cache.Add(cacheName, ExcelDao.Unicode);
                    return ExcelDao.Unicode;
                }
            }
        }

        public static List<FilterInfo> GetFilter(string taskID)
        {
            lock (Cache.SyncRoot)
            {
                string cacheName = "GetFilter" + taskID;

                if (Cache.ContainsKey(cacheName))
                    return Cache[cacheName] as List<FilterInfo>;
                else
                {
                    List<FilterInfo> list = ExcelDao.GetFilter(taskID);
                    Cache.Add(cacheName, list);
                    return list;
                }
            }
        }

        public static List<PriorityInfo> GetPriority(string taskID)
        {
            lock (Cache.SyncRoot)
            {
                string cacheName = "GetPriority" + taskID;

                if (Cache.ContainsKey(cacheName))
                    return Cache[cacheName] as List<PriorityInfo>;
                else
                {
                    List<PriorityInfo> list = ExcelDao.GetPriority(taskID);
                    Cache.Add(cacheName, list);
                    return list;
                }
            }
        }

        private static List<MimeInfo> FileTypeMime
        {
            get
            {
                lock (Cache.SyncRoot)
                {
                    if (Cache.ContainsKey(Cache_FileTypeMime))
                        return Cache[Cache_FileTypeMime] as List<MimeInfo>;
                    else
                    {
                        Cache.Add(Cache_FileTypeMime, ExcelDao.FileTypeMime);
                        return Cache[Cache_FileTypeMime] as List<MimeInfo>;
                    }
                }
            }
        }

        public static bool IsFileTypeViaExt(string mimeExt)
        {

            return FileTypeMime.Exists(delegate(MimeInfo mi)
            {

                return mimeExt.ToLower() == mi.Extension;
            });
        }
        public static bool IsFileTypeViaMime(string mime)
        {
            return FileTypeMime.Exists(delegate(MimeInfo mi)
            {
                return mime.ToLower().StartsWith(mi.Mime);
            });
        }
    }
}
