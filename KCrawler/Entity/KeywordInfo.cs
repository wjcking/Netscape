using System;
using System.Collections.Generic;
using System.Text;

namespace KCrawler
{
    public class HtmlKeywordInfo
    {
        public int ID { get; set; }
        public string KName { get; set; }
        public string Keywords { get; set; }
        public int TaskID { get; set; }

        public string KOutput
        {
            get
            {
                return string.Format(C.Bracket, KName, Keywords);
            }
        }
        public List<string> KeywordList
        {
            get
            {
                if (string.IsNullOrEmpty(Keywords))
                    return null;

                int pos = Keywords.IndexOf(',');
                if (Keywords.Length > 0 && pos > -1)
                    return new List<string>(Keywords.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                return new List<string>() { Keywords };
            }
        }


    }
    public class UrlKeywordInfo : HtmlKeywordInfo
    {

    }

    public class CookieInfo
    {

        public int ID { get; set; }
        public string Url { get; set; }
        public string UserAgent { get; set; }
        public string Cookies { get; set; }
        public int TaskID { get; set; }
        public string CookieListItem
        {
            get
            {
                return string.Format(C.Bracket, Url, Cookies);
            }
        }

    }
}
