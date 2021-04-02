namespace Netscape
{
    partial class ACrawler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ACrawler));
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.btnFolder = new System.Windows.Forms.Button();
            this.btnRedirect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkInsertUKey = new System.Windows.Forms.CheckBox();
            this.chkFilterAll = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.connectionTimeout = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numMinFileSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.threadsCount = new System.Windows.Forms.NumericUpDown();
            this.sleepTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNotSave = new System.Windows.Forms.CheckBox();
            this.cbInternal = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lbFolder = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.tabUrlKeywords = new System.Windows.Forms.TabPage();
            this.lbKeyword = new System.Windows.Forms.Label();
            this.tabHtmlKeyword = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.tabExtract = new System.Windows.Forms.TabPage();
            this.tabHttpHeaders = new System.Windows.Forms.TabPage();
            this.tabPriority = new System.Windows.Forms.TabPage();
            this.tabFilter = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.drpUnicode = new Netscape.KCombo(this.components);
            this.listPreference = new Netscape.MimeBox(this.components);
            this.ucUrlKeyword1 = new Netscape.UcUrlKeyword();
            this.ucHtmlKeywords1 = new Netscape.UCHtmlKeywords();
            this.ucExtract1 = new Netscape.UcExtract();
            this.ucCookies1 = new Netscape.UCCookies();
            this.ucPriority = new Netscape.UCPriority();
            this.ucFilter = new Netscape.UCFilter();
            this.tabControlSettings.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleepTime)).BeginInit();
            this.tabUrlKeywords.SuspendLayout();
            this.tabHtmlKeyword.SuspendLayout();
            this.tabExtract.SuspendLayout();
            this.tabHttpHeaders.SuspendLayout();
            this.tabPriority.SuspendLayout();
            this.tabFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlSettings
            // 
            resources.ApplyResources(this.tabControlSettings, "tabControlSettings");
            this.tabControlSettings.Controls.Add(this.tabBasic);
            this.tabControlSettings.Controls.Add(this.tabUrlKeywords);
            this.tabControlSettings.Controls.Add(this.tabHtmlKeyword);
            this.tabControlSettings.Controls.Add(this.tabExtract);
            this.tabControlSettings.Controls.Add(this.tabHttpHeaders);
            this.tabControlSettings.Controls.Add(this.tabPriority);
            this.tabControlSettings.Controls.Add(this.tabFilter);
            this.tabControlSettings.HotTrack = true;
            this.tabControlSettings.Multiline = true;
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Tag = " ";
            this.tabControlSettings.SelectedIndexChanged += new System.EventHandler(this.tabBasic_Click);
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.btnFolder);
            this.tabBasic.Controls.Add(this.btnRedirect);
            this.tabBasic.Controls.Add(this.groupBox1);
            this.tabBasic.Controls.Add(this.cbNotSave);
            this.tabBasic.Controls.Add(this.cbInternal);
            this.tabBasic.Controls.Add(this.label1);
            this.tabBasic.Controls.Add(this.label11);
            this.tabBasic.Controls.Add(this.txtDescription);
            this.tabBasic.Controls.Add(this.lbFolder);
            this.tabBasic.Controls.Add(this.txtUrl);
            this.tabBasic.Controls.Add(this.txtDownloadFolder);
            resources.ApplyResources(this.tabBasic, "tabBasic");
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.UseVisualStyleBackColor = true;
            this.tabBasic.Click += new System.EventHandler(this.tabBasic_Click);
            // 
            // btnFolder
            // 
            resources.ApplyResources(this.btnFolder, "btnFolder");
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnRedirect
            // 
            resources.ApplyResources(this.btnRedirect, "btnRedirect");
            this.btnRedirect.Name = "btnRedirect";
            this.btnRedirect.UseVisualStyleBackColor = true;
            this.btnRedirect.Click += new System.EventHandler(this.Button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listPreference);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.chkInsertUKey);
            this.groupBox1.Controls.Add(this.chkFilterAll);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.connectionTimeout);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.numMinFileSize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.threadsCount);
            this.groupBox1.Controls.Add(this.sleepTime);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Name = "label9";
            // 
            // chkInsertUKey
            // 
            resources.ApplyResources(this.chkInsertUKey, "chkInsertUKey");
            this.chkInsertUKey.Checked = true;
            this.chkInsertUKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInsertUKey.Name = "chkInsertUKey";
            this.chkInsertUKey.UseVisualStyleBackColor = true;
            // 
            // chkFilterAll
            // 
            resources.ApplyResources(this.chkFilterAll, "chkFilterAll");
            this.chkFilterAll.Checked = true;
            this.chkFilterAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAll.Name = "chkFilterAll";
            this.chkFilterAll.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // connectionTimeout
            // 
            this.connectionTimeout.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.connectionTimeout, "connectionTimeout");
            this.connectionTimeout.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.connectionTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.connectionTimeout.Name = "connectionTimeout";
            this.connectionTimeout.Tag = "Request timeout";
            this.connectionTimeout.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // numMinFileSize
            // 
            this.numMinFileSize.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.numMinFileSize, "numMinFileSize");
            this.numMinFileSize.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMinFileSize.Name = "numMinFileSize";
            this.numMinFileSize.Tag = "Request timeout";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Tag = "Sleep connect time";
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // threadsCount
            // 
            this.threadsCount.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.threadsCount, "threadsCount");
            this.threadsCount.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.threadsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadsCount.Name = "threadsCount";
            this.threadsCount.Tag = "Threads count";
            this.threadsCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // sleepTime
            // 
            this.sleepTime.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.sleepTime, "sleepTime");
            this.sleepTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.sleepTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sleepTime.Name = "sleepTime";
            this.sleepTime.Tag = "";
            this.sleepTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cbNotSave
            // 
            resources.ApplyResources(this.cbNotSave, "cbNotSave");
            this.cbNotSave.Name = "cbNotSave";
            this.cbNotSave.UseVisualStyleBackColor = true;
            // 
            // cbInternal
            // 
            resources.ApplyResources(this.cbInternal, "cbInternal");
            this.cbInternal.Checked = true;
            this.cbInternal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInternal.Name = "cbInternal";
            this.cbInternal.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Name = "label1";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Name = "label11";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Tag = "Download folder";
            // 
            // lbFolder
            // 
            resources.ApplyResources(this.lbFolder, "lbFolder");
            this.lbFolder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbFolder.Name = "lbFolder";
            // 
            // txtUrl
            // 
            this.txtUrl.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.txtUrl, "txtUrl");
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Tag = "Download folder";
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.txtDownloadFolder, "txtDownloadFolder");
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Tag = "Download folder";
            // 
            // tabUrlKeywords
            // 
            this.tabUrlKeywords.Controls.Add(this.lbKeyword);
            this.tabUrlKeywords.Controls.Add(this.ucUrlKeyword1);
            resources.ApplyResources(this.tabUrlKeywords, "tabUrlKeywords");
            this.tabUrlKeywords.Name = "tabUrlKeywords";
            this.tabUrlKeywords.UseVisualStyleBackColor = true;
            // 
            // lbKeyword
            // 
            resources.ApplyResources(this.lbKeyword, "lbKeyword");
            this.lbKeyword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbKeyword.Name = "lbKeyword";
            // 
            // tabHtmlKeyword
            // 
            this.tabHtmlKeyword.Controls.Add(this.label13);
            this.tabHtmlKeyword.Controls.Add(this.ucHtmlKeywords1);
            resources.ApplyResources(this.tabHtmlKeyword, "tabHtmlKeyword");
            this.tabHtmlKeyword.Name = "tabHtmlKeyword";
            this.tabHtmlKeyword.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Name = "label13";
            // 
            // tabExtract
            // 
            this.tabExtract.Controls.Add(this.ucExtract1);
            resources.ApplyResources(this.tabExtract, "tabExtract");
            this.tabExtract.Name = "tabExtract";
            this.tabExtract.UseVisualStyleBackColor = true;
            // 
            // tabHttpHeaders
            // 
            this.tabHttpHeaders.Controls.Add(this.ucCookies1);
            resources.ApplyResources(this.tabHttpHeaders, "tabHttpHeaders");
            this.tabHttpHeaders.Name = "tabHttpHeaders";
            this.tabHttpHeaders.UseVisualStyleBackColor = true;
            // 
            // tabPriority
            // 
            this.tabPriority.Controls.Add(this.ucPriority);
            resources.ApplyResources(this.tabPriority, "tabPriority");
            this.tabPriority.Name = "tabPriority";
            this.tabPriority.UseVisualStyleBackColor = true;
            // 
            // tabFilter
            // 
            this.tabFilter.Controls.Add(this.ucFilter);
            resources.ApplyResources(this.tabFilter, "tabFilter");
            this.tabFilter.Name = "tabFilter";
            this.tabFilter.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Name = "label6";
            // 
            // txtTaskName
            // 
            this.txtTaskName.BackColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.txtTaskName, "txtTaskName");
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Tag = "Download folder";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Button_Click);
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.Button_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // drpUnicode
            // 
            this.drpUnicode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpUnicode.FormattingEnabled = true;
            this.drpUnicode.Items.AddRange(new object[] {
            resources.GetString("drpUnicode.Items"),
            resources.GetString("drpUnicode.Items1"),
            resources.GetString("drpUnicode.Items2"),
            resources.GetString("drpUnicode.Items3"),
            resources.GetString("drpUnicode.Items4"),
            resources.GetString("drpUnicode.Items5"),
            resources.GetString("drpUnicode.Items6"),
            resources.GetString("drpUnicode.Items7"),
            resources.GetString("drpUnicode.Items8"),
            resources.GetString("drpUnicode.Items9"),
            resources.GetString("drpUnicode.Items10"),
            resources.GetString("drpUnicode.Items11"),
            resources.GetString("drpUnicode.Items12"),
            resources.GetString("drpUnicode.Items13"),
            resources.GetString("drpUnicode.Items14"),
            resources.GetString("drpUnicode.Items15"),
            resources.GetString("drpUnicode.Items16"),
            resources.GetString("drpUnicode.Items17"),
            resources.GetString("drpUnicode.Items18"),
            resources.GetString("drpUnicode.Items19"),
            resources.GetString("drpUnicode.Items20"),
            resources.GetString("drpUnicode.Items21"),
            resources.GetString("drpUnicode.Items22"),
            resources.GetString("drpUnicode.Items23"),
            resources.GetString("drpUnicode.Items24"),
            resources.GetString("drpUnicode.Items25"),
            resources.GetString("drpUnicode.Items26"),
            resources.GetString("drpUnicode.Items27"),
            resources.GetString("drpUnicode.Items28"),
            resources.GetString("drpUnicode.Items29"),
            resources.GetString("drpUnicode.Items30"),
            resources.GetString("drpUnicode.Items31"),
            resources.GetString("drpUnicode.Items32"),
            resources.GetString("drpUnicode.Items33"),
            resources.GetString("drpUnicode.Items34"),
            resources.GetString("drpUnicode.Items35"),
            resources.GetString("drpUnicode.Items36"),
            resources.GetString("drpUnicode.Items37"),
            resources.GetString("drpUnicode.Items38")});
            resources.ApplyResources(this.drpUnicode, "drpUnicode");
            this.drpUnicode.Name = "drpUnicode";
            this.drpUnicode.SelectedIndexChanged += new System.EventHandler(this.drpUnicode_SelectedIndexChanged);
            // 
            // listPreference
            // 
            this.listPreference.FormattingEnabled = true;
            resources.ApplyResources(this.listPreference, "listPreference");
            this.listPreference.Name = "listPreference";
            this.listPreference.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPreference.TaskID = 0;
            // 
            // ucUrlKeyword1
            // 
            resources.ApplyResources(this.ucUrlKeyword1, "ucUrlKeyword1");
            this.ucUrlKeyword1.Name = "ucUrlKeyword1";
            this.ucUrlKeyword1.TaskID = 0;
            // 
            // ucHtmlKeywords1
            // 
            resources.ApplyResources(this.ucHtmlKeywords1, "ucHtmlKeywords1");
            this.ucHtmlKeywords1.Name = "ucHtmlKeywords1";
            this.ucHtmlKeywords1.TaskID = 0;
            // 
            // ucExtract1
            // 
            resources.ApplyResources(this.ucExtract1, "ucExtract1");
            this.ucExtract1.Name = "ucExtract1";
            this.ucExtract1.TaskID = 0;
            // 
            // ucCookies1
            // 
            resources.ApplyResources(this.ucCookies1, "ucCookies1");
            this.ucCookies1.Name = "ucCookies1";
            this.ucCookies1.TaskID = 0;
            // 
            // ucPriority
            // 
            resources.ApplyResources(this.ucPriority, "ucPriority");
            this.ucPriority.Name = "ucPriority";
            this.ucPriority.TaskID = 0;
            // 
            // ucFilter
            // 
            resources.ApplyResources(this.ucFilter, "ucFilter");
            this.ucFilter.Name = "ucFilter";
            this.ucFilter.TaskID = 0;
            // 
            // ACrawler
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.drpUnicode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControlSettings);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.label6);
            this.Name = "ACrawler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ACrawler_FormClosing);
            this.Shown += new System.EventHandler(this.ACrawler_Shown);
            this.tabControlSettings.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleepTime)).EndInit();
            this.tabUrlKeywords.ResumeLayout(false);
            this.tabUrlKeywords.PerformLayout();
            this.tabHtmlKeyword.ResumeLayout(false);
            this.tabHtmlKeyword.PerformLayout();
            this.tabExtract.ResumeLayout(false);
            this.tabHttpHeaders.ResumeLayout(false);
            this.tabPriority.ResumeLayout(false);
            this.tabFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabFilter;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.Label lbFolder;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.TabPage tabPriority;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label label12;
        private KCombo drpUnicode;
        private System.Windows.Forms.CheckBox cbNotSave;
        private System.Windows.Forms.CheckBox cbInternal;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private UCPriority ucPriority;
        private UCFilter ucFilter;
        private System.Windows.Forms.TabPage tabHttpHeaders;
        private System.Windows.Forms.TabPage tabHtmlKeyword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown connectionTimeout;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numMinFileSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown threadsCount;
        private System.Windows.Forms.NumericUpDown sleepTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabUrlKeywords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private UcUrlKeyword ucUrlKeyword1;
        private UCHtmlKeywords ucHtmlKeywords1;
        private System.Windows.Forms.Label label9;
        private MimeBox listPreference;
        private System.Windows.Forms.CheckBox chkInsertUKey;
        private System.Windows.Forms.CheckBox chkFilterAll;
        private System.Windows.Forms.Label lbKeyword;
        private System.Windows.Forms.Label label13;
        private UCCookies ucCookies1;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Button btnRedirect;
        private System.Windows.Forms.TabPage tabExtract;
        private UcExtract ucExtract1;


    }
}