
namespace KCrawler
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;


    public partial class CrawlerThread
    {
        private const int bufferSize = 16384;
//        private const string Error_Extract_
        //线程提取,2次提取
        private List<string> ExtractLinks(string currentUri, string baseUri, string html)
        {
            List<string> urls = null;

            try
            {
                string refererLink;
                /*第一次提取*/
                MatchCollection matches = new Regex(@"(href|HREF|src|SRC)[ ]*=[ ]*[""'][^""'#>]+[""']", RegexOptions.IgnoreCase).Matches(html);
                lock (matches.SyncRoot)
                {
                    urls = new List<string>();
                    foreach (Match match in matches)
                    {
                        refererLink = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');

                        if (!Utility.IsGoodUri(ref refererLink))
                            continue;

                        refererLink = Utility.NormalizeUri(refererLink, ref currentUri);

                        if (!ValidateLink(refererLink))
                            continue;

                        //布隆过滤器
                        if (!Downloader.BloomFilter.Contains(refererLink))
                            urls.Add(refererLink);

                        Downloader.BloomFilter.Add(refererLink);
                    }

                }
                /*第二次 html内容中提取绝对地址*/
                matches = new Regex(@"(http|https|ftp|ed2k|flashget|thunder)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase).Matches(html);

                lock (matches.SyncRoot)
                {

                    foreach (Match match in matches)
                    {
                        if (!ValidateLink(match.Value))
                            continue;
                        //布隆过滤器
                        if (!Downloader.BloomFilter.Contains(match.Value))
                            urls.Add(match.Value);

                        Downloader.BloomFilter.Add(match.Value);
                    }

                }
                /*第三次 截断或自定义正则*/

                lock (Downloader.CrawlerInfo.ExtractLinks)
                {
                    int extractedCount = Downloader.ExtractString(ref html, ExtractOption.Option_Links);

                    if (extractedCount > 0)
                    {
                        foreach (var option in Downloader.CrawlerInfo.ExtractLinks)
                        {
                            //规整url
                            option.ExtractedText = Utility.NormalizeUri(option.ExtractedText, ref currentUri);

                            if (!Downloader.BloomFilter.Contains(option.ExtractedText))
                                urls.Add(option.ExtractedText);

                            Downloader.BloomFilter.Add(option.ExtractedText);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Downloader.Logger.Error("[ExtractLinks]" + e.InnerException.Message);
             
            }

            return urls;
        }

        //过滤条件全部在这里，
        private void EnqueueLinks(ref string url, ref string html)
        {

            // 提取URL并加入队列.      
            Status = CrawlerStatusType.Parse;
            StatusChanged(this, null);

            string baseUri = Utility.GetBaseUri(url);
            List<string> links = ExtractLinks(url, baseUri, html);

            foreach (string link in links)
            {
                // 添加到url列表
                Downloader.CrawledUrls.Add(link);
                // 如果扩展名存在Excel中，则取得优先级 
                bool hasQueuePriority = Downloader.CrawlerInfo.Priority.Exists(delegate(PriorityInfo pi)
                {
                    if (link.ToLower().EndsWith(pi.DotExtenion))
                    {
                        Downloader.UrlsQueueFrontier.Enqueue(link, pi.QueuePriority);
                        return true;
                    }
                    return false;
                });

                //否则进入正常队列
                if (!hasQueuePriority)
                    Downloader.UrlsQueueFrontier.Enqueue(link);
            }

        }
        //  1.获取页面.  2.提取URL并加入队列.  3.保存页面(到网页库). 
        private void Fetch(string url)
        {
            try
            {
                // 获取页面.
                Url = url;
                Status = CrawlerStatusType.Fetch;
                //[Fitler]过滤如果不是内部链接
                if (Link_Internal_NotExists == IsInternalLink(url))
                    return;
                //获取网页byte           
                byte[] buffer = WebBuffer(ref url, ref mimeType);
                //如果出现问题则什么都不做；
                if (buffer == null)
                    return;
                string html = null;
                //下载文件夹，按照mime分类创建
                string downloadFolder = Utility.GetFolderName(Downloader.CrawlerInfo.DownloadFolder, MimeType);

                if (!Directory.Exists(downloadFolder))
                    Directory.CreateDirectory(downloadFolder);
                //根据编码读取文档
                if (MimeType.StartsWith(C.Mime_TextHtml))
                {
                    html = string.IsNullOrEmpty(Downloader.CrawlerInfo.Unicode) ? Encoding.Default.GetString(buffer) : Encoding.GetEncoding(Downloader.CrawlerInfo.Unicode).GetString(buffer);
                    Downloader.ExtractString(ref html, ExtractOption.Option_Content);
                }
                else
                    html = string.Empty;

                //[include]内容键字包含,如果没有则return 1=内容关键字不为空&&内容不为空&&保存文档
                string keywordName = null;
                if (Key_NotFound == FilterHtmlKeywords(ref html, ref url, out keywordName))
                {
                    EnqueueLinks(ref url, ref html);
                    return;
                }
                //写文件
                if (buffer != null)
                    WriteFile(ref url, ref buffer, ref downloadFolder, keywordName);

                //如果不是网页类型则退出
                if (!MimeType.StartsWith(C.Mime_TextHtml))
                    return;

                EnqueueLinks(ref url, ref html);

            }
            catch (Exception e)
            {
                Downloader.Logger.Error("[Fetch]{0} ", e.Message);
            }

        }

        private byte[] WebBuffer(ref string url, ref string mimeType)
        {
            try
            {
                //[Fitler]如果是文件类型则下载，根据扩展名 
                bool isAddedAsFile = AddFileByExtention(ref url);

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Timeout = Downloader.CrawlerInfo.ConnectionTimeout * 1000;
                CookieInfo cookies = GetCookies(url);
                if (cookies != null)
                {
                    req.Headers["Cookie"] = cookies.Cookies;
                    req.UserAgent = cookies.UserAgent;
                }
                Monitor.Enter(this);

                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.RequestTimeout)
                        return null;

                    //解除监控
                    Monitor.Exit(this);

                    mimeType = response.ContentType;
                    int fileSize = 0;
                    //[Filter]文件大小过滤
                    if (!mimeType.StartsWith(C.Mime_TextHtml))
                    {
                        short sizeResult = IgnoreFile(response.ContentLength, out fileSize);
                        if (sizeResult < 0)
                        {
                            Downloader.Logger.Info("[Ignore{0} {1}KB] {2} {3}", sizeResult, fileSize, url, mimeType);
                            return null;
                        }
                    }

                    //[Fitler]如果检查扩展名不是文件 根据mime在检查
                    if (!isAddedAsFile)
                        AddFileByMime(ref url, ref mimeType);

                    //[Fitler] Mime先过滤，
                    if (IsMimeFiltered(mimeType))
                        return null;


                    byte[] mbuffer = new byte[bufferSize];
                    MemoryStream ms = new MemoryStream();
                    int numBytesRead = 0;
                    while (true)
                    {
                        numBytesRead = response.GetResponseStream().Read(mbuffer, 0, bufferSize);
                        if (numBytesRead <= 0)
                            break;
                        ms.Write(mbuffer, 0, numBytesRead);
                    }
                    response.Close();
                    return ms.ToArray();
                }
            }
            catch (Exception e)
            {
                Downloader.Logger.Error("[WebBuffer] {0}", e.Message + " " + url + " ");
            }
           
        return null;
           
        }

        private void WriteFile(ref string url, ref byte[] buffer, ref  string downloadFolder, string kName)
        {
            // 保存页面(到网页库).
            Status = CrawlerStatusType.Save;
            StatusChanged(this, null);

            //[必须放在这里]不保存文档则强行跳过!!!!
            if (Downloader.CrawlerInfo.NotSave)
                return;


            kName = string.IsNullOrEmpty(kName) ? "" : "(" + kName + ")";
            string prefixName = kName + Downloader.SavedCount.ToString() + "-" + Guid.NewGuid().ToString().Substring(0, 4) + "-";

            string fullFileName = null;
            string fileName = null;
            FileStream fileStream = null;
            string extension = null;
            try
            {
                extension = Path.HasExtension(url) ? Path.GetExtension(url) : ".html";

                int qPos = extension.IndexOf('?');
                if (qPos > -1)
                    extension = extension.Substring(0, qPos);

                fileName = prefixName + Path.GetFileNameWithoutExtension(url) + extension;
                fullFileName = Path.Combine(downloadFolder, fileName);
                fileStream = new FileStream(fullFileName, FileMode.OpenOrCreate);
                fileStream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception e)
            {
                fileName = "[Error]" + prefixName + ".html";
                fullFileName = Path.Combine(downloadFolder, fileName);
                fileStream = new FileStream(fullFileName, FileMode.OpenOrCreate);
                fileStream.Write(buffer, 0, buffer.Length);

                if (e.GetType() != typeof(ArgumentException))
                    Downloader.Logger.Error("[WriteFile]{0}", e.Message + " " + MimeType + " " + url);
            }
            finally
            {
                fileStream.Close();
                Downloader.Logger.LogMessage(string.Format(" {0} [{1}] ", url, fileName), LogLevel.Saved);
                Downloader.SavedCount++;
            }
        }




    }
}
