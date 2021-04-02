using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KCrawler
{
    public class ExtractDao
    {
        private readonly static AccessHelper db = new AccessHelper();

        public static void AddExtractOption(ExtractOption model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Extract](");
            strSql.Append("Label,StartString,LastString,ExtractType,TaskID,SplitType,RegEx,RegExGroup)");

            strSql.Append(" values (");
            strSql.Append("@Label,@StartString,@LastString,@ExtractType,@TaskID,@SplitType,@RegEx,@RegExGroup)");

            db.AddInParameter("Label", DbType.AnsiString, model.Label);
            db.AddInParameter("StartString", DbType.AnsiString, model.StartString);
            db.AddInParameter("LastString", DbType.AnsiString, model.LastString);
            db.AddInParameter("ExtractType", DbType.String, model.ExtractType);
            db.AddInParameter("TaskID", DbType.Int32, model.TaskID);
            db.AddInParameter("SplitType", DbType.Int32, model.SplitType);
            db.AddInParameter("RegEx", DbType.AnsiString, model.RegEx);
            db.AddInParameter("RegExGroup", DbType.AnsiString, model.RegExGroup);
            db.ExecuteNonQuery(strSql.ToString());

        }
        public static List<ExtractOption> GetOptionList(int taskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM [Extract] ");
            strSql.Append(" where TaskID=" + taskID);

            List<ExtractOption> list = new List<ExtractOption>();

            using (IDataReader dataReader = db.ExecuteReader(strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }

        static ExtractOption ReaderBind(IDataReader dataReader)
        {
            ExtractOption model = new ExtractOption();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = Convert.ToInt32(ojb);
            }
            model.TaskID = Convert.ToInt32(dataReader["TaskID"]);
            model.Label = dataReader["Label"].ToString();
            model.StartString = dataReader["StartString"].ToString();
            model.LastString = dataReader["LastString"].ToString();
            model.ExtractType = Convert.ToInt16(dataReader["ExtractType"]);
            model.SplitType = Convert.ToInt16(dataReader["SplitType"]);
            model.RegEx = dataReader["RegEx"].ToString();
            model.RegExGroup = dataReader["RegExGroup"].ToString();

            return model;
        }

        public static void DeleteExtractInfo(int id)
        {

            const string sql = "DELETE * FROM [Extract] WHERE ID=";
            db.ExecuteScalar(sql + id.ToString());


        }
        public static void UpdateExtractOption(ExtractOption model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update[Extract] set ");
            strSql.Append("[Label]=@Label ,");
            strSql.Append("StartString=@StartString,");
            strSql.Append("LastString=@LastString,");
            strSql.Append("ExtractType=@ExtractType,");
            strSql.Append("TaskID=@TaskID,");
            strSql.Append("StringFormat=@StringFormat,");
            strSql.Append("SplitType=@SplitType, ");
            strSql.Append("RegEx=@RegEx, ");
            strSql.Append("RegExGroup=@RegExGroup ");
            strSql.Append("  where ID=@ID ");

            db.AddInParameter("Label", DbType.AnsiString, model.Label);
            db.AddInParameter("StartString", DbType.AnsiString, model.StartString);
            db.AddInParameter("LastString", DbType.AnsiString, model.LastString);
            db.AddInParameter("ExtractType", DbType.String, model.ExtractType);
            db.AddInParameter("TaskID", DbType.Int32, model.TaskID);
            db.AddInParameter("StringFormat", DbType.AnsiString, model.StringFormat);
            db.AddInParameter("SplitType", DbType.String, model.SplitType);

            db.AddInParameter("RegEx", DbType.AnsiString, model.RegEx);
            db.AddInParameter("RegExGroup", DbType.AnsiString, model.RegExGroup);
            db.AddInParameter("ID", DbType.Int32, model.ID);

            db.ExecuteNonQuery(strSql.ToString());
        }

        public static void AddUrl(UrlHistory model)
        {
            
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(*) ");
                strSql.Append(" FROM UrlHistory ");

                strSql.Append(" where TaskID=" + model.TaskID.ToString());
                strSql.AppendFormat("AND Url='{0}'", model.Url.Replace("\'",""));
                int c = Convert.ToInt32(db.ExecuteScalar(strSql.ToString()));

                if (c > 0)
                    return  ;

                strSql.Remove(0, strSql.Length);

                strSql.Append("insert into UrlHistory(");
                strSql.Append("Url,TaskID)");

                strSql.Append(" values (");
                strSql.Append("@Url,@TaskID)");


                db.AddInParameter("Url", DbType.AnsiString, model.Url);
                db.AddInParameter("TaskID", DbType.Int32, model.TaskID);


                  db.ExecuteNonQuery(strSql.ToString()).ToString();
               
            
        }


        public static void DeleteUrl()
        {
            const string sql = "DELETE * FROM [Extract] ";
            db.ExecuteScalar(sql);


        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public static List<UrlHistory> GetUrlHistory(int taskid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Url,TaskID ");
            strSql.Append(" FROM UrlHistory ");

            strSql.Append(" where TaskID=" + taskid.ToString());

            var list = new List<UrlHistory>();

            using (IDataReader dataReader = db.ExecuteReader(strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(UrlReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        static UrlHistory UrlReaderBind(IDataReader dataReader)
        {
            var model = new UrlHistory();
            object ojb;
            model.Url = dataReader["Url"].ToString();
            ojb = dataReader["TaskID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TaskID = (int)ojb;
            }
            return model;
        }
    }
}
