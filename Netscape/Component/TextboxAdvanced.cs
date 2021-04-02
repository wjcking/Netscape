using System.ComponentModel;
using System.Windows.Forms;



namespace Netscape
{
    public partial class TextboxAdvanced : TextBox
    {
        public TextboxAdvanced()
        {
            InitializeComponent();
        }

        public TextboxAdvanced(IContainer container)
        {
            container.Add(this);
             
            InitializeComponent();
        }
        public void AppendLine(string text)
        {
            AppendText(text + "\r\n");
        }
        public void AppendFormat(string format, params object[] args)
        {
            AppendText(string.Format(format, args));
        }
        public void AppendLine(string format, params object[] args)
        {
            AppendText(string.Format(format, args));
            AppendText("\r\n");
        }
        public void AppendError(string error, string info)
        {
            AppendLine(string.Format("[{0}]   {1}", error, info));
        }
        private void TextboxAdvanced_DragOver(object sender, DragEventArgs e)
        {          
            e.Effect  = DragDropEffects.Move;           
        }

        private void TextboxAdvanced_DragDrop(object sender, DragEventArgs e)
        {
            Text =   e.Data.GetData(DataFormats.Text).ToString();
        }
    }
}
