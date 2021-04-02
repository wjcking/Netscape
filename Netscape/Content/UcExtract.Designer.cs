namespace Netscape
{
    partial class UcExtract
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSource = new Netscape.TextboxAdvanced(this.components);
            this.btnPreview = new System.Windows.Forms.Button();
            this.combAddress = new Netscape.KCombo(this.components);
            this.link1 = new Netscape.Link(this.components);
            this.listExtractOptions = new Netscape.ListViewAdvanced(this.components);
            this.cLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cExtractType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSplitType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cLast = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lnkHandle = new Netscape.Link(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSource);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.combAddress);
            this.groupBox1.Location = new System.Drawing.Point(256, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 395);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网页地址与预览";
            // 
            // txtSource
            // 
            this.txtSource.AllowDrop = true;
            this.txtSource.Location = new System.Drawing.Point(6, 48);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSource.Size = new System.Drawing.Size(457, 341);
            this.txtSource.TabIndex = 3;
            this.txtSource.Text = "使用提示：\r\n1）在浏览之前请添加截取设置，否则直接网页源代码\r\n2）输入测试页网址点击预览，根据截取内容显示。\r\n3）出现乱码请选择右上角编码";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(414, 20);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(49, 23);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // combAddress
            // 
            this.combAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.combAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combAddress.FormattingEnabled = true;
            this.combAddress.Location = new System.Drawing.Point(6, 22);
            this.combAddress.Name = "combAddress";
            this.combAddress.Size = new System.Drawing.Size(402, 20);
            this.combAddress.TabIndex = 1;
            // 
            // link1
            // 
            this.link1.AccessibleName = "httppostget.exe";
            this.link1.AutoSize = true;
            this.link1.Location = new System.Drawing.Point(606, 429);
            this.link1.Name = "link1";
            this.link1.Size = new System.Drawing.Size(113, 12);
            this.link1.TabIndex = 78;
            this.link1.TabStop = true;
            this.link1.Text = "打开网页源代码工具";
            // 
            // listExtractOptions
            // 
            this.listExtractOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cLabel,
            this.cExtractType,
            this.cSplitType,
            this.cStart,
            this.cLast});
            this.listExtractOptions.FullRowSelect = true;
            this.listExtractOptions.GridLines = true;
            this.listExtractOptions.Location = new System.Drawing.Point(21, 41);
            this.listExtractOptions.Name = "listExtractOptions";
            this.listExtractOptions.Size = new System.Drawing.Size(229, 373);
            this.listExtractOptions.TabIndex = 77;
            this.listExtractOptions.UseCompatibleStateImageBehavior = false;
            this.listExtractOptions.View = System.Windows.Forms.View.Details;
            // 
            // cLabel
            // 
            this.cLabel.Text = "标签名";
            this.cLabel.Width = 92;
            // 
            // cExtractType
            // 
            this.cExtractType.Text = "提取类型";
            this.cExtractType.Width = 70;
            // 
            // cSplitType
            // 
            this.cSplitType.Text = "截取方式";
            // 
            // cStart
            // 
            this.cStart.Text = "开始字符";
            this.cStart.Width = 65;
            // 
            // cLast
            // 
            this.cLast.Text = "结束字符";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 76;
            this.label1.Text = "标签与截取";
            // 
            // lnkHandle
            // 
            this.lnkHandle.AutoSize = true;
            this.lnkHandle.Location = new System.Drawing.Point(221, 17);
            this.lnkHandle.Name = "lnkHandle";
            this.lnkHandle.Size = new System.Drawing.Size(29, 12);
            this.lnkHandle.TabIndex = 78;
            this.lnkHandle.TabStop = true;
            this.lnkHandle.Text = "添加";
            this.lnkHandle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHandle_LinkClicked);
            // 
            // UcExtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.link1);
            this.Controls.Add(this.lnkHandle);
            this.Controls.Add(this.listExtractOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UcExtract";
            this.Size = new System.Drawing.Size(733, 458);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private ListViewAdvanced listExtractOptions;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ColumnHeader cLabel;
        private System.Windows.Forms.ColumnHeader cStart;
        private System.Windows.Forms.ColumnHeader cLast;
        private System.Windows.Forms.ColumnHeader cExtractType;
        private TextboxAdvanced txtSource;
        private Link lnkHandle;
        private Link link1;
        private System.Windows.Forms.ColumnHeader cSplitType;
        private KCombo combAddress;
    }
}
