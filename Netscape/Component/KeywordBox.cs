using System.ComponentModel;
using System.Windows.Forms;
using KCrawler;
using System.Collections.Generic;
using System;
namespace Netscape
{
    public partial class KeywordBox : ListBox
    {
        public KeywordBox()
        {
            InitializeComponent();
        }

        public KeywordBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            tsmRemove.Click += tsmMenu_Click;
            tsmRemoveAll.Click += tsmMenu_Click;
            tsmSelectAll.Click += tsmMenu_Click;
        }

        internal int TaskID { get; set; }

        internal void BindUrl()
        {
            try
            {
                List<UrlKeywordInfo> list = KeywordDao.GetUrlKeywordList(TaskID);
                DataSource = list;
                DisplayMember = "KOutput";
                SelectedIndex = -1;
            }
            catch (Exception e)
            {
                Items.Add(e.Message);
            }

        }

        internal void BindHtml()
        {
            try
            {
                List<HtmlKeywordInfo> list = KeywordDao.GetHtmlKeywordList(TaskID);
                DataSource = list;
                DisplayMember = "KOutput";
                SelectedIndex = -1;
            }
            catch (Exception e)
            {
                Items.Add(e.Message);
            }
        }

        private void KeywordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Delete)
                return;
            if (SelectedIndices.Count == 0)
                return;
            Remove();
        }

        private void Remove()
        {

            for (int i = 0; i < SelectedIndices.Count; i++)
            {
                int index = SelectedIndices[i];

                if (Name == "listUrlKeyword")
                {
                    UrlKeywordInfo url = Items[index] as UrlKeywordInfo;
                    KeywordDao.DeleteUrlKeyword(url.ID);
                }
                else if (Name == "listCookies")
                {
                    CookieInfo cookieInfo = Items[index] as CookieInfo;
                    KeywordDao.DeleteCookies(cookieInfo.ID);
                }
                else if (Name == "listHtmlKeyword")
                {
                    HtmlKeywordInfo html = Items[index] as HtmlKeywordInfo;
                    KeywordDao.DeleteHtmlKeyword(html.ID);
                }
                else
                {
                    var extractOption = Items[index] as ExtractOption;
                    ExtractDao.DeleteExtractInfo(extractOption.ID);

                }
            }

            if (Name == "listUrlKeyword")
                BindUrl();
            else if (Name == "listCookies")
                BindCookies();
            else if (Name == "listHtmlKeyword")
                BindHtml();
            else
                BindExtractOption();
        }

        private void tsmMenu_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            switch (tsm.Name)
            {
                case "tsmRemove":
                    Remove();
                    break;
                case "tsmRemoveAll":
                    SelectAll();
                    Remove();
                    break;
                case "tsmSelectAll":
                    SelectAll();
                    break;
            }
        }

        public void SelectAll()
        {
            for (int i = 0; i < Items.Count; i++)
                SelectedIndex = i;
        }

        internal void BindCookies()
        {
            try
            {
                List<CookieInfo> list = KeywordDao.GetCookieList(TaskID);
                DataSource = list;
                DisplayMember = "CookieListItem";
            }
            catch (Exception e)
            {
                Items.Add(e.Message);
            }
        }

        internal void BindExtractOption()
        {
         
        }
    }
}
