
namespace Netscape
{
    using System.Windows.Forms;
    using System;
    using System.Diagnostics;

    public partial class KMain : Form
    {
        private CTask ctask = new CTask();
        //  private CDetails cDetails;    
        private StartWnd start = null;
        public KMain()
        {
            InitializeComponent();
    
        }
        private void Init()
        {

            ctask.Show(dockPanel);
            ctask.DownloaderSelected += ctask_DownloaderSelected;
            ctask.CrawlerStatusChanged += CrawlerDetailForm_CrawlerStatusChanged;
            start = new StartWnd();
            start.Show(dockPanel);

            notifyIcon.BalloonTipText = R.KMain_BallonWelcome + Task.Pool.Count.ToString();
            notifyIcon.ShowBalloonTip(2000);

        }
   

        //左侧task窗体，传输过来的窗口
        private void ctask_DownloaderSelected(object sender, CTaskEventArgs e)
        {
            e.CrawlerDetailForm.Show(dockPanel);
            e.CrawlerDetailForm.CrawlerStatusChanged += CrawlerDetailForm_CrawlerStatusChanged;
        }

        private void CrawlerDetailForm_CrawlerStatusChanged(object sender, StatusEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Text))
                return;
            statusBottom.BackColor = e.BackgroundColor;
            statusBottom.Text = e.Text;
            notifyIcon.Text = e.Text.Length > 63 ? e.Text.Substring(0, 63) : e.Text;
            if (!e.IsShowOnBallon)
                return;
            notifyIcon.BalloonTipText = notifyIcon.Text;
            notifyIcon.ShowBalloonTip(50);
        }

        private void KMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            statusBottom.Start(R.KMain_Aborting);
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Task.ThreadProc(Task.Stop);
            GC.Collect();

            e.Cancel = false;
        }

        private void MenuAndToolbar_Click(object sender, EventArgs e)
        {
            string controlName;
            if (sender is ToolStripItem)
                controlName = ((ToolStripItem)sender).Name;
            else
                controlName = (sender as ToolBarButton).Name;

            switch (controlName)
            {
                case "tsmTaskFolder":
                    Process.Start(InteropPlus.TaskFolder);
                    return;
                case "tsmHelp":
                case "tsmPreference":
                    if (start.IsHidden)
                        start.Show();
                    start.Help();
                    return;
                case "btnIni":
                case "tsmSysCfg":
                    KGeneral.GetInstance();
                    return;
                case "tsmToolbar":
                    toolbar.Visible = toolbar.Visible ? false : true;
                    tsmToolbar.CheckState = tsmToolbar.CheckState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked;
                    return;
                case "tsmStatusBar":
                    statusBottom.Visible = statusBottom.Visible ? false : true;
                    tsmStatusBar.CheckState = tsmStatusBar.CheckState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked;
                    return;
                case "btnNewTask":
                case "tsmNewTask":
                case "ntsmNewTask":
                    ACrawler acrawler = new ACrawler();
                    acrawler.Show();
                    return;
                case "tsmTaskView":
                    if (ctask.IsDisposed)
                        ctask.Show(dockPanel);
                    else
                        ctask.Activate();
                    return;
                case "tsmActivedTaskWnd":
                    foreach (var kv in Task.Pool)
                    {
                        if (kv.Value.Spider.UrlsQueueFrontier == null)
                            continue;
                        if (kv.Value.IsHidden)
                            kv.Value.Show(dockPanel);
                    }
                    return;
                case "tsmStart":
                case "btnStartPage":
                    if (start.IsHidden)
                        start.Show();
                    StartWnd.WriteJsonCategory();
                    start.Start();
                    break;
                case "btnLaunch":
                case "tsmLaunch":
                case "ntsmLaunch":
                    statusBottom.Start(R.KMain_Progressing);
                    Task.ThreadProc(Task.Start);
                    statusBottom.Done(R.KMain_Lunch);
                    break;
                case "btnPause":
                case "tsmPause":
                case "ntsmPause":
                    statusBottom.Start(R.KMain_Progressing);
                    Task.ThreadProc(Task.Pause);
                    statusBottom.Done(R.KMain_Pause);
                    break;
                case "btnStop":
                case "tsmStop":
                case "ntsmStop":
                    statusBottom.Start(R.KMain_Progressing);
                    Task.ThreadProc(Task.Stop);
                    statusBottom.Done(R.KMain_Stop);
                    break;
                case "btnKCawlerWeb":
                    Process.Start("http://www.easyfound.com.cn/KCrawler");
                    return;
                case "tsmKingsure":
                    Process.Start("http://www.easyfound.com.cn");
                    return;
                case "tsmExit":
                case "ntsmExit":
                    Close();
                    return;
                case "tsmExport":
                    statusBottom.Start(R.KMain_Progressing);
                    Task.ThreadProc(Task.Dump);
                    statusBottom.Done();
                    return;
                case "tsmDB":
                case "btnDB":
                    Process.Start(CK.KSpider_Database);
                    return;
            }
        }
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            Activate();

        }

        private void KMain_Shown(object sender, EventArgs e)
        {
            Init();
        }
    }
}
