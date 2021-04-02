using KCrawler;
using System;
using System.Windows.Forms;

namespace Netscape
{
    public partial class AddExtractInfo : Form
    {
        private int extractCount;
        private ExtractOption extractOption;
        public event ExtractionHandler ExtractionCallBack;

        //是否更新
        private bool flag = true;
        internal AddExtractInfo(int taskID, int ecount)
        {
            InitializeComponent();
            txtStart.AllowDrop = txtLast.AllowDrop = true;
            btnAdd.Visible = true;
            extractOption = new ExtractOption();
            extractOption.TaskID = taskID;
            extractCount = ecount;
        }

        internal AddExtractInfo(ExtractOption option)
        {
            flag = false;
            InitializeComponent();
            txtStart.AllowDrop = txtLast.AllowDrop = true;
            btnUpdate.Visible = true;
            BindData(option);

        }
        //list调用或内部
        internal void BindData(ExtractOption option)
        {
            extractOption = option;

            if (extractOption.ExtractType == ExtractOption.Option_Links)
                rbLinks.Checked = true;
            else
                rbContent.Checked = true;
            txtStart.Text = extractOption.StartString;
            txtLast.Text = extractOption.LastString;
            txtName.Text = extractOption.Label;
            tabSplitType.SelectedIndex = extractOption.SplitType;
            txtRegEx.Text = extractOption.RegEx;
            txtRegExGroup.Text = extractOption.RegExGroup;
            Text = txtName.Text;
        }
        private void DoExtraction()
        {

            switch (tabSplitType.SelectedIndex)
            {
                case ExtractOption.Split_StartLast:
                    if (String.IsNullOrEmpty(txtStart.Text))
                    {
                        errorProvider1.SetError(txtStart, R.EmptyInfo);
                        return;
                    }
                    if (String.IsNullOrEmpty(txtLast.Text))
                    {
                        errorProvider1.SetError(txtLast, R.EmptyInfo);
                        return;
                    }
                    break;
                case ExtractOption.Split_RegEx:
                    if (String.IsNullOrEmpty(txtRegEx.Text) && String.IsNullOrEmpty(txtRegExGroup.Text))
                    {
                        errorProvider1.SetError(txtRegEx, R.EmptyInfo);
                        return;
                    }
                    break;
            }
            extractOption.StartString = txtStart.Text;
            extractOption.LastString = txtLast.Text;
            extractOption.SplitType = Convert.ToInt16(tabSplitType.SelectedIndex);
            extractOption.StringFormat = String.Empty;
            extractOption.ExtractType = Convert.ToInt16(rbLinks.Checked ? 0 : 1);
            extractOption.Label = string.IsNullOrEmpty(txtName.Text) ? "Label" + (++extractCount).ToString() : txtName.Text;
            extractOption.RegEx = txtRegEx.Text;
            extractOption.RegExGroup = txtRegExGroup.Text;
            if (flag)
            {
                ExtractDao.AddExtractOption(extractOption);
                txtLast.Clear();
                txtStart.Clear();
            }
            else
            {
                ExtractDao.UpdateExtractOption(extractOption);
                Close();
            }
            if (ExtractionCallBack != null)
                ExtractionCallBack(null, null);
        }

        private void btnHandle_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Button b = sender as Button;
            switch (b.Name)
            {
                case "btnUpdate":
                    DoExtraction();                  
                    return;
                case "btnAdd":
                    DoExtraction();
                    return;
                case "btnHandle":
                    Close();
                    return;
            }
        }

        private void linkExpression_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       //     linkExpression.SetExpression(ref txtRegEx);
        }

    }
}
