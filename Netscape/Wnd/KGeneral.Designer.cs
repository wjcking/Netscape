namespace Netscape
{
    partial class KGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KGeneral));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHandle = new System.Windows.Forms.Button();
            this.txtPool = new System.Windows.Forms.TextBox();
            this.numMaxKB = new System.Windows.Forms.NumericUpDown();
            this.lbMB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbInterval = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.link1 = new Netscape.Link(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxKB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHandle);
            this.groupBox1.Controls.Add(this.txtPool);
            this.groupBox1.Controls.Add(this.numMaxKB);
            this.groupBox1.Controls.Add(this.lbMB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbInterval);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Location = new System.Drawing.Point(27, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 243);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统参数设置";
            // 
            // btnHandle
            // 
            this.btnHandle.Location = new System.Drawing.Point(344, 182);
            this.btnHandle.Name = "btnHandle";
            this.btnHandle.Size = new System.Drawing.Size(75, 23);
            this.btnHandle.TabIndex = 4;
            this.btnHandle.Text = "...";
            this.btnHandle.UseVisualStyleBackColor = true;
            this.btnHandle.Click += new System.EventHandler(this.btnHandle_Click);
            // 
            // txtPool
            // 
            this.txtPool.Location = new System.Drawing.Point(28, 184);
            this.txtPool.Name = "txtPool";
            this.txtPool.Size = new System.Drawing.Size(300, 21);
            this.txtPool.TabIndex = 3;
            this.txtPool.TextChanged += new System.EventHandler(this.txtPool_TextChanged);
            // 
            // numMaxKB
            // 
            this.numMaxKB.Location = new System.Drawing.Point(28, 58);
            this.numMaxKB.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numMaxKB.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numMaxKB.Name = "numMaxKB";
            this.numMaxKB.Size = new System.Drawing.Size(120, 21);
            this.numMaxKB.TabIndex = 2;
            this.numMaxKB.Value = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numMaxKB.ValueChanged += new System.EventHandler(this.numMaxKB_ValueChanged);
            this.numMaxKB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numMaxKB_KeyUp);
            this.numMaxKB.Leave += new System.EventHandler(this.numMaxKB_ValueChanged);
            // 
            // lbMB
            // 
            this.lbMB.AutoSize = true;
            this.lbMB.Location = new System.Drawing.Point(195, 60);
            this.lbMB.Name = "lbMB";
            this.lbMB.Size = new System.Drawing.Size(17, 12);
            this.lbMB.TabIndex = 1;
            this.lbMB.Text = "MB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "超过多少KB不下载(1024KB=1MB)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "自定义下载库(系统重启)";
            // 
            // lbInterval
            // 
            this.lbInterval.AutoSize = true;
            this.lbInterval.Location = new System.Drawing.Point(17, 94);
            this.lbInterval.Name = "lbInterval";
            this.lbInterval.Size = new System.Drawing.Size(143, 12);
            this.lbInterval.TabIndex = 1;
            this.lbInterval.Text = "输出窗口时间间隔(毫秒):";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(19, 118);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(400, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // link1
            // 
            this.link1.AccessibleName = "config.ini";
            this.link1.AutoSize = true;
            this.link1.Location = new System.Drawing.Point(398, 20);
            this.link1.Name = "link1";
            this.link1.Size = new System.Drawing.Size(77, 12);
            this.link1.TabIndex = 1;
            this.link1.TabStop = true;
            this.link1.Text = "打开配置文件";
            // 
            // KGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 310);
            this.Controls.Add(this.link1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统参数";
            this.Load += new System.EventHandler(this.KGeneral_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxKB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Link link1;
        private System.Windows.Forms.Label lbInterval;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.NumericUpDown numMaxKB;
        private System.Windows.Forms.Label lbMB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHandle;
        private System.Windows.Forms.TextBox txtPool;
        private System.Windows.Forms.Label label1;
    }
}