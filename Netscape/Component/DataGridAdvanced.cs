using System.ComponentModel;
using System.Windows.Forms;
 
using System.Drawing;

namespace Netscape
{
     /// <summary>
     /// 
     /// </summary>
    public partial class DataGridAdvanced : DataGridView
    { 
        private int rowIndex = 0;

        public DataGridAdvanced()
        {
            InitializeComponent();
            // EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            //  MultiSelect = false;

        }

        /// <summary>
        /// 根据题型邦定列
        /// </summary>
        public void BindCheckBox()
        {
            DataGridViewCheckBoxColumn cChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            cChk.Name = "cChk";
            cChk.HeaderText = "选择";
            cChk.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            Columns.Insert(0, cChk);
        }




        public DataGridAdvanced(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void DataGridAdvanced_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                            e.RowBounds.Location.Y,
                                            RowHeadersWidth - 4,

                                              e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                                 RowHeadersDefaultCellStyle.Font,
                                  rectangle,
                                 RowHeadersDefaultCellStyle.ForeColor,
                                  TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void DataGridAdvanced_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;

            rowIndex = e.RowIndex;

            if (Columns[e.ColumnIndex].Name == "cbtnSubjectDetail")
            {

            }
        }

        private void DataGridAdvanced_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            if (Columns[e.ColumnIndex].Name == "cChk")
            {
                for (int i = 0; i < Rows.Count; i++)
                {

                    MessageBox.Show(Rows[i].Cells["cChk"].Value.ToString());
                }
            }
        }


        private void DataGridAdvanced_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle)
                return;

            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex < 0)
                return;

            DataGridViewCell cell = Rows[e.RowIndex].Cells[e.ColumnIndex];

        }
    }
}
