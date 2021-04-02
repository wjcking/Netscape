using System.Collections.Generic;
using System.Text;

namespace KCrawler
{
    public class PFCache : Cache
    {
        public const string CachePrefix = "PFCache";
        private const string Cache_FileTypeMime = CachePrefix + "FileTypeMime";

        private static List<MimeInfo> FileTypeMime
        {
            get
            {
                lock (KCache.SyncRoot)
                {
                    if (KCache.ContainsKey(Cache_FileTypeMime))
                        return KCache[Cache_FileTypeMime] as List<MimeInfo>;
                    else
                    {
                        KCache.Add(Cache_FileTypeMime, PriorityFilterDao.FileTypeMime);
                        return KCache[Cache_FileTypeMime] as List<MimeInfo>;
                    }
                }
            }
        }

        public static List<MCateInfo> GetMimeCategoryList()
        {
            lock (KCache.SyncRoot)
            {
                string cacheName = CachePrefix + "GetMimeCategoryList";
                if (KCache.ContainsKey(cacheName))
                    return KCache[cacheName] as List<MCateInfo>;
                else
                {
                    KCache.Add(cacheName, PreferenceDao.GetMimeCategoryList());
                    return KCache[cacheName] as List<MCateInfo>;
                }
            }
        }
        /// <summary>
        /// urlkeyword kname 删除使用
        /// </summary>
        internal static string MCateString
        {
            get
            {
                var mList = PFCache.GetMimeCategoryList();
                var categoryString = new StringBuilder();

                foreach (var mc in mList)
                {
                    if (mc.Category == "" || string.IsNullOrEmpty(mc.Category))
                        continue;
                    categoryString.Append("\'");
                    categoryString.Append(mc.Category);
                    categoryString.Append("\'");
                    categoryString.Append(',');
                }
                return categoryString.ToString().Trim(',');
            }
        }
        //urlkeyword说明调用
        public static string LabelForMCate
        {
            get
            {
                return  R.MCate_LabelPrefix + MCateString.Replace("\'", "");
            }
        }
        public static bool IsFileTypeViaExt(string mimeExt)
        {
            return FileTypeMime.Exists(delegate(MimeInfo mi)
            {

                return mimeExt.ToLower() == mi.DotExtenion;
            });
        }
        public static bool IsFileTypeViaMime(string mime)
        {
            return FileTypeMime.Exists(delegate(MimeInfo mi)
            {
                return mime.ToLower().StartsWith(mi.Mime);
            });
        }
    }
}
