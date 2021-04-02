using KCrawler;
using System;
using System.Windows.Forms;

namespace Netscape
{
    public partial class KGeneral : Form
    {
        private static KGeneral kgen;
        public KGeneral()
        {
            InitializeComponent();
            numMaxKB.Value = KConfig.MaxKB;
            trackBar1.Value = KConfig.Interval;
            lbMB.Text = KConfig.MaxMB;
            lbInterval.Text = string.Format(R.KGen_Interval, KConfig.Interval);
            txtPool.Text = KConfig.SpiderPool;
            FormClosing += delegate { kgen = null; };
        }

        internal static void GetInstance()
        {
            if (null == kgen)
            {
                kgen = new KGeneral();
                kgen.Show();
            }
            else
                kgen.Activate();
        }

        private void KGeneral_Load(object sender, EventArgs e)
        {

        }

        private void numMaxKB_ValueChanged(object sender, EventArgs e)
        {
            lbMB.Text = Convert.ToDouble(numMaxKB.Value / 1024).ToString(".00") + "MB"; ;
            KConfig.MaxKB = Convert.ToInt32(numMaxKB.Value);

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lbInterval.Text = string.Format(R.KGen_Interval, trackBar1.Value);
            KConfig.Interval = trackBar1.Value;
        }

        private void btnHandle_Click(object sender, EventArgs e)
        {
            InteropPlus.BindFolder(ref txtPool);

            if (!string.IsNullOrEmpty(txtPool.Text))
                KConfig.SpiderPool = txtPool.Text;
        }

        private void txtPool_TextChanged(object sender, EventArgs e)
        {
            KConfig.SpiderPool = txtPool.Text;
        }

        private void numMaxKB_KeyUp(object sender, KeyEventArgs e)
        {
            numMaxKB_ValueChanged(sender, null);
        }
    }
}
