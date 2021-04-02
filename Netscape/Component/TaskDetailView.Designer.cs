namespace Netscape
{
    partial class TaskDetailView
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("任务信息", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("地址包含关键字", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("内容关键字", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("我的最爱（优先级）", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("过滤掉的文件类型", System.Windows.Forms.HorizontalAlignment.Left);
            this.SuspendLayout();
            // 
            // TaskDetailView
            // 
            listViewGroup1.Header = "任务信息";
            listViewGroup1.Name = "lvgTaskDetails";
            listViewGroup2.Header = "地址包含关键字";
            listViewGroup2.Name = "lvgUrlKeywords";
            listViewGroup3.Header = "内容关键字";
            listViewGroup3.Name = "lvgKeywords";
            listViewGroup4.Header = "我的最爱（优先级）";
            listViewGroup4.Name = "lvgPiroity";
            listViewGroup5.Header = "过滤掉的文件类型";
            listViewGroup5.Name = "lvgFilter";
            this.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
            this.ResumeLayout(false);

        }

        #endregion
    }
}
