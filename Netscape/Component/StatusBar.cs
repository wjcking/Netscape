using System.ComponentModel;
using System.Windows.Forms;

namespace Netscape
{
    public partial class StatusBar : Label, IStatus
    {
        public StatusBar()
        {
            InitializeComponent();
        }

        public StatusBar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Done()
        {
            Text = "就绪";
            BackColor = CK.ColorControl;
        }

        public void Done(string text)
        {
            Text = text;
            BackColor = CK.ColorControl;
        }

        public void Error(string text)
        {
            BackColor = CK.ColorError;
            Text = text;
        }

        public void Start(string text)
        {
            BackColor = CK.ColorStart;
            Text = text;
        }
    }
}
