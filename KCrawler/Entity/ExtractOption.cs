using System;
using System.Text;

namespace KCrawler
{

    public class ExtractOption
    {

        private string extractedText;
        public const short Option_Links = 0;
        public const short Option_Content = 1;


        public const short Split_StartLast = 0;
        public const short Split_RegEx = 1;
        public int TaskID { get; set; }
        public int ID { get; set; }
        public string StartString { get; set; }
        public string LastString { get; set; }
        public short ExtractType { get; set; }
        public string Label { get; set; }
        public string StringFormat { get; set; }
        public short SplitType { get; set; }
        public string SplitTypeText
        {
            get
            {
                switch (SplitType)
                {
                    case Split_StartLast:
                        return R.Extract_Split_StartLast;
                    case Split_RegEx:
                        return R.Extract_Split_RegEx;
                    default:
                        return SplitType.ToString();
                }
            }
        }
        public string ExtractTypeName
        {
            get
            {
                switch (ExtractType)
                {
                    case Option_Links:
                        return R.Extract_Links;
                    case Option_Content:
                        return R.Extract_Content;
                    default:
                        return String.Empty;
                }
            }
        }
        public string Text
        {
            get
            {
                return string.Format(C.Bracket, ExtractTypeName + ":" + Label, ExtractedText);
            }
        }

        public string ExtractedText
        {
            get
            {
                return extractedText;
            }
            set { extractedText = value; }
        }

        public string XmlItem
        {
            get
            {
                StringBuilder x = new StringBuilder();
                x.AppendFormat("\t\r\n<{0}>", Label);
                x.AppendLine("\t\r\n<![CDATA[" + ExtractedText + "]]>");
                x.AppendFormat("</{0}>", Label);

                return x.ToString();
            }
        }

        public string RegEx { get; set; }

        public string RegExGroup { get; set; }
    }

    public class UrlHistory
    {
        public string Url { get; set; }
        public int TaskID { get; set; }
    }
}
