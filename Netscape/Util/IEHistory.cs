using System;
using System.Collections.Generic;


using System.Runtime.InteropServices;
using System.Text;  //命名空间  
 

namespace KssOffice
{
    public class IEHistory
    {

        public struct STATURL
        {
            public static uint SIZEOF_STATURL =
                (uint)Marshal.SizeOf(typeof(STATURL));
            public uint cbSize;                    //网页大小  
            [MarshalAs(UnmanagedType.LPWStr)]      //网页Url  
            public string pwcsUrl;
            [MarshalAs(UnmanagedType.LPWStr)]      //网页标题  
            public string pwcsTitle;
            public System.Runtime.InteropServices.ComTypes.FILETIME
                ftLastVisited,                     //网页最近访问时间  
                ftLastUpdated,                     //网页最近更新时间  
                ftExpires;
            public uint dwFlags;
        }

        //ComImport属性通过guid调用com组件  
        [ComImport, Guid("3C374A42-BAE4-11CF-BF7D-00AA006946EE"),
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface IEnumSTATURL
        {
            [PreserveSig]
            //搜索IE历史记录匹配的搜索模式并复制到指定缓冲区  
            uint Next(uint celt, out STATURL rgelt, out uint pceltFetched);
            void Skip(uint celt);
            void Reset();
            void Clone(out IEnumSTATURL ppenum);
            void SetFilter(
                [MarshalAs(UnmanagedType.LPWStr)] string poszFilter,
                uint dwFlags);
        }

        [ComImport, Guid("AFA0DC11-C313-11d0-831A-00C04FD5AE38"),
            InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface IUrlHistoryStg2
        {
            #region IUrlHistoryStg methods
            void AddUrl(
                [MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
                [MarshalAs(UnmanagedType.LPWStr)] string pocsTitle,
                uint dwFlags);

            void DeleteUrl(
                [MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
                uint dwFlags);

            void QueryUrl(
                [MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
                uint dwFlags,
                ref STATURL lpSTATURL);

            void BindToObject(
                [MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
                ref Guid riid,
                [MarshalAs(UnmanagedType.IUnknown)] out object ppvOut);

            IEnumSTATURL EnumUrls();
            #endregion

            void AddUrlAndNotify(
                [MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
                [MarshalAs(UnmanagedType.LPWStr)] string pocsTitle,
                uint dwFlags,
                [MarshalAs(UnmanagedType.Bool)] bool fWriteHistory,
                [MarshalAs(UnmanagedType.IUnknown)] object    /*IOleCommandTarget*/
                poctNotify,
                [MarshalAs(UnmanagedType.IUnknown)] object punkISFolder);

            void ClearHistory();       //清除历史记录  
        }

        [ComImport, Guid("3C374A40-BAE4-11CF-BF7D-00AA006946EE")]
        class UrlHistory /* : IUrlHistoryStg[2] */ { }

        public static Dictionary<string,string> GetHistoryUrl()
        {
            IUrlHistoryStg2 vUrlHistoryStg2 = (IUrlHistoryStg2)new UrlHistory();
            IEnumSTATURL vEnumSTATURL = vUrlHistoryStg2.EnumUrls();
            STATURL vSTATURL;
            uint vFectched;

            Dictionary<string, string> historyList = new Dictionary<string, string>();
            while (vEnumSTATURL.Next(1, out vSTATURL, out vFectched) == 0)
            {
               // url.Append(string.Format("{0}\r\n{1}\r\n", vSTATURL.pwcsTitle, vSTATURL.pwcsUrl));
                //url.Append(vSTATURL.pwcsUrl).Append("\r\n");

                if (historyList.ContainsKey(vSTATURL.pwcsUrl))
                    continue;

                historyList.Add(vSTATURL.pwcsUrl, vSTATURL.pwcsTitle);
            }
            return historyList;
        }

        public static  string  GetHistoryString()
        {
            IUrlHistoryStg2 vUrlHistoryStg2 = (IUrlHistoryStg2)new UrlHistory();
            IEnumSTATURL vEnumSTATURL = vUrlHistoryStg2.EnumUrls();
            STATURL vSTATURL;
            uint vFectched;

            StringBuilder url = new StringBuilder();
            while (vEnumSTATURL.Next(1, out vSTATURL, out vFectched) == 0)
            { 
               url.Append(vSTATURL.pwcsUrl).Append("\r\n");
                 
            }
            return url.ToString();
        }
    }
}