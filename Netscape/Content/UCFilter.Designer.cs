namespace Netscape
{
    partial class UCFilter
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
            this.filterBox = new Netscape.MimeBox(this.components);
            this.mimeBox = new Netscape.MimeBox(this.components);
            this.btnFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFilterAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filterBox
            // 
            this.filterBox.FormattingEnabled = true;
            this.filterBox.ItemHeight = 12;
            this.filterBox.Location = new System.Drawing.Point(299, 37);
            this.filterBox.Name = "filterBox";
            this.filterBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.filterBox.Size = new System.Drawing.Size(176, 268);
            this.filterBox.TabIndex = 0;
            this.filterBox.TaskID = 0;
            this.filterBox.MimeJobFinished += new Netscape.MimeBoxEventHandler(this.filterBox_MimeJobFinished);
            // 
            // mimeBox
            // 
            this.mimeBox.FormattingEnabled = true;
            this.mimeBox.ItemHeight = 12;
            this.mimeBox.Location = new System.Drawing.Point(15, 37);
            this.mimeBox.Name = "mimeBox";
            this.mimeBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.mimeBox.Size = new System.Drawing.Size(183, 268);
            this.mimeBox.TabIndex = 0;
            this.mimeBox.TaskID = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(204, 101);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(89, 23);
            this.btnFilter.TabIndex = 10;
            this.btnFilter.Text = "过滤掉>>";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(13, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "已经设置优先级的不会过滤,网页类型不会过滤";
            // 
            // btnFilterAll
            // 
            this.btnFilterAll.Location = new System.Drawing.Point(204, 151);
            this.btnFilterAll.Name = "btnFilterAll";
            this.btnFilterAll.Size = new System.Drawing.Size(89, 23);
            this.btnFilterAll.TabIndex = 10;
            this.btnFilterAll.Text = "全部过滤>>";
            this.btnFilterAll.UseVisualStyleBackColor = true;
            this.btnFilterAll.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // UCFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFilterAll);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.mimeBox);
            this.Name = "UCFilter";
            this.Size = new System.Drawing.Size(533, 376);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MimeBox mimeBox;
        private MimeBox filterBox;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilterAll;
    }
}
