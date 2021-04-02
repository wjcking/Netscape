using KCrawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Netscape
{
    public partial class ListViewAdvanced : ListView
    {
        private AddExtractInfo wndExtraction;
        public List<ExtractOption> ExtractionList
        {
            get;
            private set;
        }

        public const string CName_ExtractOption = "listExtractOptions";
        public ListViewAdvanced()
        {
            InitializeComponent();

        }

        public ListViewAdvanced(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }

        public void Init()
        {

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            UpdateStyles();

        }

        private void BindExtractOptions()
        {
            if (SelectedIndices.Count <= 0)
                return;

            int index = SelectedIndices[0];
            BindExtractOptions(ExtractionList[index].TaskID);
            Refresh();
        }
        internal void BindExtractOptions(int taskID)
        {
            try
            {
                Items.Clear();
                ExtractionList = ExtractDao.GetOptionList(taskID);
                ExtractOption o;
                for (int i = 0; i < ExtractionList.Count; i++)
                {
                    o = ExtractionList[i];
                    Items.Add(o.Label);
                    Items[i].SubItems.Add(o.ExtractTypeName);
                    Items[i].SubItems.Add(o.SplitTypeText);
                    if (o.SplitType == ExtractOption.Split_StartLast)
                    {
                        Items[i].SubItems.Add(o.StartString);
                        Items[i].SubItems.Add(o.LastString);
                    }
                    else
                    {

                        Items[i].SubItems.Add(o.RegEx);
                        Items[i].SubItems.Add("");
                    }
                    //Items[i].Text = o.FieldName;
                    //Items[i].SubItems[0].Text = o.StartString;
                    //Items[i].SubItems[1].Text = o.LastString;
                    //Items[i].SubItems[2].Text = o.ExtractedText;
                }
            }
            catch (Exception e)
            {
                Items.Add(e.Message);
            }
        }

        //ucExtract
        private void DoExtraction()
        {

            if (Name != CName_ExtractOption)
                return;
            if (ExtractionList == null)
                return;
            if (SelectedIndices.Count <= 0)
                return;

            int index = SelectedIndices[0];

            if (wndExtraction == null || wndExtraction.IsDisposed)
            {
                wndExtraction = new AddExtractInfo(ExtractionList[index]);
                wndExtraction.ExtractionCallBack += wndExtraction_ExtractionCallBack;
                wndExtraction.Show();
            }
            else
            {
                wndExtraction.BindData(ExtractionList[index]);
                wndExtraction.Activate();
            }

        }

        void wndExtraction_ExtractionCallBack(object sender, EventArgs e)
        {
            BindExtractOptions();
        }
        private void ListViewAdvanced_DoubleClick(object sender, EventArgs e)
        {
            DoExtraction();
        }

        private void ListViewAdvanced_KeyUp(object sender, KeyEventArgs e)
        {
            if (SelectedIndices.Count <= 0)
                return;

            int index = SelectedIndices[0];


            switch (Name)
            {
                case CName_ExtractOption:

                    if (e.KeyData != Keys.Delete)
                        return;
                    ExtractDao.DeleteExtractInfo(ExtractionList[index].ID);
                    BindExtractOptions();
                    return;
            }
        }


    }
}
