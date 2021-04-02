using System;
using System.Windows.Forms;
using KCrawler;
using System.Diagnostics;
using System.Collections.Generic;

 
namespace Netscape
{
    public partial class MainForm : Form
    {
        private Downloader downloader;
        string currentUrl = String.Empty;

        public MainForm()
        {
            InitializeComponent();
            downloader = new Downloader(null);
            downloader.StatusChanged += new DownloaderStatusChangedEventHandler(DownloaderStatusChanged);
     
            
        }

        private void ShowSettingsDialog()
        {
            ACrawler dialog = new ACrawler();
            dialog.ShowDialog();
        }


        #region UI Events


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettingsDialog();
        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            downloader.Resume();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            downloader.Suspend();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            downloader.Abort();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            ShowSettingsDialog();
        }

        #endregion

        private void buttonGo_Click(object sender, EventArgs e)
        {
            downloader.InitSeeds(new string[] { txtSeed.Text });
            downloader.Start();

            timer.Start();
            //while(true)
            //{

            //    Application.DoEvents();
            //    Text = "链接总数：" + downloader.CrawledUrlSet.Count.ToString();
            //    if (string.IsNullOrEmpty(downloader.LastCrawledUrl))
            //        continue;

            //    if (downloader.LastCrawledUrl ==  "")
            //        continue;

            //    if (currentUrl == downloader.LastCrawledUrl)
            //        continue;
            //    currentUrl = downloader.LastCrawledUrl;

            //    //       txtOutput.AppendText(String.Format("[{0}]{1} \r\n",System.IO.Path.GetExtension(downloader.LastCrawledUrl), downloader.LastCrawledUrl ));
            // txtOutput.AppendText(downloader.LastCrawledUrl + Environment.NewLine);
            //}

        }


        delegate void UpdateDataGridCallback(Downloader d);

        private void UpdateDataGrid(Downloader d)
        {
            try
            {
                if (this.dataGridThreads.InvokeRequired)
                {
                    UpdateDataGridCallback callback = new UpdateDataGridCallback(UpdateDataGrid);
                    this.Invoke(callback, new object[] { d });
                }
                else
                {
                    //      dataGridThreads.DataSource = typeof(CrawlerThread[]);
                    dataGridThreads.DataSource = d.Crawlers;
                    dataGridThreads.Columns["Name"].Width = 100;
                    dataGridThreads.Columns["Status"].Width = 100;
                }
            }
            catch (ObjectDisposedException)
            {
            }
        }

        delegate void UpdateStatusStripCallback();

        private void UpdateStatusStrip()
        {
            //if (this.statusStrip.InvokeRequired)
            //{
            //    UpdateStatusStripCallback callback = new UpdateStatusStripCallback(UpdateStatusStrip);
            //    this.Invoke(callback, new object[] { });
            //}
            //else
            //{

            //    //if (m_downloader.UrlsQueueFrontier.Count >0)
            //    //    txtOutput.AppendText(m_downloader.UrlsQueueFrontier.Dequeue() + "\r\n");


            //}
        }

        private void DownloaderStatusChanged(object sender, DownloaderStatusChangedEventArgs e)
        {
            Downloader d = (Downloader)sender;
            UpdateDataGrid(d);

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(downloader.LastCrawledUrl))
                return;

            if (downloader.LastCrawledUrl == "")
                return;

            if (currentUrl == downloader.LastCrawledUrl)
                return;
            currentUrl = downloader.LastCrawledUrl;

            //       txtOutput.AppendText(String.Format("[{0}]{1} \r\n",System.IO.Path.GetExtension(downloader.LastCrawledUrl), downloader.LastCrawledUrl ));
            txtOutput.AppendText(downloader.LastCrawledUrl + Environment.NewLine);
            UpdateStatusStrip();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (downloader == null)
                return;
            downloader.Abort(); 
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {


        }

        private void txtOutput_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
