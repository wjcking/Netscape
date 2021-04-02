using System;
using KCrawler;

namespace Netscape
{
    public partial class UCCookies : UCBase
    {
        public UCCookies()
        {
            InitializeComponent();
        }
        public override void BindData()
        {
            listCookies.TaskID = TaskID;
            listCookies.BindCookies();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtUrl.Text))
            {
                errorProvider.SetError(txtUrl, R.EmptyInfo);
                return;
            }
            if (string.IsNullOrEmpty(txtUserAgent.Text))
            {
                errorProvider.SetError(txtUserAgent, R.EmptyInfo);
                return;
            }
            if (string.IsNullOrEmpty(txtCookies.Text))
            {
                errorProvider.SetError(txtCookies, R.EmptyInfo);
                return;
            }
            CookieInfo ci = new CookieInfo();

            ci.Url = txtUrl.Text.ToLower();
            ci.Cookies = txtCookies.Text;
            ci.UserAgent = txtUserAgent.Text;
            ci.TaskID = TaskID;
            KeywordDao.AddCookies(ci);

            listCookies.BindCookies();

            txtCookies.Clear();
        }
    }
}
