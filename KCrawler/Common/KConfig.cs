
namespace KCrawler
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;

    public class KConfig
    {

        private static readonly IniFiles ini = new IniFiles(C.IniFile);
        private const string ConfigurationName = "KSpider";
        private const string CMinFileSize = "CMinFileSize";

        public static int GetMinKB(string category)
        {
            return GetMinKB(category, 0);
        }
        public static int GetMinKB(string category, int defaultKB)
        {
            category = string.IsNullOrEmpty(category) ? "Default" : category;
            return ini.GetInteger(CMinFileSize, category, defaultKB);
        }
        public static void SetMinFileSize(string category, int minKb)
        {
            category = string.IsNullOrEmpty(category) ? "Default" : category;
            ini.WriteInteger(CMinFileSize, category, minKb);
        }

        public static bool IsAddUrlKeyword
        {
            get
            {
                return ini.GetBoolean(ConfigurationName, "IsAddUrlKeyword", true);
            }
            set
            {
                ini.SetBoolean(ConfigurationName, "IsAddUrlKeyword", value);
            }
        }
        public static bool IsFilterAll
        {
            get
            {
                return ini.GetBoolean(ConfigurationName, "IsFilterAll", true);
            }
            set
            {
                ini.SetBoolean(ConfigurationName, "IsFilterAll", value);
            }
        }

        public static int Interval
        {
            get
            {
                return ini.GetInteger(ConfigurationName, "Interval", 180);
            }
            set
            {
                ini.WriteInteger(ConfigurationName, "Interval", value);
            }
        }

        public static int MaxKB
        {
            get
            {
                return ini.GetInteger(ConfigurationName, "MaxKB", 100000000);
            }
            set
            {
                ini.WriteInteger(ConfigurationName, "MaxKB", value);
            }
        }

        public static string MaxMB
        {
            get
            {
                return Convert.ToDouble(MaxKB / 1024).ToString(".00") + "MB";

            }
        }

        public static string SpiderPool
        {
            get
            {
                return ini.GetString(ConfigurationName, "SpiderPool", String.Empty);
            }
            set
            {
                ini.WriteString(ConfigurationName, "SpiderPool", value);
            }
        }
    }
}
