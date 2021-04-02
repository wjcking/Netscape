
namespace KCrawler
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Utility
    {

        private const string HTTP_PREFIX = "http://";
        private const string HTTPS_PREFIX = "https://";
        private static readonly string[] DefaultDirectoryIndexes = 
            {
                "index.htm",  "index.html", "index.asp",  "index.php", "index.jsp",   "default.htm", 
                "default.asp",  "default.aspx",  "default.php",
                "default.html",
            };
        private readonly static string[] domainNameList = new string[] 
        {
            ".com.cn", ".net.cn", ".org.cn", ".gov.cn", ".ac.cn", ".bj.cn", ".sh.cn", ".tj.cn", ".cq.cn", ".he.cn", ".sx.cn", ".nm.cn", ".ln.cn", ".jl.cn", ".hl.cn", ".js.cn", ".zj.cn", ".ah.cn", ".fj.cn", ".jx.cn", ".sd.cn", ".ha.cn", ".hb.cn", ".hn.cn", ".gd.cn", ".gx.cn", ".hi.cn", ".sc.cn", ".gz.cn", ".yn.cn", ".xz.cn", ".sn.cn", ".gs.cn", ".qh.cn", ".nx.cn", ".xj.cn", ".tw.cn", ".hk.cn", ".mo.cn", ".com", ".net", ".org", ".biz", ".info", ".cc", ".tv", ".cn" 
        };
        public readonly static List<string> FileProtocol = PriorityFilterDao.Protocol;

    

        public static string GetDomain(string domain)
        {
            Uri u = new Uri(domain);
            string url = u.Host.Replace("www.","");

            int lastDot = url.LastIndexOf('.');

            if (lastDot > -1)
                return url.Substring(0, lastDot);
            return url;
        }

        //正规化url
        public static string NormalizeUri(string url, ref string baseUrl)
        {
            if (string.IsNullOrEmpty(url))
            {
                return baseUrl;
            }
            //文件协议

            bool isFile = Utility.FileProtocol.Exists(delegate(string u) {
                return url.ToLower().StartsWith(u);
            });
            if (isFile)
                return url;

            // Only handle same schema as base uri
            if (Uri.IsWellFormedUriString(url, UriKind.Relative))
            {
                if (!string.IsNullOrEmpty(baseUrl))
                {
                    Uri absoluteBaseUrl = new Uri(baseUrl, UriKind.Absolute);
                    return new Uri(absoluteBaseUrl, url).ToString();
                }

                return new Uri(url, UriKind.Relative).ToString();
            }

            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                Uri baseUri = new Uri(baseUrl);
                Uri uri = new Uri(url);

                bool schemaMatch;

                // Special case for http/https
                if ((baseUri.Scheme == Uri.UriSchemeHttp) ||
                    (baseUri.Scheme == Uri.UriSchemeHttps))
                {
                    schemaMatch = string.Compare(Uri.UriSchemeHttp, uri.Scheme, StringComparison.OrdinalIgnoreCase) == 0 ||
                        string.Compare(Uri.UriSchemeHttps, uri.Scheme, StringComparison.OrdinalIgnoreCase) == 0;
                }
                else
                {
                    schemaMatch = string.Compare(baseUri.Scheme, uri.Scheme, StringComparison.OrdinalIgnoreCase) == 0;
                }

                if (schemaMatch)
                {
                    return new Uri(url, UriKind.Absolute).ToString();
                }
            }

            return null;
        }


        //获取子目录
        public static string GetBaseUri(string strUri)
        {
            string baseUri;
            Uri uri = new Uri(strUri);
            string port = string.Empty;
            if (!uri.IsDefaultPort)
                port = ":" + uri.Port;
            baseUri = uri.Scheme + "://" + uri.Host + port + "/";

            return baseUri;

        }


        internal static bool IsGoodUri(ref string uri)
        {
            if (uri == null)
                return false;

            if (uri.StartsWith("javascript:"))
                return false;
            if (uri.StartsWith("mailto:"))
                return false;
            if (uri.StartsWith("tencent:"))
                return false;
            if (uri.StartsWith("file://"))
                return false;
            return true;
        }


        internal static string GetFolderName(string downloadFolder, string contentType)
        {
            if (string.IsNullOrEmpty(contentType))
                return Path.Combine(downloadFolder, "NoContentType");

            int pos = contentType.IndexOf('/');

            if (pos < 0)
                return Path.Combine(downloadFolder, "NoContentType");

            return Path.Combine(downloadFolder, contentType.Substring(0, pos));
        }
    }
}
