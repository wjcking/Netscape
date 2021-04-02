using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KCrawler
{
    public class Cache
    {
        public readonly static Hashtable KCache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 清空缓存
        /// </summary>
        public static void Clear(string cachePrefix)
        {
            if (string.IsNullOrEmpty(cachePrefix))
                KCache.Clear();

            string key = null;
            IDictionaryEnumerator enumerator = KCache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().IndexOf(cachePrefix) > -1)
                {
                    key = enumerator.Key.ToString();
                    break;
                }
            }
            if (null != key)
                KCache.Remove(key);
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public static void Clear()
        {
            Clear(String.Empty);
        }

        public static void ClearTaskList()
        {
            Clear(TaskCache.C_TaskList);
        }

        public static void ClearTaskInfo(int taskid)
        {
            Clear(TaskCache.CachePrefix + "GetTaskInfo" + taskid.ToString());
        }

    }
}
