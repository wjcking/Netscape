namespace Netscape
{
    partial class AddExtractInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.rbContent = new System.Windows.Forms.RadioButton();
            this.rbLinks = new System.Windows.Forms.RadioButton();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnHandle = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabSplitType = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtStart = new Netscape.TextboxAdvanced(this.components);
            this.txtLast = new Netscape.TextboxAdvanced(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtRegExGroup = new Netscape.TextboxAdvanced(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtRegEx = new Netscape.TextboxAdvanced(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.link1 = new Netscape.Link(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabSplitType.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtName.Location = new System.Drawing.Point(42, 102);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtName.Size = new System.Drawing.Size(293, 21);
            this.txtName.TabIndex = 3;
            this.txtName.Tag = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(19, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 12);
            this.label4.TabIndex = 78;
            this.label4.Text = "标签名（不填写则自动生成）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(25, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 79;
            this.label2.Text = "开始字符串";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(245, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 80;
            this.label16.Text = "结束字符串";
            // 
            // rbContent
            // 
            this.rbContent.AutoSize = true;
            this.rbContent.Location = new System.Drawing.Point(272, 48);
            this.rbContent.Name = "rbContent";
            this.rbContent.Size = new System.Drawing.Size(167, 16);
            this.rbContent.TabIndex = 2;
            this.rbContent.TabStop = true;
            this.rbContent.Text = "提取内容（放到一个字段）";
            this.rbContent.UseVisualStyleBackColor = true;
            // 
            // rbLinks
            // 
            this.rbLinks.AutoSize = true;
            this.rbLinks.Checked = true;
            this.rbLinks.Location = new System.Drawing.Point(42, 48);
            this.rbLinks.Name = "rbLinks";
            this.rbLinks.Size = new System.Drawing.Size(221, 16);
            this.rbLinks.TabIndex = 1;
            this.rbLinks.TabStop = true;
            this.rbLinks.Text = "提取链接(提取内容设置为一个链接）";
            this.rbLinks.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(309, 363);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(62, 35);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnHandle_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(377, 363);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 35);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "追加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnHandle_Click);
            // 
            // btnHandle
            // 
            this.btnHandle.Location = new System.Drawing.Point(445, 363);
            this.btnHandle.Name = "btnHandle";
            this.btnHandle.Size = new System.Drawing.Size(62, 35);
            this.btnHandle.TabIndex = 11;
            this.btnHandle.Text = "关闭";
            this.btnHandle.UseVisualStyleBackColor = true;
            this.btnHandle.Click += new System.EventHandler(this.btnHandle_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 78;
            this.label1.Text = "请输入正则表达式：";
            // 
            // tabSplitType
            // 
            this.tabSplitType.Controls.Add(this.tabPage1);
            this.tabSplitType.Controls.Add(this.tabPage2);
            this.tabSplitType.Location = new System.Drawing.Point(21, 139);
            this.tabSplitType.Name = "tabSplitType";
            this.tabSplitType.SelectedIndex = 0;
            this.tabSplitType.Size = new System.Drawing.Size(490, 207);
            this.tabSplitType.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.txtStart);
            this.tabPage1.Controls.Add(this.txtLast);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(482, 181);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "前后截取";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtStart
            // 
            this.txtStart.AllowDrop = true;
            this.txtStart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtStart.Location = new System.Drawing.Point(27, 41);
            this.txtStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStart.MaxLength = 255;
            this.txtStart.Multiline = true;
            this.txtStart.Name = "txtStart";
            this.txtStart.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStart.Size = new System.Drawing.Size(190, 113);
            this.txtStart.TabIndex = 5;
            this.txtStart.Tag = " ";
            // 
            // txtLast
            // 
            this.txtLast.AllowDrop = true;
            this.txtLast.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLast.Location = new System.Drawing.Point(247, 41);
            this.txtLast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLast.MaxLength = 255;
            this.txtLast.Multiline = true;
            this.txtLast.Name = "txtLast";
            this.txtLast.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLast.Size = new System.Drawing.Size(193, 113);
            this.txtLast.TabIndex = 6;
            this.txtLast.Tag = " ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtRegExGroup);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtRegEx);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(482, 181);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "正则截取";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtRegExGroup
            // 
            this.txtRegExGroup.AllowDrop = true;
            this.txtRegExGroup.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtRegExGroup.Location = new System.Drawing.Point(43, 115);
            this.txtRegExGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRegExGroup.MaxLength = 255;
            this.txtRegExGroup.Multiline = true;
            this.txtRegExGroup.Name = "txtRegExGroup";
            this.txtRegExGroup.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRegExGroup.Size = new System.Drawing.Size(412, 39);
            this.txtRegExGroup.TabIndex = 88;
            this.txtRegExGroup.Tag = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(14, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 78;
            this.label5.Text = "正则表达式分组：";
            // 
            // txtRegEx
            // 
            this.txtRegEx.AllowDrop = true;
            this.txtRegEx.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtRegEx.Location = new System.Drawing.Point(43, 40);
            this.txtRegEx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRegEx.MaxLength = 255;
            this.txtRegEx.Multiline = true;
            this.txtRegEx.Name = "txtRegEx";
            this.txtRegEx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRegEx.Size = new System.Drawing.Size(412, 39);
            this.txtRegEx.TabIndex = 88;
            this.txtRegEx.Tag = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(19, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 12);
            this.label3.TabIndex = 85;
            this.label3.Text = "提取类型（链接放入队列，内容导出数据）";
            // 
            // link1
            // 
            this.link1.AccessibleName = "httppostget.exe";
            this.link1.AutoSize = true;
            this.link1.Location = new System.Drawing.Point(19, 374);
            this.link1.Name = "link1";
            this.link1.Size = new System.Drawing.Size(113, 12);
            this.link1.TabIndex = 89;
            this.link1.TabStop = true;
            this.link1.Text = "打开网页源代码工具";
            // 
            // AddExtractInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 417);
            this.Controls.Add(this.tabSplitType);
            this.Controls.Add(this.link1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbContent);
            this.Controls.Add(this.rbLinks);
            this.Controls.Add(this.btnHandle);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddExtractInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提取或截取";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabSplitType.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextboxAdvanced txtLast;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton rbContent;
        private TextboxAdvanced txtStart;
        private System.Windows.Forms.RadioButton rbLinks;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnHandle;
        private Link link1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private  TextboxAdvanced  txtRegEx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabSplitType;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private TextboxAdvanced txtRegExGroup;
        private System.Windows.Forms.Label label5;
    }
}