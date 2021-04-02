using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KCrawler
{
    public class PriorityFilterDao
    {

        private readonly static AccessHelper db = new AccessHelper();
        public static void AddPriority(int taskID, List<PriorityInfo> pi)
        {
            const string sql = "   INSERT INTO [Priority] ( TaskID, MimeID,Priority )  VALUES({0},{1},{2}) ";
            const string filter = " DELETE * FROM filter WHERE TaskID={0} AND MimeID={1}";
            foreach (PriorityInfo p in pi)
            {
                db.ExecuteNonQuery(string.Format(sql, taskID, p.MimeID, p.Priority));
                db.ExecuteNonQuery(string.Format(filter, taskID, p.MimeID));
            }
        }

        public static void AddFilter(int taskID, List<int> mimeID)
        {
            const string sql = "    INSERT INTO [Filter] ( TaskID, MimeID )  VALUES({0},{1}) ";
            foreach (int id in mimeID)
                db.ExecuteNonQuery(string.Format(sql, taskID, id));
        }
        /// <summary>
        /// 返回新增taskid
        /// </summary>
        public static void RemovePriority(int[] rowID)
        {
            const string sql = "  DELETE * FROM Pirority WHERE ID= ";

            foreach (int id in rowID)
                db.ExecuteNonQuery(sql + id);
        }

        public static void RemoveFilter(int[] rowID)
        {
            const string sql = "  DELETE * FROM Filter WHERE ID= ";

            foreach (int id in rowID)
                db.ExecuteNonQuery(sql + id);
        }

        public static List<FilterInfo> GetFilter(int taskID)
        {
            const string sql = "SELECT *  FROM Mime RIGHT JOIN Filter ON Mime.ID = Filter.MimeID WHERE TaskID={0}";
            IDataReader dr = db.ExecuteReader(string.Format(sql, taskID));
            var list = new List<FilterInfo>();
            FilterInfo model;
            while (dr.Read())
            {
                model = new FilterInfo();
                object ojb;
                model.Extension = dr["Extension"].ToString();
                model.Mime = dr["Mime"].ToString();
                model.Category = dr["Category"].ToString(); 

                ojb = dr["Filter.ID"];
                if (ojb != null && ojb != DBNull.Value)
                    model.ID = (int)ojb;
                list.Add(model);
            }
            return list;
        }

        public static List<PriorityInfo> GetPriority(int taskID)
        {
            const string sql = "SELECT * FROM Mime RIGHT JOIN Priority ON Mime.ID = Priority.MimeID WHERE TaskID = {0}";
            IDataReader dr = db.ExecuteReader(string.Format(sql, taskID));
            var list = new List<PriorityInfo>();
            PriorityInfo model;
            while (dr.Read())
            {
                model = new PriorityInfo();
                object ojb;
                model.Extension = dr["Extension"].ToString();
                model.Mime = dr["Mime"].ToString();
                model.Category = dr["Category"].ToString();
                model.MimeID = (int)dr["mimeid"];
                ojb = dr["Priority.ID"];
                if (ojb != null && ojb != DBNull.Value)              
                    model.ID = (int)ojb;

                ojb = dr["Priority"];
                if (ojb != null && ojb != DBNull.Value)
                    model.Priority = Convert.ToInt16(ojb);

                list.Add(model);
            }
            return list;
        }

        public static List<MimeInfo> GetMimeWithoutFilter(int taskID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("   SELECT * ");
            sql.Append("   FROM Mime ");
            sql.AppendFormat("   WHERE Mime.[id] Not In (select mimeid from Filter where taskid={0}) ", taskID);
            sql.AppendFormat("   AND  Mime.[id] Not In (select mimeid from Priority where taskid={0}) ", taskID);

            IDataReader dr = db.ExecuteReader(sql.ToString());
            var list = new List<MimeInfo>();
        
            while (dr.Read())
            { 
                list.Add(MimeReaderBind(dr));
            }
            return list;
        }

        public static List<MimeInfo> GetMimeWithoutPriority(int taskID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append("  FROM Mime  ");
            sql.AppendFormat(" WHERE Mime.[id] Not In (select mimeid from Priority where taskid={0}) ", taskID);
            sql.AppendFormat("   AND Mime.[id] Not In (select mimeid from Filter where taskid={0}) ", taskID);
            IDataReader dr = db.ExecuteReader(sql.ToString());
            var list = new List<MimeInfo>();

            while (dr.Read())
            {
                list.Add(MimeReaderBind(dr));
            }
            return list;
        }


        private static MimeInfo MimeReaderBind(IDataReader dataReader)
        {
            MimeInfo model = new MimeInfo();
            object ojb;
            model.Extension = dataReader["Extension"].ToString();
            model.Mime = dataReader["Mime"].ToString();
            model.Category = dataReader["Category"].ToString();
            model.MType = Convert.ToInt16(dataReader["MType"]);
            ojb = dataReader["ID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (int)ojb;
            }
            return model;
        }

        public static List<MimeInfo> FileTypeMime {

            get
            {
                IDataReader dataReader = db.ExecuteReader("SELECT *  FROM [Mime] WHERE MType=1 ");
                var list = new List<MimeInfo>();

                while (dataReader.Read())
                {
                    list.Add(MimeReaderBind(dataReader));
                }
                return list;
            }
        }

        public static List<string> Protocol
        {

            get
            {
                IDataReader dataReader = db.ExecuteReader("SELECT [Prefix]  FROM [Protocol]   ");
                var p=new  List<string>();
                while (dataReader.Read())
                {
                    p.Add(dataReader["Prefix"].ToString());
                }
                return p;
            }
        }
    }
}
