namespace Netscape
{
    partial class MimeBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRemove,
            this.tsmRemoveAll,
            this.tsmSelectAll});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(125, 70);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // tsmRemove
            // 
            this.tsmRemove.Name = "tsmRemove";
            this.tsmRemove.Size = new System.Drawing.Size(124, 22);
            this.tsmRemove.Text = "取消";
            // 
            // tsmRemoveAll
            // 
            this.tsmRemoveAll.Name = "tsmRemoveAll";
            this.tsmRemoveAll.Size = new System.Drawing.Size(124, 22);
            this.tsmRemoveAll.Text = "取消所有";
            // 
            // tsmSelectAll
            // 
            this.tsmSelectAll.Name = "tsmSelectAll";
            this.tsmSelectAll.Size = new System.Drawing.Size(124, 22);
            this.tsmSelectAll.Text = "全选";
            // 
            // MimeBox
            // 
            this.ContextMenuStrip = this.contextMenu;
            this.ItemHeight = 12;
            this.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.Size = new System.Drawing.Size(120, 88);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MimeBox_KeyUp);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmRemove;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveAll;
        private System.Windows.Forms.ToolStripMenuItem tsmSelectAll;
    }
}
