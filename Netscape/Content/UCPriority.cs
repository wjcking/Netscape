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
    public partial class UCPriority : UCBase
    {
        public event PriorityLevelHandler PriorityLevelClicked;
        public UCPriority()
        {
            InitializeComponent();

        }



        public override void BindData()
        {
            try
            {
                mimeBox.TaskID = TaskID;
                priorityBox.TaskID = TaskID;
                mimeBox.BindMimeWithoutPriority();
                priorityBox.BindPrioity();
                base.BindData();
            }
            catch (Exception e)
            {
                mimeBox.Items.Add(e.Message);
            }
        }

        private void Level_Clicked(object sender, EventArgs e)
        {
            try
            {
                ListBox.SelectedObjectCollection list = mimeBox.SelectedItems;

                if (list.Count == 0)
                    return;

                //更新偏好类型
                TaskDao.UpdateCategory(TaskID, string.Empty);
                Button btn = sender as Button;
                short level = Convert.ToInt16(btn.Name.Substring(btn.Name.Length - 1, 1));

                List<PriorityInfo> priorityList = new List<PriorityInfo>();
       
                for (int i = 0; i < list.Count; i++)
                {
                  var  mi = list[i] as MimeInfo;

                    priorityList.Add(new PriorityInfo { MimeID =  mi.ID, Priority = level });
                }

                PriorityFilterDao.AddPriority(TaskID, priorityList);
                BindData();

                if (PriorityLevelClicked != null)
                    PriorityLevelClicked(sender, e);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }   
        }

        private void priorityBox_MimeJobFinished(object sender, EventArgs e)
        {
            mimeBox.BindMimeWithoutPriority();
        }
    }
}
