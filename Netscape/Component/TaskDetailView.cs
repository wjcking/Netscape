using KCrawler;
using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace Netscape
{
    public partial class TaskDetailView : ListViewAdvanced
    {
        private ExcelSets excelSets;
        private CrawlerSets crawlerSets;
        public string TaskID { get; set; }
        public TaskDetailView()
        {
            InitializeComponent();
        }

        public TaskDetailView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void BindData()
        {
            if (String.IsNullOrEmpty(TaskID))
                return;
            if (excelSets == null)
                excelSets = new ExcelSets(TaskID);
            if (crawlerSets == null)
                crawlerSets = new CrawlerSets(TaskID);
       //     Items.Clear();
           //  ListViewItemCollection itemC = new ListViewItemCollection(this);
           // //ListViewItem lvi =new ListViewItem()
           //int index = 0;
           //  itemC.Add(new ListViewItem("fsfsdf",Groups[0]));
           // itemC[index].Group = Groups[0];
            //foreach (string k in crawlerSets.KeywordList)
            //{
            //    if (string.IsNullOrEmpty(k))
            //        continue;
            //    itemC.Add(k);
            //    itemC[index].Group = Groups["lvgKeywords"];
            //    //Groups["lvgKeywords"].Items.Add(itemC[index]);
            //    //    index++;
            //}
        
            //foreach (string uk in crawlerSets.UrlKeywordList)
            //{
            //    if (string.IsNullOrEmpty(uk))
            //        continue;
            //    itemC.Add(uk);
            //    itemC[index++].Group = Groups["lvgUrlKeywords"];
            //}


            //foreach (PriorityInfo pi in excelSets.Priority)
            //{
            //    itemC.Add(pi.Text);
            //    itemC[index++].Group = Groups["lvgPiroity"];
            //} 

            //foreach (FilterInfo fi in excelSets.Filter)
            //{
            //    itemC.Add( new ListViewItem( fi.Text, Groups["lvgFilter"]));
            //}
        //      Items.AddRange(itemC);
        }
    }
}
