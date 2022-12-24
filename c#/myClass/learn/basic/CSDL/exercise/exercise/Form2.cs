using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using exercise.model;
using Microsoft.Reporting.WinForms;

namespace exercise
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Connection db = new Connection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\learn\\basic\\CSDL\\exercise\\exercise\\Database1.mdf\";Integrated Security=True");


        private void Form2_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "exercise.report.Report1.rdlc";


            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSetBaoCaoChatLieu";

            //gán giá trị của dataSource = bảng data (datatable)
            reportDataSource.Value = db.getTable("select * from ChatLieu");
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();

        }
    }
}
