﻿namespace Netscape
{
    partial class DataGridAdvanced
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridAdvanced
            // 
            this.AllowUserToAddRows = false;
            this.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.RowTemplate.Height = 23;
            this.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridAdvanced_CellClick);
            this.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridAdvanced_CellMouseUp);
            this.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridAdvanced_ColumnHeaderMouseDoubleClick);
            this.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DataGridAdvanced_RowPostPaint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
