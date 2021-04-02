namespace Netscape
{
    partial class UCHtmlKeywords
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
            this.listHtmlKeyword = new Netscape.KeywordBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // listHtmlKeyword
            // 
            this.listHtmlKeyword.FormattingEnabled = true;
            this.listHtmlKeyword.ItemHeight = 12;
            this.listHtmlKeyword.Location = new System.Drawing.Point(13, 134);
            this.listHtmlKeyword.Name = "listHtmlKeyword";
            this.listHtmlKeyword.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listHtmlKeyword.Size = new System.Drawing.Size(482, 172);
            this.listHtmlKeyword.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(11, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 12);
            this.label1.TabIndex = 63;
            this.label1.Text = "内容筛选名称(不填则自动生成）";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtName.Location = new System.Drawing.Point(13, 106);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtName.Size = new System.Drawing.Size(177, 21);
            this.txtName.TabIndex = 64;
            this.txtName.Tag = " ";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(420, 31);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 51);
            this.btnAdd.TabIndex = 62;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtKeywords
            // 
            this.txtKeywords.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtKeywords.Location = new System.Drawing.Point(13, 31);
            this.txtKeywords.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKeywords.MaxLength = 255;
            this.txtKeywords.Multiline = true;
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKeywords.Size = new System.Drawing.Size(383, 51);
            this.txtKeywords.TabIndex = 61;
            this.txtKeywords.Tag = " ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(12, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(317, 12);
            this.label16.TabIndex = 57;
            this.label16.Text = "内容包含关键字(如 股票大全,美女,神教 多个用逗号分开)";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // UCHtmlKeywords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listHtmlKeyword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.label16);
            this.Name = "UCHtmlKeywords";
            this.Size = new System.Drawing.Size(543, 358);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private KeywordBox listHtmlKeyword;
        private System.Windows.Forms.ErrorProvider errorProvider;

    }
}
