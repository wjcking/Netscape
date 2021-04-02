using Lv.Docking;
using System;
using System.IO;
using System.Windows.Forms;

namespace Netscape
{

    public partial class StartWnd : DockContent
    {
        private static readonly string StartUrl = Path.Combine(System.Environment.CurrentDirectory, R.URLStartPage);
        private static readonly string HelpUrl = Path.Combine(System.Environment.CurrentDirectory, R.URLHelpPage);
        /// <summary>
        /// json个人偏好模板 category
        /// </summary>
        internal static void WriteJsonCategory()
        {
            var list = KCrawler.PFCache.GetMimeCategoryList();
            string CategoryJson = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(CK.Json_CategoryFile, "var jsonCate=" + CategoryJson);
        }

        public StartWnd()
        {
            InitializeComponent();
            if (!File.Exists(CK.Json_CategoryFile))
                WriteJsonCategory();

            webBrowser.Url = new Uri(StartUrl);
            webBrowser.ObjectForScripting = new InteropPlus();
            //隐藏窗口


        }
        internal void Help()
        {
            webBrowser.Url = new Uri(HelpUrl);
            Activate();
        }
        internal void Start()
        {
            webBrowser.Url = new Uri(StartUrl);
            Activate();
        }

        private void StartWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
