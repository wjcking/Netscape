using System.Data.OleDb;
using System.Collections.Generic;
using System.Data;
using System;

namespace KCrawler
{
    public class AccessHelper
    {
        private const string Connection_String = "Provider=Microsoft.Jet.OLEDB.4.0;  Data Source='mime.mdb';Jet OLEDB:Database Password=;";

        private List<OleDbParameter> paramCollection = new List<OleDbParameter>();

        public static int Delete(string tableName, int id)
        {
            return new AccessHelper().ExecuteNonQuery("  DELETE * FROM " + tableName + " WHERE ID= " + id);

        }
        public AccessHelper()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName">包括路径</param>
        public int ExecuteNonQuery(string cmdText)
        {

            OleDbConnection conn = new OleDbConnection(Connection_String);
            OleDbCommand cmd = new OleDbCommand(cmdText, conn);

            if (paramCollection.Count > 0)
            {
                foreach (OleDbParameter p in paramCollection)
                    cmd.Parameters.Add(p);
            }

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            //清空参数
            cmd.Parameters.Clear();
            paramCollection.Clear();
            return result;
        }


        public OleDbParameter AddInParameter(string name, System.Data.DbType dbType, object value)
        {
            //bool exists = paramCollection.Exists(delegate(OleDbParameter para)
            //{

            //    if (para.ParameterName == name && value == para.Value)
            //        return true;
            //    return false;
            //});

            //if (exists)
            //    return null;
            OleDbParameter p = new OleDbParameter();
            p.DbType = dbType;
            p.ParameterName = name;
            p.Value = value;
            paramCollection.Add(p);
            return p;
        }

        public OleDbDataReader ExecuteReader(string cmdText)
        {
            OleDbConnection conn = new OleDbConnection(Connection_String);
            OleDbCommand cmd = new OleDbCommand(cmdText, conn);

            if (paramCollection.Count > 0)
            {
                foreach (OleDbParameter p in paramCollection)
                    cmd.Parameters.Add(p);
            }
            conn.Open();


            OleDbDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            //清空参数
            cmd.Parameters.Clear();
            paramCollection.Clear();

            return dr;

        }


        public object ExecuteScalar(string cmdText)
        {


            OleDbConnection conn = new OleDbConnection(Connection_String);
            OleDbCommand cmd = new OleDbCommand(cmdText, conn);

            if (paramCollection.Count > 0)
            {
                foreach (OleDbParameter p in paramCollection)
                    cmd.Parameters.Add(p);
            }
            conn.Open();


            object o = cmd.ExecuteScalar();
            conn.Close();
            //清空参数
            cmd.Parameters.Clear();
            paramCollection.Clear();
            return o;
        }



        internal void Close()
        {
            paramCollection.Clear();
        }
    }
}
