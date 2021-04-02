using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace KCrawler
{
    public class TaskInfo
    {
        //Ctask左侧任务栏 
        private bool isLunched = false;

        public bool IsLunched
        {
            get { return isLunched; }
            set { isLunched = value; }
        }
        public string TaskID { get { return ID.ToString(); } }
        public int ID { get; set; }
        public string TaskName { get; set; }
        public bool NotSave { get; set; }
        public string Unicode { get; set; }
        public string DownloadFolder { get; set; }
        public bool IsInternal { get; set; }
        public string EntranceURL { get; set; }
        public int ThreadCount { get; set; }
        public int ConnectionTimeout { get; set; }
        public int ThreadSleepTimeWhenQueueIsEmpty { get; set; }
        public int MinFileSize { get; set; }
        public string MinKB { get { return MinFileSize.ToString() + "KB"; } }

        public string MinMB { get { return MinFileSize <= 1024 ? MinKB : Convert.ToDouble(MinFileSize / 1024).ToString(".00") + "MB"; } }
        public string Description { get; set; }
        public bool IsPreference { get; set; }
        public List<HtmlKeywordInfo> HtmlKeyword { get; set; }
        public List<UrlKeywordInfo> UrlKeyword { get; set; }
        public List<CookieInfo> CookieList { get; set; }

        public List<PriorityInfo> Priority { get; set; }

        public List<FilterInfo> Filter { get; set; }
        public bool IsFilterAllMime { get; set; }
        public bool IsAddUkey { get; set; }

        public string Domain
        {
            get
            {
                return Utility.GetDomain(EntranceURL);
            }
        }
        public string FilterText
        {
            get
            {
                StringBuilder s = new StringBuilder();
                foreach (var u in Filter)
                {
                    s.Append('\t');
                    s.AppendLine(u.EMText);
                }
                return s.ToString();
            }
        }
        public string PriorityText
        {
            get
            {
                StringBuilder s = new StringBuilder();
                foreach (var u in Priority)
                {
                    s.Append('\t');
                    s.AppendLine(u.EMText);
                }
                return s.ToString();
            }
        }

        public string UrlKeywordText
        {
            get
            {
                StringBuilder s = new StringBuilder();
                foreach (var u in UrlKeyword)
                {
                    s.Append('\t');
                    s.AppendLine(u.KOutput);
                }
                return s.ToString();
            }
        }

        public string HtmlKeywordText
        {
            get
            {
                StringBuilder s = new StringBuilder();
                foreach (var h in HtmlKeyword)
                {
                    s.Append('\t');
                    s.AppendLine(h.KOutput);
                }
                return s.ToString();
            }
        }

        public string Category { get; set; }

        public List<ExtractOption> ExtractOptionList { get; set; }
        public string ExtractedXml
        {
            get
            {
                if (null == ExtractOptionList)
                    return string.Empty;

                if (ExtractOptionList.Count == 0)
                    return string.Empty;
                StringBuilder currentItem = new StringBuilder();
                currentItem.AppendLine(C.Xml_Item);
                foreach (var option in ExtractOptionList)
                {
                    currentItem.AppendLine(option.XmlItem);
                }
                currentItem.AppendLine(C.Xml_ItemEnd);

                return currentItem.ToString();
            }
        }

        public List<ExtractOption> ExtractLinks
        {
            get
            {
                return ExtractOptionList.Where(a => a.ExtractType == ExtractOption.Option_Links).ToList();
            }
        }
        public List<ExtractOption> ExtractContent
        {
            get
            {
                return ExtractOptionList.Where(a => a.ExtractType == ExtractOption.Option_Content).ToList();
            }
        }
    }

}

