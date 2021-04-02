using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Netscape
{
    public partial class RichTextAdvanced : RichTextBox
    {
        public delegate void LogAppendDelegate(Color color, string text);

        public RichTextAdvanced()
        {
            InitializeComponent();
        }

        public RichTextAdvanced(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private void RichTextAdvanced_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        public void AppendLine(string text)
        {
            AppendText(text + "\r\n");
        }
        private void Append()
        {

        }
        public void AppendLine(Color color, string val)
        {
            if (string.IsNullOrEmpty(val))
                return;
            int p1 = TextLength;  //取出未添加时的字符串长度。   
            AppendText(val + "\r\n");  //保留每行的所有颜色。 //  rtb.Text += strInput + "/n";  //添加时，仅当前行有颜色。   
            int p2 = val.Length;  //取出要添加的文本的长度   
            Select(p1, p2);        //选中要添加的文本   
            SelectionColor = color;  //设置要添加的文本的字体色 
        }
    }
}
