namespace Netscape
{
    partial class UCCookies
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCookies = new System.Windows.Forms.TextBox();
            this.txtUserAgent = new System.Windows.Forms.TextBox();
            this.listCookies = new Netscape.KeywordBox(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 12);
            this.label2.TabIndex = 67;
            this.label2.Text = "网址（如果“包含”则注入cookies信息）";
            // 
            // txtUrl
            // 
            this.txtUrl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtUrl.Location = new System.Drawing.Point(17, 29);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUrl.MaxLength = 255;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUrl.Size = new System.Drawing.Size(272, 21);
            this.txtUrl.TabIndex = 68;
            this.txtUrl.Tag = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(14, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cookies:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(14, 339);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(353, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "此设置为高级选项，如不熟悉可跳过， 已添加的网址注入cookies";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(14, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "UserAgent：";
            // 
            // txtCookies
            // 
            this.txtCookies.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCookies.Location = new System.Drawing.Point(17, 116);
            this.txtCookies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCookies.Multiline = true;
            this.txtCookies.Name = "txtCookies";
            this.txtCookies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCookies.Size = new System.Drawing.Size(390, 51);
            this.txtCookies.TabIndex = 16;
            this.txtCookies.Tag = "Download folder";
            // 
            // txtUserAgent
            // 
            this.txtUserAgent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUserAgent.Location = new System.Drawing.Point(17, 72);
            this.txtUserAgent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserAgent.Name = "txtUserAgent";
            this.txtUserAgent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUserAgent.Size = new System.Drawing.Size(390, 21);
            this.txtUserAgent.TabIndex = 12;
            this.txtUserAgent.Tag = "Download folder";
            this.txtUserAgent.Text = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2" +
    ".0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C;" +
    " .NET4.0E)";
            // 
            // listCookies
            // 
            this.listCookies.FormattingEnabled = true;
            this.listCookies.HorizontalScrollbar = true;
            this.listCookies.ItemHeight = 12;
            this.listCookies.Location = new System.Drawing.Point(19, 198);
            this.listCookies.Name = "listCookies";
            this.listCookies.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listCookies.Size = new System.Drawing.Size(460, 124);
            this.listCookies.TabIndex = 66;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(413, 116);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 51);
            this.btnAdd.TabIndex = 69;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // UCCookies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.listCookies);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCookies);
            this.Controls.Add(this.txtUserAgent);
            this.Name = "UCCookies";
            this.Size = new System.Drawing.Size(506, 378);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCookies;
        private System.Windows.Forms.TextBox txtUserAgent;
        private KeywordBox listCookies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
