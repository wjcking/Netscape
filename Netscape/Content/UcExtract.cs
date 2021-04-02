using System;
using System.Text;
using System.Windows.Forms;
using KCrawler;
using System.Net;

namespace Netscape
{
    public partial class UcExtract : UCBase
    {


        private AddExtractInfo addExtract;
        private string previewHtml;

        private Downloader spiderExtract;
        public string Unicode { get; set; }

        public UcExtract()
        {
            InitializeComponent();
            combAddress.DropDownStyle = ComboBoxStyle.DropDown;
        }
        internal void SetUrlAddress(string url)
        {
            combAddress.Text = url;
        }
        public override void BindData()
        {
            //listExtractOption.TaskID = TaskID;
            //listExtractOption.BindExtractOption();
            listExtractOptions.BindExtractOptions(TaskID);
            combAddress.DataSource = ExtractDao.GetUrlHistory(TaskID);
            combAddress.DisplayMember = "Url";
            if (null == addExtract)
            {
                addExtract = new AddExtractInfo(TaskID, listExtractOptions.Items.Count);
                addExtract.ExtractionCallBack += addExtract_ExtractionCallBack;
            }
             
        }

        private void addExtract_ExtractionCallBack(object sender, EventArgs e)
        {
            listExtractOptions.BindExtractOptions(TaskID);
        }


        private void lnkHandle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addExtract.ShowDialog();
        }
        private void Preview(object url)
        {
            try
            {
                WebClient c = new WebClient();
                string address = url.ToString();
                if (!Uri.IsWellFormedUriString(address, UriKind.Absolute))
                    address = Uri.UriSchemeHttp + Uri.SchemeDelimiter + address; 
                ExtractDao.AddUrl(new UrlHistory() { TaskID = this.TaskID, Url =  url.ToString()});

                byte[] bt = c.DownloadData(new Uri(address));
                previewHtml = string.IsNullOrEmpty(Unicode) ? Encoding.Default.GetString(bt) : Encoding.GetEncoding(Unicode).GetString(bt);
             
            }
            catch (Exception e)
            {
                previewHtml = e.Message;
            }
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {

            txtSource.Text = R.URL_Requesting;

            Task.ThreadProc(new System.Threading.ParameterizedThreadStart(Preview), combAddress.Text);
         
            if (spiderExtract == null)
            {
                spiderExtract = new Downloader();
            }
            if (listExtractOptions.ExtractionList == null || 0 == listExtractOptions.ExtractionList.Count)
            {
                txtSource.Text = previewHtml;
                return;
            }

            spiderExtract.CrawlerInfo.ExtractOptionList = listExtractOptions.ExtractionList;

            spiderExtract.ExtractString(ref previewHtml, -1);
            txtSource.Text = spiderExtract.CrawlerInfo.ExtractedXml;


        }
    }
}
