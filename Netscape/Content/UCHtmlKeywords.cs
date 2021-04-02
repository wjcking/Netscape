using System;
using KCrawler;
namespace Netscape
{
    public partial class UCHtmlKeywords : UCBase
    {
        public UCHtmlKeywords()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (string.IsNullOrEmpty(txtKeywords.Text))
            {
                errorProvider.SetError(txtKeywords, R.UcKey_EmptyKeyword);
                return;
            }

            HtmlKeywordInfo hk = new HtmlKeywordInfo();

            hk.KName = string.IsNullOrEmpty(txtName.Text) ? "HKey"+ listHtmlKeyword.Items.Count  : txtName.Text;
            hk.TaskID = TaskID;
            hk.Keywords = txtKeywords.Text;

            KeywordDao.AddKeyword(hk);
            txtName.Clear();
            txtKeywords.Clear();

            listHtmlKeyword.BindHtml();
        }

        internal new void BindData()
        {
            listHtmlKeyword.TaskID = TaskID;
            listHtmlKeyword.BindHtml();
        }
    }
}
