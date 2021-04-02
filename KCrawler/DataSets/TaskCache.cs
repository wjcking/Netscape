using System.Collections.Generic;

namespace KCrawler
{
    public class TaskCache : Cache
    {
        public const string CachePrefix = "TaskCache";
        public const string C_TaskList = CachePrefix + "GetTaskList";

         public static List<TaskInfo> GetTaskList()
        {
            lock (KCache.SyncRoot)
            {
                string cacheName = CachePrefix + "GetTaskList";

                if (KCache.ContainsKey(cacheName))
                    return KCache[cacheName] as List<TaskInfo>;
                else
                {
                    List<TaskInfo> t = TaskDao.GetTaskList();
                    KCache.Add(C_TaskList, t);
                    return t;
                }
            }
        }

        public static int Count
         {
             get
             {
                 return GetTaskList().Count;
             }
         }
        public static TaskInfo GetTaskInfo(int id)
        {
            lock (KCache.SyncRoot)
            {
                string cacheName = CachePrefix + "GetTaskInfo" + id.ToString();

                if (KCache.ContainsKey(cacheName))
                    return KCache[cacheName] as TaskInfo;
                else
                {
                    TaskInfo taskInfo = TaskDao.GetTaskInfo(id);
                    KCache.Add(cacheName, taskInfo);
                    return taskInfo;
                }
            }
           
        }
        public static List<FilterInfo> GetFilter(int taskID)
        {
            lock (KCache.SyncRoot)
            {
                string cacheName = "GetFilter" + taskID;

                if (KCache.ContainsKey(cacheName))
                    return KCache[cacheName] as List<FilterInfo>;
                else
                {
                    var dt = PriorityFilterDao.GetFilter(taskID);
                    KCache.Add(cacheName, dt);
                    return dt;
                }
            }
        }

        
    }
}
