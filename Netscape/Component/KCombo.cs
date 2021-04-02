using System.ComponentModel;
using System.Windows.Forms;

namespace Netscape
{
    public partial class KCombo : ComboBox
    {
        public KCombo()
        {
            InitializeComponent();
        }

        public KCombo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void BindUnicode()
        {
            
          //  DataSource = KCrawler. ExcelCache.Unicode;         

           SelectedIndex = 0;
        }

        public void BindMime()
        {

            Items.Clear();
        }
    }
}
