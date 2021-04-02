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
    public partial class UCFilter : UCBase
    {
        public UCFilter()
        {
            InitializeComponent(); 
        }

        public override void BindData()
        {

            try
            {
                mimeBox.TaskID = TaskID;
                filterBox.TaskID = TaskID;
                mimeBox.BindMimeWithoutFilter();
                filterBox.BindFilter();
                base.BindData();
            }
            catch (Exception e)
            {
                mimeBox.Items.Add(e.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn == btnFilterAll)
                mimeBox.SelectAll();
            try
            {

                ListBox.SelectedObjectCollection list = mimeBox.SelectedItems;
                if (list.Count == 0)
                    return;

                List<int> filterList = new List<int>();             
                for (int i = 0; i < list.Count; i++)
                {
                    var f = list[i] as MimeInfo;
                    filterList.Add(f.ID);                   
                }
                PriorityFilterDao.AddFilter(TaskID, filterList);
         
                BindData();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void filterBox_MimeJobFinished(object sender, EventArgs e)
        {
            mimeBox.BindMimeWithoutFilter();
        }

    }
}
