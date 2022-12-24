using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTTH4_CSDL.database;
using Microsoft.Reporting.WinForms;

namespace BTTH4_CSDL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Connection db = new Connection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\partice\\TH4_CSDL\\BTTH4_CSDL\\BTTH4_CSDL\\Database1.mdf\";Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "BTTH4_CSDL.Report.ReportSamPham.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSetBaoCaoSanPham";

                //gán giá trị của dataSource = bảng data (datatable)
                reportDataSource.Value = db.getTable("select * from SanPham where DonGia < 30000");
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }

            catch
            {

            }
        }
    }
}
