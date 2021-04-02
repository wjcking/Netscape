using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using KCrawler;

namespace Netscape
{
    public partial class UcUrlKeyword : UCBase
    {
        public UcUrlKeyword()
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

            UrlKeywordInfo hk = new UrlKeywordInfo();

            hk.KName = string.IsNullOrEmpty(txtName.Text) ? "UKey" + listUrlKeyword.Items.Count : txtName.Text;
            hk.TaskID = TaskID;
            hk.Keywords = txtKeywords.Text;

            KeywordDao.AddKeyword(hk);
            listUrlKeyword.BindUrl();
            txtName.Clear();
            txtKeywords.Clear();
        }

        public override void BindData()
        {
            listUrlKeyword.TaskID = TaskID;
            listUrlKeyword.BindUrl();
        }

    }
}
