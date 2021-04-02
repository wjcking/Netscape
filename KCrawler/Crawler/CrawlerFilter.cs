using System;
using System.IO;

namespace KCrawler
{
    public partial class CrawlerThread
    {

        private const short Link_Internal_Exists = 1;
        private const short Link_Internal_NotExists = -1;
        private const short Link_NoSets = 0;

        private const short Key_NonExists = -1;
        private const short Key_NoContent = -2;
        private const short Key_NotSave = -3;
        private const short Key_Exists = 1;
        private const short Key_NotFound = 0;

        private const short Size_Unknown = 0;
        private const short Size_LessThan = -1;
        private const short Size_MoreThran = -2;
        private const short Size_Normal = 1;


        //[Filter] 
        private bool ValidateLink(string refererLink)
        {
            if (null == refererLink)
                return false;
            // 1) 避免爬虫陷阱
            if (refererLink.Length > 400)
                return false;
            //文件协议，布隆管理器
            if (!Downloader.BloomFilter.Contains(refererLink))
            {
                if (AddFileByProtocol(refererLink))
                    return false;
            }
            //2) 是否只提取内部链接 以前是 (baseUri.IndexOf(Downloader.BaseEntranceUrl) < 0)
            if (Link_Internal_NotExists == IsInternalLink(refererLink))
                return false;
            //3) [Fitler]先过滤，然后优先级
            if (IsLinkFilteredByExtension(refererLink))
                return false;
            //4) [include] url关键字包含,如果没有则continue
            if (Key_NotFound == FilterUrlKeywords(refererLink))
                return false;

            return true;
        }
        /// <summary>
        /// [Fitler]过滤如果不是内部链接
        /// </summary>
        /// <param name="url"></param>
        /// <returns>0=不是内部链接 1=已设置为内部链接并且关键字中存在 2=已设置但关键字中不存在</returns>
        private short IsInternalLink(string url)
        {

            if (Downloader.CrawlerInfo.IsInternal)
            {
                if (url.IndexOf(Downloader.BaseEntranceUrl) > 0)
                    return Link_Internal_Exists;

                return Link_Internal_NotExists;
            }
            return Link_NoSets;
        }

        /// <summary>
        /// 如果文件小于最小值则不保存
        /// </summary>
        /// <param name="contentLength">response</param>
        /// <returns></returns>
        private short IgnoreFile(long contentLength, out int fileSize)
        {
            fileSize = 0;

            if (contentLength <= 0)
                return Size_Unknown;

            fileSize = Convert.ToInt32(contentLength / 1024);
            //如果是0可能请求不到，不忽略 
            if (fileSize < Downloader.CrawlerInfo.MinFileSize)
                return Size_LessThan;
            //如果大于总kb也取消下载
            if (fileSize > KConfig.MaxKB)
                return Size_MoreThran;

            return Size_Normal;
        }


        private short FilterUrlKeywords(string link)
        {
            if (null == Downloader.CrawlerInfo.UrlKeyword)
                return Key_NonExists;

            if (Downloader.CrawlerInfo.UrlKeyword.Count == 0)
                return Key_NonExists;
            //所有关键字列
            foreach (UrlKeywordInfo uk in Downloader.CrawlerInfo.UrlKeyword)
            {
                //如果存在直接返回，包括单个或多个关键字
                int inclucedCount = 0;
                var innerKeyList = uk.KeywordList;
                foreach (string k in innerKeyList)
                {
                    if (link.IndexOf(k) > -1)
                        inclucedCount++;
                }
                if (inclucedCount == innerKeyList.Count)
                    return Key_Exists;
            }
            //如果内容没有该关键字则继续入队链接，但不写入文件
            return Key_NotFound;
        }

        /// <summary>
        /// [include]内容键字包含,如果没有则return 1=内容关键字不为空&&内容不为空&&保存文档
        /// </summary>
        /// <param name="html">网页内容</param>
        /// <param name="url">入口链接</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        private short FilterHtmlKeywords(ref string html, ref string url, out string keyName)
        {
            keyName = null;
            //如果不保存
            if (Downloader.CrawlerInfo.NotSave)
                return Key_NotSave;
            //没有内容
            if (String.IsNullOrEmpty(html))
                return Key_NoContent;

            if (null == Downloader.CrawlerInfo.HtmlKeyword)
                return Key_NonExists;

            //若果list为空则没有关键字
            if (Downloader.CrawlerInfo.HtmlKeyword.Count == 0)
                return Key_NonExists;

            //所有关键字列
            foreach (HtmlKeywordInfo hk in Downloader.CrawlerInfo.HtmlKeyword)
            {
                //如果存在直接返回，包括单个或多个关键字
                int inclucedCount = 0;
                var innerKeyList = hk.KeywordList;
                foreach (string k in innerKeyList)
                {
                    if (html.IndexOf(k) > -1)
                        inclucedCount++;
                }

                if (inclucedCount == innerKeyList.Count)
                {
                    keyName = hk.KName;
                    return Key_Exists;
                }

            }
            //如果内容没有该关键字则继续入队链接，但不写入文件
            return Key_NotFound;
        }


        //[Fitler]如果是文件类型则下载，根据扩展名
        private bool AddFileByExtention(ref string url)
        {
            string extension = Path.GetExtension(url);
            if (PFCache.IsFileTypeViaExt(extension))
            {
                Downloader.FilePool.Add(url);
                return true;
            }

            return false;
        }
        private bool AddFileByMime(ref string url, ref string mimeType)
        {
            if (PFCache.IsFileTypeViaMime(mimeType))
            {
                Downloader.FilePool.Add(url);
                return true;
            }

            return false;
        }
        private bool AddFileByProtocol(string link)
        {
            foreach (string fp in Utility.FileProtocol)
            {
                if (link.ToLower().StartsWith(fp))
                {
                    Downloader.FilePool.Add(link);
                    Downloader.BloomFilter.Add(link);
                    return true;
                }
            }
            return false;
        }

        private CookieInfo GetCookies(string url)
        {
            var c = Downloader.CrawlerInfo.CookieList.Find(delegate(CookieInfo ci)
            {
                return url.ToLower().IndexOf(ci.Url) > -1;
            });

            return c;
        }
        /// <summary>
        /// mime过滤
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        private bool IsMimeFiltered(string mimeType)
        {
            if (mimeType.StartsWith(C.Mime_TextHtml))
                return false;

            bool isFilteredMime = Downloader.CrawlerInfo.Filter.Exists(delegate(FilterInfo fi)
            {
                return mimeType.ToLower().Trim().StartsWith(fi.Mime);
            });

            return isFilteredMime;
        }

        /// <summary>
        /// 扩展名过滤
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        private bool IsLinkFilteredByExtension(string link)
        {
            bool isFiltered = Downloader.CrawlerInfo.Filter.Exists(delegate(FilterInfo fi)
            {
                return link.ToLower().EndsWith(fi.DotExtenion);
            });

            return isFiltered;
        }
    }
}
