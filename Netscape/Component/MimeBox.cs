using System.ComponentModel;
using System.Windows.Forms;
using KCrawler;
using System;
namespace Netscape
{
    /// <summary>
    ///  
    /// </summary>
    public partial class MimeBox : ListBox
    {
        public event MimeBoxEventHandler MimeJobFinished;

        public int TaskID { get; set; }
        public MimeBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            tsmRemove.Click += tsmMenu_Click;
            tsmRemoveAll.Click += tsmMenu_Click;
            tsmSelectAll.Click += tsmMenu_Click;


        }
        internal void BindMimeCategory()
        {
            DataSource = PreferenceDao.GetMimeCategoryList();
            DisplayMember = "Desc";
            SelectedIndex = -1;
        }

        internal void SelecteMCate(string category)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if ((Items[i] as MCateInfo).Category == category)
                    SelectedIndex = i;
            }
        }


        internal void BindMimeWithoutPriority()
        {
            DataSource = PriorityFilterDao.GetMimeWithoutPriority(TaskID);
            DisplayMember = "EMText";
            SelectedIndex = -1;
        }

        internal void BindMimeWithoutFilter()
        {
            DataSource = PriorityFilterDao.GetMimeWithoutFilter(TaskID);
            DisplayMember = "EMText";
            SelectedIndex = -1;
        }

        internal void BindPrioity()
        {
            DataSource = PriorityFilterDao.GetPriority(TaskID);
            DisplayMember = "Text";
            SelectedIndex = -1;
        }

        internal void BindFilter()
        {
            DataSource = PriorityFilterDao.GetFilter(TaskID);
            DisplayMember = "EMText";
            SelectedIndex = -1;
        }

        internal short UpdatePreference(ref TaskInfo taskInfo)
        {

            if (Name != "listPreference")
                return -1;
            //如果是自定义则退出
            if (SelectedIndex <=0)
            {
                TaskDao.UpdateCategory(taskInfo.ID, string.Empty);
                return -2;
            }
            int index = SelectedIndices[0];

            var mc = Items[index] as MCateInfo;
            if (mc.Category == taskInfo.Category)
                return -3;
            taskInfo.Category = mc.Category;
            PreferenceDao.UpdatePreference(taskInfo);
            return 0;
        }
        private void tsmMenu_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            switch (tsm.Name)
            {
                case "tsmRemove":
                    Remove(Name, false);
                    break;
                case "tsmRemoveAll":
                    Remove(Name, true);
                    break;
                case "tsmSelectAll":
                    SelectAll();
                    break;
            }
            if (MimeJobFinished != null)
                MimeJobFinished(tsm, e);
        }
        public void SelectAll()
        {
            for (int i = 0; i < Items.Count; i++)
                SelectedIndex = i;
        }
        private void Remove(string name, bool isAll)
        {

            try
            {
                int max = isAll ? Items.Count : SelectedIndices.Count;

                if (max == 0)
                    return;

                int[] idArray = new int[max];

                switch (name)
                {

                    case "priorityBox":
                        for (int i = 0; i < max; i++)
                        {
                            int s = isAll ? i : SelectedIndices[i];
                            var pi = Items[s] as PriorityInfo;

                            AccessHelper.Delete("Priority", pi.ID);
                        }

                        BindPrioity();
                        return;
                    case "filterBox":
                        for (int i = 0; i < max; i++)
                        {
                            int s = isAll ? i : SelectedIndices[i];
                            var fi = Items[s] as FilterInfo;
                            AccessHelper.Delete("Filter", fi.ID);
                        }

                        BindFilter();
                        return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


        //删除
        private void MimeBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (SelectedIndex < 0)
                return;
            if (SelectedIndices.Count == 0)
                return;
            if (e.KeyData != Keys.Delete)
                return;

            Remove(Name, false);

            if (MimeJobFinished != null)
                MimeJobFinished(sender, e);
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            switch (Name)
            {
                case "mimeBox":
                    tsmRemove.Visible = false;
                    tsmRemoveAll.Visible = false;
                    return;
                case "listPreference":
                    tsmRemove.Visible = false;
                    tsmRemoveAll.Visible = false;
                    tsmSelectAll.Visible = false;
                    return;   
            }
        }
    }
}
