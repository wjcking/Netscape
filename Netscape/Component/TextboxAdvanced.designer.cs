﻿namespace Netscape
{
    partial class TextboxAdvanced
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
            this.SuspendLayout();
            // 
            // TextboxAdvanced
            // 
            this.AllowDrop = true;
            this.Multiline = true;
            this.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Size = new System.Drawing.Size(208, 122);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextboxAdvanced_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.TextboxAdvanced_DragOver);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
