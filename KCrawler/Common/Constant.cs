using System.Text;

namespace KCrawler
{

    public class C
    {
        internal static readonly string ExportXmlScheme;
        internal const string Xml_Root_KSpider = "KSpider";
        internal const string Xml_KSpiderEnd = "</" + Xml_Root_KSpider + ">";
        internal const string Xml_Item = "<Item>";
        internal const string Xml_ItemEnd = "</Item>";
        static C()
        {
            var exportXmlScheme = new StringBuilder();
            exportXmlScheme.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            exportXmlScheme.AppendLine("<" + Xml_Root_KSpider + ">");
            exportXmlScheme.AppendLine(Xml_KSpiderEnd);
            ExportXmlScheme = exportXmlScheme.ToString();
        }

        public const string StringReplacement = "{0}";
        public const string IniFile = "config.ini";
        public const string Mime_TextHtml = "text/html";

        public const string Sheet_Priority = "Priority";
        public const string Excel_Mime = "mime.xlsx";
        public const string DateFormat = "yMd-Hms";
        public const string DateFormatFile = "yMd";

        public const string Sheet_Filter = "Filter";

        public const string F_KName = "KName";
        public const string F_Keywords = "Keywords";
        public const string F_TaskID = "TaskID";
        public const string F_ID = "ID";

        public const string T_Priority = "Priority";
        public const string T_Filter = "Filter";
        public const string Bracket = "[{0}]{1}";
    }
}
