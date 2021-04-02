using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace KCrawler
{

    public class ExcelDao
    {
        public const string HDR_YES = "Yes";
        public const string HDR_NO = "No";
        private static string SelectConnection(string path, string hdr)
        {
            string excelExtension = Path.GetExtension(path);

            if (excelExtension.ToLower() == ".xlsx")
                return String.Format("Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + path + ";Extended Properties='Excel 12.0; HDR={0}; IMEX=1'", hdr);
            else
                return String.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + ";Extended Properties=\"Excel 8.0; HDR={0};  IMEX=1\"", hdr);
        }

        public static string[] GetExcelSheetName(string path, string hdr)
        {
            try
            {
                string excelExtension = Path.GetExtension(path);

                string strConn = SelectConnection(path, hdr);

                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();


                DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                string[] strTableNames = new string[dtSheetName.Rows.Count];
                for (int k = 0; k < dtSheetName.Rows.Count; k++)
                {
                    strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
                }

                return strTableNames;
            }
            catch (Exception e)
            {
                return new string[] { e.Message };
            }
        }

        public static DataTable GetDataFromSheet(string path, string hdr, string sql)
        {
            DataTable dt = new DataTable();
            //try
            //{
            string strConn = SelectConnection(path, hdr);
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();

            DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            OleDbDataAdapter myCommand = null;

            myCommand = new OleDbDataAdapter(sql, strConn);
            dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
            //}
            //catch (Exception e)
            //{
            //    dt.Clear();
            //    dt.Columns.Add("Exception", typeof(string));
            //    DataRow dr = dt.NewRow();
            //    dr[0] = e.Message;
            //    dt.Rows.Add(dr);
            //    return dt;
            //}
        }
        public static DataTable GetDataFromSheet(string path, string sql)
        {
            return GetDataFromSheet(path, HDR_YES, sql);
        }

    }
}
