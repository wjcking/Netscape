namespace Netscape
{
    partial class UcUrlKeyword
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
            this.listUrlKeyword = new Netscape.KeywordBox(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // listUrlKeyword
            // 
            this.listUrlKeyword.FormattingEnabled = true;
            this.listUrlKeyword.ItemHeight = 12;
            this.listUrlKeyword.Location = new System.Drawing.Point(15, 99);
            this.listUrlKeyword.Name = "listUrlKeyword";
            this.listUrlKeyword.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listUrlKeyword.Size = new System.Drawing.Size(482, 208);
            this.listUrlKeyword.TabIndex = 61;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(422, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 60;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 57;
            this.label1.Text = "Url筛选名称(不填则自动生成）";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(13, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(281, 12);
            this.label15.TabIndex = 57;
            this.label15.Text = "地址包含关键字(如 cctv,abc,hao 多个用逗号分开)";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtName.Location = new System.Drawing.Point(15, 71);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtName.Size = new System.Drawing.Size(235, 21);
            this.txtName.TabIndex = 58;
            this.txtName.Tag = " ";
            // 
            // txtKeywords
            // 
            this.txtKeywords.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtKeywords.Location = new System.Drawing.Point(15, 28);
            this.txtKeywords.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKeywords.MaxLength = 255;
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKeywords.Size = new System.Drawing.Size(384, 21);
            this.txtKeywords.TabIndex = 58;
            this.txtKeywords.Tag = " ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // UcUrlKeyword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listUrlKeyword);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtKeywords);
            this.Name = "UcUrlKeyword";
            this.Size = new System.Drawing.Size(536, 365);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private KeywordBox listUrlKeyword;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
