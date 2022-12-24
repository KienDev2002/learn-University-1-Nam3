using huongdan.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; 

namespace huongdan
{
    public partial class ExportExcel : Form
    {
        public ExportExcel()
        {
            InitializeComponent();
        }


        Connection db = new Connection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\learn\\basic\\exportExcel\\huongdan\\huongdan\\Database1.mdf\";Integrated Security=True");


        private void exportExcel()
        {

        }

        private void ExportExcel_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.getTable("select * from tblChatLieu");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if(MessageBox.Show("Bạn có xóa không","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && !s.Equals(""))
            {
                string sql = $"delete from tblChatLieu where MaCL = N'{s}'";
                db.Excute(sql);
                ExportExcel_Load(null, null);
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];


            exSheet.get_Range("B3:C4").Font.Bold = true;
            exSheet.get_Range("B3").Value = "Danh sách chất liệu";
            exSheet.get_Range("A4").Value = "STT";
            exSheet.get_Range("B4").Value = "Mã chất liệu";
            exSheet.get_Range("C4").Value = "Mã chất liệu";
            int n = dataGridView1.Rows.Count;
            for (int i = 0; i< n; i++)
            {
                exSheet.get_Range("A" + (i + 5).ToString()).Value = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 5).ToString()).Value = dataGridView1.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 5).ToString()).Value = dataGridView1.Rows[i].Cells[1].Value;
            }
            exSheet.Activate();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "export(*.xlsx)|*.xlsx";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(saveFileDialog.FileName.ToString());
            }
        }
    }
}
