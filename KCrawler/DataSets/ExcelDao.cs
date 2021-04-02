using System;
using System.Collections.Generic;

using Aspose.Cells;
namespace KCrawler
{
    public class ExcelDao 
    {

        public   static List<string> Unicode
        {
            get
            {
                Workbook workBook = new Workbook(C.Excel_Mime);
                Worksheet sheetXPath = workBook.Worksheets["unicode"];
                List<string> list = new List<string>();

                for (int i = 1; i < sheetXPath.Cells.Rows.Count; i++)
                {
                    Cells cells = sheetXPath.Cells;
                    if (cells[i, 0].Value == null)
                        continue;
                    list.Add(cells[i, 0].Value.ToString());
                }

                return list;
            }
        }
        public static void AddPriority(string taskID, List<PriorityInfo> list)
        {
            Workbook workBook = new Workbook(C.Excel_Mime);
            Worksheet sheetPrioity = workBook.Worksheets[C.Sheet_Priority];

            foreach (PriorityInfo pi in list)
            {
                int lastRow = sheetPrioity.Cells.Rows.Count;
                sheetPrioity.Cells.InsertRow(lastRow);

                sheetPrioity.Cells[lastRow, 0].PutValue(taskID);
                sheetPrioity.Cells[lastRow, 1].PutValue(pi.Extension);
                sheetPrioity.Cells[lastRow, 2].PutValue(pi.Mime);
                sheetPrioity.Cells[lastRow, 4].PutValue(pi.Priority);
            }
            workBook.Save(C.Excel_Mime);


        }

        public static void RemovePriority(int[] rowID)
        {
            Workbook workBook = new Workbook(C.Excel_Mime);
            Worksheet sheetPrioity = workBook.Worksheets[C.Sheet_Priority];
            foreach(int r in rowID)
            sheetPrioity.Cells.DeleteRow(r);
            workBook.AcceptAllRevisions();
            workBook.Save(C.Excel_Mime);

        }
        public static void RemoveFilter(int[] rowID)
        {
            Workbook workBook = new Workbook(C.Excel_Mime);
            Worksheet sheet = workBook.Worksheets[C.Sheet_Filter];
            foreach (int r in rowID)
            sheet.Cells.DeleteRow(r);
            workBook.AcceptAllRevisions();
            workBook.Save(C.Excel_Mime);

        }
        public static void AddFilter(string taskID, List<FilterInfo> list)
        {
            Workbook workBook = new Workbook(C.Excel_Mime);
            Worksheet sheetPrioity = workBook.Worksheets[C.Sheet_Filter];

            foreach (FilterInfo fi in list)
            {
                int lastRow = sheetPrioity.Cells.Rows.Count;
                sheetPrioity.Cells.InsertRow(lastRow);

                sheetPrioity.Cells[lastRow, 0].PutValue(taskID);
                sheetPrioity.Cells[lastRow, 1].PutValue(fi.Extension);
                sheetPrioity.Cells[lastRow, 2].PutValue(fi.Mime);         
            }
            workBook.Save(C.Excel_Mime);
            //      Clear();
            //    TaskName	Extension	Mime	Category	Priority(1-5)

        }
        //优先级设置
        public static List<PriorityInfo> GetPriority(string taskID)
        {

            Workbook workBook = new Workbook(C.Excel_Mime);
            Worksheet sheetXPath = workBook.Worksheets[C.Sheet_Priority];

            List<PriorityInfo> list = new List<PriorityInfo>();
            PriorityInfo pi;
            for (int i = sheetXPath.Cells.Rows.Count - 1; i > 0; i--)
            {
                Cells cells = sheetXPath.Cells;
                if (cells[i, 0].Value == null)
                    continue;

                pi = new PriorityInfo();
                pi.TaskName = cells[i, 0].Value.ToString();
                if (pi.TaskName.Trim() != taskID)
                    continue;
                pi.RowID = i;
                pi.Extension = sheetXPath.Cells[i, 1].Value.ToString();
                pi.Mime = sheetXPath.Cells[i, 2].Value.ToString();
                //   pi.Category = sheetXPath.Cells[i, 3].Value.ToString();
                try
                {
                    pi.Priority = Convert.ToInt32(sheetXPath.Cells[i, 4].Value);
                }
                catch
                {
                    pi.Priority = (int)FrontierQueuePriority.Normal;
                }
                list.Add(pi);
            }

            return list;

        }


