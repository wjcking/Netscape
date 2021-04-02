using System;
using System.ComponentModel;
using System.Diagnostics;

using System.Windows.Forms;
namespace Netscape
{
    public partial class Link : LinkLabel
    {
        public Link()
        {
            InitializeComponent();
        }

        public Link(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }
        internal void SetExpression(ref TextboxAdvanced txt)
        {
           // txt.Text.Insert(txt.SelectionStart, Text);
            txt.AppendLine(Text);
        }
        protected override void OnClick(EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(AccessibleName))
                    Process.Start(AccessibleName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            base.OnClick(e);
        }
    }
}
