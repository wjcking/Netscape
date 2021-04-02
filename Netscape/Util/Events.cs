using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using KCrawler;

namespace Netscape
{

    public delegate void CTaskLivtViewHandler(object sender, CTaskEventArgs e);
    public delegate void TaskMenuHandler(object sender, EventArgs e);
    public delegate void StatusEventHandler(object sender, StatusEventArgs e);
    public delegate void MimeBoxEventHandler(object sender, EventArgs e);
    public delegate void PriorityLevelHandler(object sender, EventArgs e);
    public delegate void ExtractionHandler(object sender, EventArgs e);

    /// <summary>
    /// 格式转换选择代理【用于flowcontainer按钮发送到主窗体】
    /// </summary>
    public class CTaskEventArgs : EventArgs //事件参数类
    {
        public CTaskEventArgs(CDetails cd)
        {
            CrawlerDetailForm = cd;
        }
        public CDetails CrawlerDetailForm { get; private set; }
    }

    //状态栏事件参数
    public class StatusEventArgs : EventArgs
    {

        private bool isShowOnBallon = false;
        public string Text { get; set; }
        public Color BackgroundColor { get; set; }
        public Color ForeColor { get; set; }

        public bool IsShowOnBallon
        {
            get { return isShowOnBallon; }
            set { isShowOnBallon = value; }
        }
         
        public void Info(string info)
        {
            BackgroundColor = CK.ColorControl;
            Text = info;
        }
        public void Done()
        {
            Text = "就绪";
            BackgroundColor = CK.ColorControl;
        }
        public void Done(string doneString)
        {
            BackgroundColor = CK.ColorControl;
            Text = doneString;
        }

        public void Error(string error)
        {
            BackgroundColor = CK.ColorError;
            Text = error;
        }
        public void Start(string text)
        {
            Text = text;
            BackgroundColor = CK.ColorStart; ;
        }


    }

}
