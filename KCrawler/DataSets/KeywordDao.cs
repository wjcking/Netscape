using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KCrawler
{
    public class KeywordDao
    {
        private readonly static AccessHelper db = new AccessHelper();
        public static void DeleteUrlKeyword(int id)
        {
            const string sql = "DELETE * FROM UrlKeyword WHERE ID=";
            db.ExecuteScalar(sql + id.ToString());
        }
        public static void DeleteHtmlKeyword(int id)
        {
            const string sql = "DELETE * FROM HtmlKeyword WHERE ID=";
            db.ExecuteScalar(sql + id.ToString());
        }

        public static void DeleteCookies(int id)
        {

            const string sql = "DELETE * FROM Cookies WHERE ID=";
            db.ExecuteScalar(sql + id.ToString());
        }

        public static void AddKeyword(HtmlKeywordInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HtmlKeyword(");
            strSql.Append("KName,Keywords,TaskID)");

            strSql.Append(" values (");
            strSql.Append("@KName,@Keywords,@TaskID)");

            db.AddInParameter("KName", DbType.AnsiString, model.KName);
            db.AddInParameter("Keywords", DbType.AnsiString, model.Keywords);
            db.AddInParameter("TaskID", DbType.Int32, model.TaskID);

            db.ExecuteScalar(strSql.ToString());
        }


        public static void AddKeyword(UrlKeywordInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UrlKeyword(");
            strSql.Append("KName,Keywords,TaskID)");
            strSql.Append(" values (");
            strSql.Append("@KName,@Keywords,@TaskID)");

            db.AddInParameter("KName", DbType.AnsiString, model.KName);
            db.AddInParameter("Keywords", DbType.AnsiString, model.Keywords);
            db.AddInParameter("TaskID", DbType.Int32, model.TaskID);

            db.ExecuteScalar(strSql.ToString());

        }

        public static void AddCookies(CookieInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cookies(");
            strSql.Append("Url,UserAgent,Cookies,TaskID)");

            strSql.Append(" values (");
            strSql.Append("@Url,@UserAgent,@Cookies,@TaskID)");

            db.AddInParameter("Url", DbType.AnsiString, model.Url);
            db.AddInParameter("UserAgent", DbType.AnsiString, model.UserAgent);
            db.AddInParameter("Cookies", DbType.AnsiString, model.Cookies);
            db.AddInParameter("TaskID", DbType.Int32, model.TaskID);
            db.ExecuteScalar(strSql.ToString());
        }


        public static List<CookieInfo> GetCookieList(int taskid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Url,UserAgent,Cookies,TaskID ");
            strSql.Append(" FROM Cookies ");
            strSql.Append(" where taskid=").Append(taskid);

            List<CookieInfo> list = new List<CookieInfo>();

            using (IDataReader dataReader = db.ExecuteReader(strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(CookieReaderBind(dataReader));
                }
            }
            return list;
        }

        public static List<HtmlKeywordInfo> GetHtmlKeywordList(int taskid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,KName,Keywords,TaskID ");
            strSql.Append(" FROM HtmlKeyword ");        
                strSql.Append(" where TaskID=").Append(taskid);

            List<HtmlKeywordInfo> list = new List<HtmlKeywordInfo>();
            HtmlKeywordInfo hk;
            using (IDataReader dataReader = db.ExecuteReader(strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    hk = ReaderBind(dataReader) as HtmlKeywordInfo;
                    list.Add(hk);
                }
            }
            return list;
        }

        public static List<UrlKeywordInfo> GetUrlKeywordList(int taskid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,KName,Keywords,TaskID ");
            strSql.Append(" FROM UrlKeyword ");
            strSql.Append(" where TaskID=").Append(taskid);

            List<UrlKeywordInfo> list = new List<UrlKeywordInfo>();
            UrlKeywordInfo uk;
            using (IDataReader dataReader = db.ExecuteReader(strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    uk = ReaderBind(dataReader) as UrlKeywordInfo;
                    list.Add(uk);
                }
            }
            return list;
        }

        /// <summary>
        /// url html 子 父 类
        /// </summary>
        private static UrlKeywordInfo ReaderBind(IDataReader dataReader)
        {
            UrlKeywordInfo model = new UrlKeywordInfo();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (int)ojb;
            }
            model.KName = dataReader["KName"].ToString();
            model.Keywords = dataReader["Keywords"].ToString();
            ojb = dataReader["TaskID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TaskID = (int)ojb;
            }
            return model;
        }

        private static CookieInfo CookieReaderBind(IDataReader dataReader)
        {
            CookieInfo model = new CookieInfo();
            object ojb;
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (int)ojb;
            }
            model.Url = dataReader["Url"].ToString();
            model.UserAgent = dataReader["UserAgent"].ToString();
            model.Cookies = dataReader["Cookies"].ToString();
            ojb = dataReader["TaskID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TaskID = (int)ojb;
            }
            return model;
        }


    }
}
