using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace KCrawler
{

    public partial class Downloader
    {
        private StringBuilder xmlAppender = new StringBuilder(C.ExportXmlScheme);
        //配置总揽
        public string Overview
        {
            get
            {
                StringBuilder overview = new StringBuilder();
                overview.AppendLine(string.Empty);
                overview.AppendLine(R.CDetails_TaskID + CrawlerInfo.TaskID);
                overview.AppendLine("\t" + R.CDetails_TaskName + CrawlerInfo.TaskName);

                overview.AppendLine("\t" + R.CDetails_EntranceURL + CrawlerInfo.EntranceURL);
                //if (!string.IsNullOrEmpty(Downloader.CrawlerSets.UserAgent))
                //    overview.AppendLine("\tUserAgent" + Downloader.CrawlerSets.UserAgent);
                //if (!string.IsNullOrEmpty(Downloader.CrawlerSets.Cookies))
                //    overview.AppendLine("\tCookies" + Downloader.CrawlerSets.Cookies);

                overview.AppendLine("\t" + R.CDetails_DownloadFolder + CrawlerInfo.DownloadFolder);

                if (!string.IsNullOrEmpty(CrawlerInfo.Unicode))
                    overview.AppendLine("\t" + R.CDetails_Unicode + CrawlerInfo.Unicode);

                if (CrawlerInfo.IsInternal)
                    overview.AppendLine("\t" + R.CDetails_IsInternal);

                if (CrawlerInfo.NotSave)
                    overview.AppendLine("\t" + R.CDetails_NotSave);
                //日志
                overview.AppendLine(R.CDetails_LogCount);
                overview.AppendLine("\t" + Logger.LogCountText);
                overview.AppendLine(R.CDetails_QueueCount);
                overview.AppendLine("\t" + UrlsQueueFrontier.QueueTotal);

                if (CrawlerInfo.UrlKeyword.Count > 0)
                {
                    overview.AppendLine(R.CDetails_UrlKeywords);
                    overview.AppendLine(CrawlerInfo.UrlKeywordText);
                }
                if (CrawlerInfo.HtmlKeyword.Count > 0)
                {
                    overview.AppendLine(R.CDetails_Keywords);
                    overview.AppendLine(CrawlerInfo.HtmlKeywordText);
                }
                if (CrawlerInfo.Priority.Count > 0)
                {
                    overview.AppendLine(R.CDetails_Priority);
                    overview.AppendLine(CrawlerInfo.PriorityText);
                }
                if (CrawlerInfo.Filter.Count > 0)
                {
                    overview.AppendLine(R.CDetails_Filter);
                    overview.AppendLine(CrawlerInfo.FilterText);
                }


                return overview.ToString();
            }
        }

        //任务个数详细信息
        public string TotalCountInfo
        {
            get
            {
                StringBuilder total = new StringBuilder();
                if (CrawlerInfo.NotSave)
                    total.Append(' ').Append(R.CrawlerSets_NotSave);
                if (CrawlerInfo.IsInternal)
                    total.Append(' ').Append(R.CrawlerSets_Internal);
                //      if (!string.IsNullOrEmpty(CrawlerSets.UrlKeywordText))
                total.Append(' ').Append(R.CDetails_UrlKeywords).Append(CrawlerInfo.UrlKeyword.Count);
                //  if (!string.IsNullOrEmpty(CrawlerSets.UrlKeywords))
                total.Append(' ').Append(R.CDetails_Keywords).Append(CrawlerInfo.HtmlKeyword.Count);
                int c = CrawlerInfo.Priority.Count;
                if (c > 0)
                    total.Append(' ').Append(R.CrawlerSets_Priority).Append(c);
                c = CrawlerInfo.Filter.Count;
                if (c > 0)
                    total.Append(' ').Append(R.CrawlerSets_Filter).Append(c);
                total.Append(" " + R.Range_FileSize);
                total.Append(' ').AppendFormat("{0}--{1}", CrawlerInfo.MinMB, KConfig.MaxMB);
                return total.ToString();
            }
        }

        //所有爬去文件url
        public string FileTotalUrls
        {
            get
            {
                StringBuilder files = new StringBuilder();
                for (int i = 0; i < FilePool.Count; i++)
                    files.Append(FilePool[i] + "\r\n");
                return files.ToString();
            }
        }
        private void CrawlerStatusChanged(object sender, CrawlerStatusChangedEventArgs e)
        {
            if (StatusChanged != null)
            {
                DownloaderStatusChangedEventArgs myEvent = new DownloaderStatusChangedEventArgs();
                StatusChanged(this, myEvent);
            }
        }
        public void Suspend()
        {
            DoThread(1);
        }

        public void Resume()
        {
            DoThread(2);
        }

        public void Abort()
        {
            DoThread(3);
        }

        private void DoThread(object status)
        {

            if (crawlerThreads == null)
                return;

            int s = Convert.ToInt32(status);
            for (int i = 0; i < crawlerThreads.Length; i++)
            {
                if (null == crawlerThreads[i])
                    continue;
                switch (s)
                {
                    case 1:
                        crawlerThreads[i].Suspend();
                        systemStatus = DownloaderStatus.Paused;
                        continue;
                    case 2:
                        crawlerThreads[i].Resume();
                        systemStatus = DownloaderStatus.Running;
                        continue;
                    case 3:
                        crawlerThreads[i].Abort();
                        systemStatus = DownloaderStatus.Stopped;
                        continue;
                }
            }
            Save();
        }

        //保存进度,导出url，error 
        public void Save()
        {

            try
            {
                Logger.Info(R.Log_Info_SavingQueue);
                SerialUnit.Save(UrlsQueueFrontier, Path_CacheQueue);
                Logger.Info(R.Log_Info_SavingUrl);
                SerialUnit.Save(CrawledUrls, Path_CrawledUrl);
                SerialUnit.Save(FilePool, Path_FilePool);
                SerialUnit.Save(BloomFilter, Path_Bloom);
                SerialUnit.Save(Logger.Log, Path_Log);

            }
            catch (Exception e)
            {
                Logger.Error("[Save]" + e.Message);
            }

        }
        //清除文件记录
        public void Clear()
        {
            try
            {
                File.Delete(Path_CacheQueue);
                File.Delete(Path_CrawledUrl);
                File.Delete(Path_FilePool);
                File.Delete(Path_Bloom);
                File.Delete(Path_Log);
            }
            catch (Exception e)
            {
                Logger.Fatal("[Clear]" + e.Message);
            }
        }
        public void Dump()
        {
            Dump(String.Empty);
        }


        //dumptype=哪里执行的
        public void Dump(string dumpType)
        {
            try
            {
                //重新还原，导出
                if (systemStatus == DownloaderStatus.Stopped && UrlsQueueFrontier== null)
                    Restore();

                if (!string.IsNullOrEmpty(dumpType))
                    dumpType = "[" + dumpType + "]";

                string pathDumpLog = Path.Combine(CrawlerInfo.DownloadFolder, dumpType + "Log.txt");
                string pathDumpUrls = Path.Combine(CrawlerInfo.DownloadFolder, dumpType + "Urls.txt");
                string pathDumpFiles = Path.Combine(CrawlerInfo.DownloadFolder, dumpType + "Files.txt");

                //日志
                using (StreamWriter writer = new StreamWriter(new FileStream(pathDumpLog, FileMode.OpenOrCreate)))
                {
                    for (int i = 0; i < Logger.Log.Count; i++)
                        if (Logger[i] != null)
                            writer.WriteLine(Logger[i].LogOutTime);
                }
                //文件
                using (StreamWriter writer = new StreamWriter(new FileStream(pathDumpFiles, FileMode.OpenOrCreate)))
                {
                    for (int i = 0; i < FilePool.Count; i++)
                    {
                        writer.WriteLine(FilePool[i]);
                    }
                }
                //地址
                using (StreamWriter writer = new StreamWriter(new FileStream(pathDumpUrls, FileMode.OpenOrCreate)))
                {
                    for (int i = 0; i < CrawledUrls.Count; i++)
                    {
                        writer.WriteLine(CrawledUrls[i]);
                    }

                    //const string Path = @"C:\Users\Administrator\Desktop\";
                    //var porn = File.ReadAllText(Path + "ping.ini", Encoding.Default);

                    //var pornArray = porn.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    //var thunders = pornArray.Where(t => t.StartsWith("thunder")).ToList();
                    //var flashgets = pornArray.Where(t => t.ToLower().StartsWith("flashget")).ToList();
                    //var ed2ks = pornArray.Where(t => t.StartsWith("ed2k")).ToList();

                    //var address = new StringBuilder();
                    //foreach (var t in thunders)
                    //{
                    //    address.AppendLine(t);
                    //}
                    //foreach (var t in flashgets)
                    //{
                    //    address.AppendLine(t);
                    //}
                    //foreach (var t in ed2ks)
                    //{
                    //    address.AppendLine(t);
                    //}
                    //address.AppendFormat("\r\n\r\nthunders:{0} flashgets:{1} ed2ks:{2}", thunders.Count, flashgets.Count, ed2ks.Count);
                    //File.WriteAllText(Path + "exported.txt", address.ToString(), Encoding.Default);
                }
            }
            catch (Exception e)
            {
                Logger.Error("[Dump]" + e.Message);
            }
        }

        /// <summary>
        /// 展示或内部使用，提取内容
        /// </summary>
        /// <param name="html"></param>
        /// <param name="extractType"></param>
        /// <returns></returns>
        public int ExtractString(ref string html, short extractType)
        {
            List<ExtractOption> eString = null;
            int c = 0;

            switch (extractType)
            {
                case ExtractOption.Option_Links:
                    eString = CrawlerInfo.ExtractLinks;
                    break;
                case ExtractOption.Option_Content:
                    eString = CrawlerInfo.ExtractContent;
                    break;
                default:
                    eString = CrawlerInfo.ExtractOptionList;
                    break;
            }

            if (eString == null)
                return 0;

            if (eString.Count == 0)
                return 0;

            string restString;

            for (int i = 0; i < eString.Count; i++)
            {
                eString[i].ExtractedText = String.Empty;

                switch (eString[i].SplitType)
                {
                    case ExtractOption.Split_StartLast:
                        int startIndex = html.IndexOf(eString[i].StartString);
                        if (startIndex < 0)
                            continue;
                        restString = html.Substring(eString[i].StartString.Length + startIndex);

                        int lastIndex = restString.IndexOf(eString[i].LastString);
                        if (lastIndex < 0)
                            continue;
                        eString[i].ExtractedText = restString.Substring(0, lastIndex);
                        if (eString[i].ExtractedText.Length > 0)
                            c++;
                        break;
                    case ExtractOption.Split_RegEx:

                        var regex = new Regex(eString[i].RegEx, RegexOptions.IgnoreCase);
                        Match match = regex.Match(html);

                        if (match.Success)
                        {
                            eString[i].ExtractedText = match.Value;
                            c++;
                        }
                        if (ExtractOption.Option_Content == extractType)
                        {
                            var regexGroup = new Regex(eString[i].RegExGroup, RegexOptions.IgnoreCase).Matches(html);
                            StringBuilder collection = new StringBuilder();
                            foreach (Match m in regexGroup)
                            {
                                collection.AppendLine(m.Value);
                            }
                            if (collection.Length > 0)
                            {
                                eString[i].ExtractedText = collection.ToString();
                                c++;
                            }
                        }

                        break;
                }

            }

            if (ExtractOption.Option_Content == extractType)
            {
                if (!string.IsNullOrEmpty(CrawlerInfo.ExtractedXml))
                    xmlAppender.Insert(xmlAppender.ToString().LastIndexOf(C.Xml_KSpiderEnd), CrawlerInfo.ExtractedXml);
            }
            return c;
        }
        //退出和定时导出
        public void WriteXmlFile()
        {
            if (!Directory.Exists(Path.Combine(CrawlerInfo.DownloadFolder, CrawlerInfo.TaskName)))
                return;
            string path = Path.Combine(CrawlerInfo.DownloadFolder, CrawlerInfo.TaskName + DateTime.Now.ToString(C.DateFormatFile) + ".xml");
            
            File.WriteAllText(path, xmlAppender.ToString());
        }

        internal void ClearXmlApplender()
        {
            xmlAppender.Remove(0, xmlAppender.Length);
            xmlAppender.Append(C.ExportXmlScheme);
        }

    }
}
