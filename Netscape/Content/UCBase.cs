using System.Windows.Forms;

namespace Netscape
{
    public partial class UCBase : UserControl
    {
        public UCBase()
        {
            InitializeComponent();
        }
        public int TaskID { get; set; } 
        public virtual void BindData()
        {
            //清除优先级或过滤器缓存
            KCrawler.TaskCache.Clear("Priority");
            KCrawler.TaskCache.Clear("Filter");
        }
    }
}
