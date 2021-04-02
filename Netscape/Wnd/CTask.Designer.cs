namespace Netscape
{
    partial class CTask
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.lvTask = new Netscape.ListViewAdvanced(this.components);
            this.headerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerTaskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerInternal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerNotSave = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taskContextMenu = new Netscape.TaskContextMenu(this.components);
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(263, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 750;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // lvTask
            // 
            this.lvTask.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerID,
            this.headerTaskName,
            this.headerStatus,
            this.headerInternal,
            this.headerNotSave});
            this.lvTask.ContextMenuStrip = this.taskContextMenu;
            this.lvTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTask.FullRowSelect = true;
            this.lvTask.GridLines = true;
            this.lvTask.Location = new System.Drawing.Point(0, 0);
            this.lvTask.MultiSelect = false;
            this.lvTask.Name = "lvTask";
            this.lvTask.Size = new System.Drawing.Size(340, 457);
            this.lvTask.TabIndex = 5;
            this.lvTask.UseCompatibleStateImageBehavior = false;
            this.lvTask.View = System.Windows.Forms.View.Details;
            this.lvTask.DoubleClick += new System.EventHandler(this.lvTask_DoubleClick);
            this.lvTask.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvTask_KeyUp);
            this.lvTask.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvTask_MouseClick);
            // 
            // headerID
            // 
            this.headerID.Text = "最小保存";
            this.headerID.Width = 63;
            // 
            // headerTaskName
            // 
            this.headerTaskName.Text = "任务名称";
            this.headerTaskName.Width = 231;
            // 
            // headerStatus
            // 
            this.headerStatus.Text = "状态";
            this.headerStatus.Width = 40;
            // 
            // headerInternal
            // 
            this.headerInternal.Text = "仅内链接";
            // 
            // headerNotSave
            // 
            this.headerNotSave.Text = "不保存文档";
            // 
            // taskContextMenu
            // 
            this.taskContextMenu.Name = "taskContextMenu";
            this.taskContextMenu.Size = new System.Drawing.Size(242, 214);
            this.taskContextMenu.TaskID = 0;
            this.taskContextMenu.ClickedTask += new Netscape.TaskMenuHandler(this.taskContextMenu_MenuItemClicked);
            this.taskContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.taskContextMenu_Opening);
            // 
            // CTask
            // 
            this.ClientSize = new System.Drawing.Size(340, 457);
            this.Controls.Add(this.lvTask);
            this.Controls.Add(this.toolStrip1);
            this.HideOnClose = true;
            this.Name = "CTask";
            this.ShowHint = Lv.Docking.DockState.DockLeft;
            this.ShowIcon = false;
            this.TabText = "任务列表";
            this.Text = "任务列表";
            this.Shown += new System.EventHandler(this.CTask_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ColumnHeader headerID;
        private System.Windows.Forms.ColumnHeader headerTaskName;
        private System.Windows.Forms.ColumnHeader headerStatus;
        public ListViewAdvanced lvTask;
        private TaskContextMenu taskContextMenu;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.ColumnHeader headerInternal;
        private System.Windows.Forms.ColumnHeader headerNotSave;

    }
}