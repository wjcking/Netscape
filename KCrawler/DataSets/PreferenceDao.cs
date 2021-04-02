using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KCrawler
{
    public class PreferenceDao
    {
        private readonly static AccessHelper db = new AccessHelper();

    
        public static List<MCateInfo> GetMimeCategoryList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Category,Desc,DescEn,OrderNumber ");
            strSql.Append(" FROM MCate ORDER BY OrderNumber");
            var list = new List<MCateInfo>();
            //默认
            list.Add(new MCateInfo { Category = string.Empty, Desc = R.MCate_Default, OrderNumber = 0 });
            using (IDataReader dataReader = db.ExecuteReader(strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(MCateReaderBind(dataReader));
                }
            }
            return list;
        }


        static MCateInfo MCateReaderBind(IDataReader dataReader)
        {
            var model = new MCateInfo();
            model.Category = dataReader["Category"].ToString();
            model.Desc = dataReader["Desc"].ToString();
            model.DescEn = dataReader["DescEn"].ToString();
            model.OrderNumber = Convert.ToInt16(dataReader["OrderNumber"]);

            return model;
        }

        /// <summary>
        /// 更新个人喜好到优先级 urkeyword中的 Kname=category
        /// </summary>
        public static void UpdatePreference(TaskInfo ti)
        {

            StringBuilder sql = new StringBuilder();
            //重置优先级
            sql.Append("DELETE * FROM Priority WHERE Taskid=").Append(ti.ID);
            db.ExecuteNonQuery(sql.ToString());   
            //添加优先级
                sql.Remove(0, sql.Length);
                sql.AppendFormat("INSERT INTO {0} (MimeID,TaskID,Priority) ", C.T_Priority);
                sql.AppendFormat("SELECT ID,{0},5 FROM Mime WHERE Category = '{1}'", ti.ID, ti.Category);
                sql.Append("");
                db.ExecuteNonQuery(sql.ToString());
            //关键字
         
            if (ti.IsAddUkey)
            {   
                sql.Remove(0, sql.Length);
                sql.AppendFormat("DELETE * FROM UrlKeyword WHERE KName IN ({0}) AND TaskID={1}  ", PFCache.MCateString, ti.ID);
                db.ExecuteNonQuery(sql.ToString());
         
                //添加扩展名到keywords
                sql.Remove(0, sql.Length);
                sql.Append("INSERT INTO UrlKeyword (KName,Keywords,TaskID) ");
                sql.AppendFormat("SELECT '{0}',Extension, {1} FROM Mime WHERE Category = '{2}'", ti.Category, ti.ID, ti.Category); 
                db.ExecuteNonQuery(sql.ToString());

                //如果是文件类型则添加非http协议关键字
                if (ti.Category == "File")
                {
                    sql.Remove(0, sql.Length);
                    sql.Append("INSERT INTO UrlKeyword (KName,Keywords,TaskID) ");
                    sql.AppendFormat("SELECT '{0}',[Prefix], {1} FROM  [Protocol]", ti.Category, ti.ID, ti.Category);
                    db.ExecuteNonQuery(sql.ToString());
                }
            }
            //domain插入添加主域名到urlkeyword
            if (ti.IsInternal)
            {
                sql.Remove(0, sql.Length);
                sql.AppendFormat("SELECT count(keywords)  FROM  UrlKeyword WHERE Keywords = '{0}' AND TaskID={1}", ti.Domain, ti.ID);
                object o = db.ExecuteScalar(sql.ToString());

                if (Convert.ToInt16(o) == 0)
                {
                    sql.Remove(0, sql.Length);
                    sql.AppendFormat("INSERT INTO UrlKeyword (KName,Keywords,TaskID) VALUES('Domain','{0}','{1}') ", ti.Domain, ti.ID);
                    db.ExecuteNonQuery(sql.ToString());
                }
            }
            else
            {
                sql.Remove(0, sql.Length);
                sql.AppendFormat("INSERT INTO UrlKeyword (KName,Keywords,TaskID) VALUES('Domain','{0}',{1}) ", ti.Domain, ti.ID);
                db.ExecuteNonQuery(sql.ToString());
            }

            if (ti.IsFilterAllMime)
            {
                //重置Filter
                sql.Remove(0, sql.Length);
                sql.Append("DELETE * FROM Filter WHERE Taskid=").Append(ti.ID);
                db.ExecuteNonQuery(sql.ToString());

                //过滤除了优先级以外的文件
                sql.Remove(0, sql.Length);
                sql.Append("  INSERT INTO [Filter] ( TaskID, MimeID )   ");
                sql.AppendFormat("   SELECT {0},  ID ", ti.ID);
                sql.Append("   FROM Mime ");
                sql.Append("  WHERE 1=1");
                //sql.AppendFormat("   AND Mime.[id] Not In (select mimeid from Filter where taskid={0}) ", ti.ID);
                sql.AppendFormat("   AND  Mime.[id] Not In (select mimeid from Priority where taskid={0}) ", ti.ID);
                db.ExecuteNonQuery(sql.ToString());
            }
            TaskDao.UpdateCategory(ti.ID, ti.Category);
        }

    }
}
