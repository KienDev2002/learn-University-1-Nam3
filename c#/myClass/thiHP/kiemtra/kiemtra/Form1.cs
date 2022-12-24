using kiemtra.model;
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

namespace kiemtra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        ProcessDatabase db = new ProcessDatabase("");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            // 2 dòng đầu là title và tên trường tùy ứng biến
            worksheet.get_Range("I9:K10").Font.Bold = true;

            //Danh sách gì thì viết thêm
            worksheet.get_Range("I9").Value = "Danh sách ";
            worksheet.get_Range("I9").Font.Size = 20;
            worksheet.get_Range("I9").Font.Color = Color.Red;

            //trộn title tùy ứng biến chữ
            worksheet.get_Range("I9:K9").Merge(true);

            //căn giữa tuy ứng biến từ đâu đến đâu cho phù hợp các trường
            worksheet.get_Range("I9:K40").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Trường số thứ tự
            worksheet.get_Range("I10").Value = "STT";
            worksheet.get_Range("I10").ColumnWidth = 10;

            //trường dữ liệu thứ nhất
            worksheet.get_Range("J10").Value = "";
            worksheet.get_Range("J10").ColumnWidth = 20;

            //trường dữ liệu thứ hai
            worksheet.get_Range("K10").Value = "";
            worksheet.get_Range("K10").ColumnWidth = 25;


            //trường thứ 3,4,5 nếu có
            //......


            int n = dataGridView1.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                //vị trí chứ cái giống với trường ở trên nhưng số tăng lên 1 vd I10 -> I11
                worksheet.get_Range("I" + (i + 11).ToString()).Value = (i + 1).ToString();

                //vị trí chứ cái giống với trường ở trên nhưng số tăng lên 1 
                worksheet.get_Range("J" + (i + 11).ToString()).Value = dataGridView1.Rows[i].Cells[0].Value;
                worksheet.get_Range("K" + (i + 11).ToString()).Value = dataGridView1.Rows[i].Cells[1].Value;
            }

            worksheet.Activate();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "fileExcel(*.xlsx)|*.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                worksheet.SaveAs(saveFileDialog.FileName.ToString());
                MessageBox.Show("Lưu file thành công");
            }

        }
    }
}
