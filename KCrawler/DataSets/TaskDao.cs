using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KCrawler
{

    public class TaskDao
    {
        private readonly static AccessHelper db = new AccessHelper();

        private static int LastTaskID
        {
            get
            {
                return Convert.ToInt32(db.ExecuteScalar("SELECT  max(ID) FROM [task]  "));
            }
        }
        /// <summary>
        /// 返回task id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int AddTask(TaskInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Task(");
            strSql.Append("TaskName,NotSave,Unicode,DownloadFolder,IsInternal,EntranceURL,ThreadCount,ConnectionTimeout,ThreadSleepTimeWhenQueueIsEmpty,MinFileSize,Description,IsPreference)");

            strSql.Append(" values (");
            strSql.Append("@TaskName,@NotSave,@Unicode,@DownloadFolder,@IsInternal,@EntranceURL,@ThreadCount,@ConnectionTimeout,@ThreadSleepTimeWhenQueueIsEmpty,@MinFileSize,@Description,@IsPreference)");

            db.AddInParameter("TaskName", DbType.AnsiString, model.TaskName);
            db.AddInParameter("NotSave", DbType.Boolean, model.NotSave);
            db.AddInParameter("Unicode", DbType.AnsiString, model.Unicode);
            db.AddInParameter("DownloadFolder", DbType.AnsiString, model.DownloadFolder);
            db.AddInParameter("IsInternal", DbType.Boolean, model.IsInternal);
            db.AddInParameter("EntranceURL", DbType.AnsiString, model.EntranceURL);
            db.AddInParameter("ThreadCount", DbType.String, model.ThreadCount);
            db.AddInParameter("ConnectionTimeout", DbType.String, model.ConnectionTimeout);
            db.AddInParameter("ThreadSleepTimeWhenQueueIsEmpty", DbType.String, model.ThreadSleepTimeWhenQueueIsEmpty);
            db.AddInParameter("MinFileSize", DbType.Int32, model.MinFileSize);
            db.AddInParameter("Description", DbType.AnsiString, model.Description); 
            db.AddInParameter("IsPreference", DbType.Boolean, model.IsPreference);

            db.ExecuteNonQuery(strSql.ToString());
            model.ID = LastTaskID;
            //事先设置的全部更新
            UpdateTaskID(model.ID);
            return model.ID;
        }
        /// <summary>
        /// 更新任务 acrawler
        /// </summary>
        public static bool UpdateTask(TaskInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Task set ");
            strSql.Append("TaskName=@TaskName,");
            strSql.Append("NotSave=@NotSave,");
            strSql.Append("Unicode=@Unicode,");
            strSql.Append("DownloadFolder=@DownloadFolder,");
            strSql.Append("IsInternal=@IsInternal,");
            strSql.Append("EntranceURL=@EntranceURL,");
            strSql.Append("ThreadCount=@ThreadCount,");
            strSql.Append("ConnectionTimeout=@ConnectionTimeout,");
            strSql.Append("ThreadSleepTimeWhenQueueIsEmpty=@ThreadSleepTimeWhenQueueIsEmpty,");
            strSql.Append("MinFileSize=@MinFileSize,");
            strSql.Append("Description=@Description,");
            strSql.Append("IsPreference=@IsPreference,");
            strSql.Append("[CreateTime]=@CreateTime ");
            strSql.Append(" where ID=@ID ");

            db.AddInParameter("TaskName", DbType.AnsiString, model.TaskName);
            db.AddInParameter("NotSave", DbType.Boolean, model.NotSave);
            db.AddInParameter("Unicode", DbType.AnsiString, model.Unicode);
            db.AddInParameter("DownloadFolder", DbType.AnsiString, model.DownloadFolder);
            db.AddInParameter("IsInternal", DbType.Boolean, model.IsInternal);
            db.AddInParameter("EntranceURL", DbType.AnsiString, model.EntranceURL);
            db.AddInParameter("ThreadCount", DbType.String, model.ThreadCount);
            db.AddInParameter("ConnectionTimeout", DbType.String, model.ConnectionTimeout);
            db.AddInParameter("ThreadSleepTimeWhenQueueIsEmpty", DbType.String, model.ThreadSleepTimeWhenQueueIsEmpty);
            db.AddInParameter("MinFileSize", DbType.Int32, model.MinFileSize);        
            db.AddInParameter("Description", DbType.AnsiString, model.Description);
            db.AddInParameter("IsPreference", DbType.Boolean, model.IsPreference);
            db.AddInParameter("CreateTime", DbType.AnsiString, DateTime.Now);
            db.AddInParameter("ID", DbType.Int32, model.ID);
            int rows = db.ExecuteNonQuery(strSql.ToString());

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void AddTaskViaPreference(int taskID)
        {
            //1 插入task
            StringBuilder sql = new StringBuilder();
            sql.Append("    INSERT INTO Task (   [TaskName] ,  [NotSave] ,  [Unicode] , [DownloadFolder] ,  [IsInternal] ,   [EntranceURL] , ");
            sql.Append("    [ThreadCount] ,  [ConnectionTimeout] , [ThreadSleepTimeWhenQueueIsEmpty] , [MinFileSize] ,   [Description] ,  [IsPreference] )  ");

            sql.Append("      SELECT     [TaskName] ,  [NotSave] ,  [Unicode] ,   [DownloadFolder] ,   [IsInternal] ,  [EntranceURL] , ");
            sql.Append("      [ThreadCount] ,    [ConnectionTimeout] , [ThreadSleepTimeWhenQueueIsEmpty] , [MinFileSize] ,  [Description] ,  false ");
            sql.Append("       From [task] ");
            sql.Append("      WHERE IsPreference =true and id= ").Append(taskID);
            db.ExecuteNonQuery(sql.ToString());
            //2 获取新增taskid
            int newID = LastTaskID;
            //3 增加优先级
            sql.Remove(0, sql.Length);
            sql.Append("         INSERT INTO [Priority] ( TaskID, MimeID ) ");
            sql.Append("           SELECT {0} , MimeID FROM Priority WHERE TaskID={1}; ", newID, taskID);
            db.ExecuteNonQuery(sql.ToString());
            //4 添加过滤
            sql.Remove(0, sql.Length);
            sql.Append("         INSERT INTO [Filter] ( TaskID, MimeID ) ");
            sql.Append("           SELECT {0} , MimeID FROM Filter WHERE TaskID={1}; ", newID, taskID);
            db.ExecuteNonQuery(sql.ToString());

        }


        public static void DeleteTask(bool isDeleteTaskInfo, int taskID)
        {
            string sql = " DELETE * FROM Task WHERE ID= " + taskID.ToString();
            if (isDeleteTaskInfo)
                db.ExecuteNonQuery(sql);
            sql = "  DELETE * FROM Priority WHERE TaskID= " + taskID.ToString();
            db.ExecuteNonQuery(sql);
            sql = "  DELETE * FROM Filter WHERE TaskID= " + taskID.ToString();
            db.ExecuteNonQuery(sql);
            sql = "  DELETE * FROM HtmlKeyword WHERE TaskID= " + taskID.ToString();
            db.ExecuteNonQuery(sql);
            sql = "  DELETE * FROM UrlKeyword WHERE TaskID= " + taskID.ToString();
            db.ExecuteNonQuery(sql);
            sql = "  DELETE * FROM [Cookies] WHERE TaskID= " + taskID.ToString();
            db.ExecuteNonQuery(sql);
            sql = "  DELETE * FROM [Extract] WHERE TaskID= " + taskID.ToString();
            db.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 新建爬虫，未确定则更新0
        /// </summary>
        /// <param name="taskID"></param>
        public static void DeleteTask(int taskID)
        {
            DeleteTask(true, taskID);
        }
        /// <summary>
        /// 新建任务或修改任务后更新
        /// </summary>
        /// <param name="taskid"></param>
        public static void UpdateTaskID( int taskid )
        {
            const string sql = " UPDATE [{0}] SET TaskID = {1} WHERE TaskID= 0 ";
            db.ExecuteNonQuery(string.Format(sql,"Priority",taskid));
            db.ExecuteNonQuery(string.Format(sql, "Filter", taskid));
            db.ExecuteNonQuery(string.Format(sql, "HtmlKeyword", taskid));
            db.ExecuteNonQuery(string.Format(sql, "UrlKeyword", taskid));
            db.ExecuteNonQuery(string.Format(sql, "Cookies", taskid));
            db.ExecuteNonQuery(string.Format(sql, "Extract", taskid));
        }
        public static List<TaskInfo> GetPreferenceList()
        {
            const string sql = "SELECT * FROM Task WHERE IsPreference =true ORDER BY CreateTime DESC ";

            var list = new List<TaskInfo>();
            using (IDataReader dataReader = db.ExecuteReader(sql))
            {
                while (dataReader.Read())
                {
                    TaskInfo ti = ReaderBind(dataReader);
                    list.Add(ti);
                }
            }

            return list;
        }

   
        public static List<TaskInfo> GetTaskList()
        {
            const string sql = "SELECT * FROM Task WHERE IsPreference =false ORDER BY CreateTime DESC ";

            var list = new List<TaskInfo>();
            using (IDataReader dataReader = db.ExecuteReader(sql))
            {
           
                while (dataReader.Read())
                {
                    TaskInfo ti = ReaderBind(dataReader);
       
                    list.Add(ti);
                }
            }

            return list;
        }
        public static TaskInfo GetTaskInfo(int id)
        {
            string sql = "SELECT TOP 1 * FROM Task WHERE  ID= " + id.ToString();
            TaskInfo ti = new TaskInfo();
            using (IDataReader dataReader = db.ExecuteReader(sql))
            {
                if (dataReader.Read())
                {
                    ti = ReaderBind(dataReader);
                }
            }
            ti.HtmlKeyword = KeywordDao.GetHtmlKeywordList(id);
            ti.UrlKeyword = KeywordDao.GetUrlKeywordList(id);
            ti.CookieList = KeywordDao.GetCookieList(id);
            ti.Filter = PriorityFilterDao.GetFilter(id);
            ti.Priority = PriorityFilterDao.GetPriority(id);
            ti.ExtractOptionList = ExtractDao.GetOptionList(id);
            return ti;
        }

        private static TaskInfo ReaderBind(IDataReader dataReader)
        {
            TaskInfo model = new TaskInfo();
            object ojb;
            model.TaskName = dataReader["TaskName"].ToString();
            ojb = dataReader["NotSave"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.NotSave = (bool)ojb;
            }
            model.Unicode = dataReader["Unicode"].ToString();
            model.DownloadFolder = dataReader["DownloadFolder"].ToString();
            ojb = dataReader["IsInternal"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsInternal = (bool)ojb;
            }
            model.EntranceURL = dataReader["EntranceURL"].ToString();
            model.ThreadCount = Convert.ToInt32(dataReader["ThreadCount"]);
            model.ConnectionTimeout = Convert.ToInt32(dataReader["ConnectionTimeout"]);
            model.ThreadSleepTimeWhenQueueIsEmpty = Convert.ToInt32(dataReader["ThreadSleepTimeWhenQueueIsEmpty"]);
            model.MinFileSize = Convert.ToInt32(dataReader["MinFileSize"]);
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (int)ojb;
            }
            model.Description = dataReader["Description"].ToString();
            ojb = dataReader["IsPreference"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsPreference = (bool)ojb;
            }
            model.Category = dataReader["Category"].ToString();
            return model;
        }

        public static void UpdateCategory(int taskid, string category)
        {          
            string sql =string.Format("UPDATE [Task] SET [Category]='{0}' WHERE ID={1}", category, taskid);
            db.ExecuteNonQuery(sql.ToString());      
        }
    }
}
