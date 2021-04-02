using System;
using System.Collections.Generic;
using System.Text;

using KCrawler;
using System.Windows.Forms;
using System.Threading;
using System.Data;

namespace Netscape
{

    public class Task
    {
        //爬虫运行窗体,包含
        internal static Dictionary<int, CDetails> Pool { get; private set; }
        static Task()
        {
            if (Pool == null)
                Pool = new Dictionary<int, CDetails>();
        }

       
        internal static void HideView( int taskID)
        {
            foreach (var t in Task.Pool)
            {
                if (taskID <0)
                {
                    t.Value.Hide();
                    continue;
                }

                if (t.Value.TaskID != taskID)
                    t.Value.Hide();
            }
        }

        internal static void HideView()
        {
            HideView(-1);
        }
        //线程，保存爬去数据
        internal static void ThreadProc(ThreadStart ts)
        {
            Thread stopThread = new Thread(ts);
            stopThread.Start();
            while (true)
            {
                Application.DoEvents();
                if (!stopThread.IsAlive)
                    break;
                Thread.Sleep(100);
            }
        }
        internal static void ThreadProc(ParameterizedThreadStart ts, object p)
        {
            Thread stopThread = new Thread(ts);
            stopThread.Start(p);
            while (true)
            {
                Application.DoEvents();
                if (!stopThread.IsAlive)
                    break;
                Thread.Sleep(100);
            }
        }
        internal static void ThreadQueueSave(object s)
        {
            Save();
        }
        internal static void Save()
        {
            foreach (var kv in Pool)
            {
                //if (kv.Value.CrawlerInfo.NotSave)
                //    kv.Value.Spider.Dump("Save");
                kv.Value.Spider.Save();
            }
        }
        //根据任务section获得窗体

        public static CDetails GetSpiderView(int taskid)
        {

            if (Pool.ContainsKey(taskid))
                return Pool[taskid];

            CDetails spiderWindow = new CDetails();
            spiderWindow.Spider = new Downloader(taskid);

            Pool.Add(taskid, spiderWindow);
            return spiderWindow;
        }

        internal static void Pause()
        {

            foreach (var kv in Pool)
            {
                if (kv.Value.Spider.Status != DownloaderStatus.Running)
                    continue;

                kv.Value.Spider.Suspend();
            }
        }

        internal static void Stop()
        {
            foreach (var kv in Pool)
            {
                kv.Value.Spider.Abort();
            }
        }

        internal static void Start()
        {
            foreach (var kv in Pool)
            {
                kv.Value.Spider.Start();
            }
        }

        //线程调用
        internal static void Dump()
        {
            foreach (var kv in Pool)
            {
                if (kv.Value.Spider.Status == DownloaderStatus.Stopped)
                    kv.Value.Spider.Restore();

                kv.Value.Spider.Dump();
            }
        }


        internal static void WriteXmlFile(object s)
        {
            foreach (var a in Task.Pool)
                if (a.Value.Spider.Status != DownloaderStatus.Stopped)
                a.Value.Spider.WriteXmlFile();
        }
    }
}
