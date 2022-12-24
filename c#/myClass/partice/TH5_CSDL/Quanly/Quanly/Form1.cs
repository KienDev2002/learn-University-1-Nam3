using Quanly.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.XlsIO;

namespace Quanly
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        connection db = new connection("");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExportExcel(DataTable dataTable, string path)
        {
            using (ExcelEngine exelEngine = new ExcelEngine())
            {
                IApplication application = exelEngine.Excel;

       
                IWorkbook workbook = application.Workbooks.Create(1);


          
                IWorksheet worksheet = workbook.Worksheets[0];


       
                worksheet.ImportDataTable(dataTable, true, 1, 1);


     
                worksheet.UsedRange.AutofitColumns();

                workbook.SaveAs(path);
            }
        }
    }
}