        // mime类型 过滤列表
        public static List<FilterInfo> GetFilter(string taskID)
        {

            Workbook workBook = new Workbook(C.Excel_Mime);
            Worksheet sheetXPath = workBook.Worksheets[C.Sheet_Filter];
            List<FilterInfo> list = new List<FilterInfo>();
            FilterInfo filter;
            for (int i = sheetXPath.Cells.Rows.Count - 1; i > 0; i--)
            {
                Cells cells = sheetXPath.Cells;
                if (cells[i, 0].Value == null)
                    continue;

                filter = new FilterInfo();
                filter.TaskName = cells[i, 0].Value.ToString();
                if (filter.TaskName.Trim() != taskID)
                    continue;
                filter.RowID = i;
                filter.Extension = sheetXPath.Cells[i, 1].Value.ToString();
                filter.Mime = sheetXPath.Cells[i, 2].Value.ToString().ToLower();
                if (sheetXPath.Cells[i, 3].Value != null)
                    filter.Category = sheetXPath.Cells[i, 3].Value.ToString();

                list.Add(filter);
            }

            return list;

        }

        public static List<MimeInfo> GetMimeWithoutPriority(string taskID)
        {


            List<MimeInfo> list = Mime;
            foreach (PriorityInfo pi in GetPriority(taskID))
            {

                list.Find(delegate(MimeInfo mi)
               {
                   if (pi.Extension == mi.Extension)
                   {
                       list.Remove(mi);
                       return true;
                   }
                   return false;
               });

            }
            return list;

        }

        public static List<MimeInfo> GetMimeWithoutFilter(string taskID)
        {

            List<MimeInfo> list = Mime;
            foreach (FilterInfo fi in GetFilter(taskID))
            {

                list.Find(delegate(MimeInfo mi)
                {
                    if (fi.Extension == mi.Extension)
                    {
                        list.Remove(mi);
                        return true;
                    }
                    return false;
                });

            }
            return list;


        }
        public static List<MimeInfo> Mime
        {
            get
            {

                Workbook workBook = new Workbook(C.Excel_Mime);
                Worksheet sheetXPath = workBook.Worksheets["mime"];
                List<MimeInfo> list = new List<MimeInfo>();
                MimeInfo mi;
                //for (int i = sheetXPath.Cells.Rows.Count - 1; i > 0; i--)
                for (int i = 1; i < sheetXPath.Cells.Rows.Count; i++)
                {
                    Cells cells = sheetXPath.Cells;
                    if (cells[i, 0].Value == null)
                        continue;

                    mi = new MimeInfo();

                    if (cells[i, 0].Value!=null)
                    mi.Extension = cells[i, 0].Value.ToString();
                    if (cells[i, 1].Value != null)
                    mi.Mime = cells[i, 1].Value.ToString().ToLower();
                    if (cells[i, 2].Value != null)
                    mi.Category = cells[i, 2].Value.ToString();

                    list.Add(mi);
                }


                return list;
            }
        }


        public static List<MimeInfo> FileTypeMime
        {
            get
            {
                List<MimeInfo> list = new List<MimeInfo>();
                Workbook workBook = new Workbook(C.Excel_Mime);
                Worksheet sheetXPath = workBook.Worksheets["FileType"];

                MimeInfo mi;

                for (int i = 1; i < sheetXPath.Cells.Rows.Count; i++)
                {
                    Cells cells = sheetXPath.Cells;
                    if (cells[i, 0].Value == null)
                        continue;

                    mi = new MimeInfo();

                    mi.Extension = sheetXPath.Cells[i, 0].Value.ToString();
                    mi.Mime = sheetXPath.Cells[i, 1].Value.ToString().ToLower();

                    list.Add(mi);
                }
                return list;
            }
        }


    }
}
