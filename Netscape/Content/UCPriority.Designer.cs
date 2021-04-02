namespace Netscape
{
    partial class UCPriority
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnLevel1 = new System.Windows.Forms.Button();
            this.btnLevel2 = new System.Windows.Forms.Button();
            this.btnLevel3 = new System.Windows.Forms.Button();
            this.btnLevel4 = new System.Windows.Forms.Button();
            this.btnLevel5 = new System.Windows.Forms.Button();
            this.priorityBox = new Netscape.MimeBox(this.components);
            this.mimeBox = new Netscape.MimeBox(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(13, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "等级越高则优先抓取，网页等级为中级(已过滤类型在设置优先级无效)";
            // 
            // btnLevel1
            // 
            this.btnLevel1.Location = new System.Drawing.Point(212, 209);
            this.btnLevel1.Name = "btnLevel1";
            this.btnLevel1.Size = new System.Drawing.Size(75, 23);
            this.btnLevel1.TabIndex = 10;
            this.btnLevel1.Text = "低级 >>";
            this.btnLevel1.UseVisualStyleBackColor = true;
            this.btnLevel1.Click += new System.EventHandler(this.Level_Clicked);
            // 
            // btnLevel2
            // 
            this.btnLevel2.Location = new System.Drawing.Point(212, 180);
            this.btnLevel2.Name = "btnLevel2";
            this.btnLevel2.Size = new System.Drawing.Size(75, 23);
            this.btnLevel2.TabIndex = 10;
            this.btnLevel2.Text = "中低级>>";
            this.btnLevel2.UseVisualStyleBackColor = true;
            this.btnLevel2.Click += new System.EventHandler(this.Level_Clicked);
            // 
            // btnLevel3
            // 
            this.btnLevel3.Location = new System.Drawing.Point(212, 151);
            this.btnLevel3.Name = "btnLevel3";
            this.btnLevel3.Size = new System.Drawing.Size(75, 23);
            this.btnLevel3.TabIndex = 10;
            this.btnLevel3.Text = "中级>>";
            this.btnLevel3.UseVisualStyleBackColor = true;
            this.btnLevel3.Click += new System.EventHandler(this.Level_Clicked);
            // 
            // btnLevel4
            // 
            this.btnLevel4.Location = new System.Drawing.Point(212, 122);
            this.btnLevel4.Name = "btnLevel4";
            this.btnLevel4.Size = new System.Drawing.Size(75, 23);
            this.btnLevel4.TabIndex = 10;
            this.btnLevel4.Text = "高级>>";
            this.btnLevel4.UseVisualStyleBackColor = true;
            this.btnLevel4.Click += new System.EventHandler(this.Level_Clicked);
            // 
            // btnLevel5
            // 
            this.btnLevel5.Location = new System.Drawing.Point(212, 93);
            this.btnLevel5.Name = "btnLevel5";
            this.btnLevel5.Size = new System.Drawing.Size(75, 23);
            this.btnLevel5.TabIndex = 10;
            this.btnLevel5.Text = "最高级 >>";
            this.btnLevel5.UseVisualStyleBackColor = true;
            this.btnLevel5.Click += new System.EventHandler(this.Level_Clicked);
            // 
            // priorityBox
            // 
            this.priorityBox.FormattingEnabled = true;
            this.priorityBox.ItemHeight = 12;
            this.priorityBox.Location = new System.Drawing.Point(293, 37);
            this.priorityBox.Name = "priorityBox";
            this.priorityBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.priorityBox.Size = new System.Drawing.Size(195, 268);
            this.priorityBox.TabIndex = 0;
            this.priorityBox.TaskID = 0;
            this.priorityBox.MimeJobFinished += new Netscape.MimeBoxEventHandler(this.priorityBox_MimeJobFinished);
            // 
            // mimeBox
            // 
            this.mimeBox.FormattingEnabled = true;
            this.mimeBox.ItemHeight = 12;
            this.mimeBox.Location = new System.Drawing.Point(15, 37);
            this.mimeBox.Name = "mimeBox";
            this.mimeBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.mimeBox.Size = new System.Drawing.Size(191, 268);
            this.mimeBox.TabIndex = 0;
            this.mimeBox.TaskID = 0;
            // 
            // UCPriority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLevel1);
            this.Controls.Add(this.btnLevel2);
            this.Controls.Add(this.btnLevel3);
            this.Controls.Add(this.btnLevel4);
            this.Controls.Add(this.btnLevel5);
            this.Controls.Add(this.priorityBox);
            this.Controls.Add(this.mimeBox);
            this.Name = "UCPriority";
            this.Size = new System.Drawing.Size(579, 348);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MimeBox mimeBox;
        private MimeBox priorityBox;
        private System.Windows.Forms.Button btnLevel5;
        private System.Windows.Forms.Button btnLevel4;
        private System.Windows.Forms.Button btnLevel3;
        private System.Windows.Forms.Button btnLevel2;
        private System.Windows.Forms.Button btnLevel1;
        private System.Windows.Forms.Label label2;
    }
}
