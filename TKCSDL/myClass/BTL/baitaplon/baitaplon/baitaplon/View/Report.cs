
using baitaplon.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon.View
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            menuStrip2.Cursor = Cursors.Hand;
        }

        bool isMatch;
        bool isPlayer;

        ProcessConnect db = new ProcessConnect("Data Source=DESKTOP-OSRNAUL\\SQLEXPRESS;Initial Catalog=QLGiaiBongNHA;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Report_Load(object sender, EventArgs e)
        {

            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void matchResultInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbSelect.Visible = true;

            cbSelect.Items.Clear();
            cbSelect.Focus();

            lbCBSelect.Text = "Mã trận đấu";
            DataTable dt = db.getTable("select MaTD from TranDau");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbSelect.Items.Add(dt.Rows[i]["MaTD"].ToString());
            }
            MessageBox.Show("Mời bạn chọn mã trận đấu");
            isMatch = true;
            isPlayer = false;

        }

        private void playerListReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbSelect.Visible = true;

            cbSelect.Items.Clear();
            cbSelect.Focus();
            lbCBSelect.Text = "Mã đội bóng";
            DataTable dt = db.getTable("select MaDoi from DoiBong");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbSelect.Items.Add(dt.Rows[i]["MaDoi"].ToString());
            }
            MessageBox.Show("Mời bạn chọn mã đội bóng");
            isPlayer = true;
            isMatch = false;

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void cbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbSelect.SelectedIndex != -1)
            {

                if (isMatch == true && isPlayer == false)
                {
                    try
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportEmbeddedResource = "baitaplon.Reports.MatchResult.rdlc";
                        ReportDataSource reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "MatchResult";

                        string maTD = cbSelect.SelectedItem.ToString();

                        reportDataSource.Value = db.getTable($"select * from TranDau where MaTD = N'{maTD}'");
                        reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                        this.reportViewer1.RefreshReport();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (isMatch == false && isPlayer == true)
                {

                    try
                    {
                        reportViewer1.LocalReport.DataSources.Clear();

                        reportViewer1.LocalReport.ReportEmbeddedResource = "baitaplon.Reports.PlayerList.rdlc";
                        ReportDataSource reportDataSource = new ReportDataSource();
                        reportDataSource.Name = "playerList";

                        string maDB = cbSelect.SelectedItem.ToString();

                        reportDataSource.Value = db.getTable($"select * from CauThu where MaDoi = N'{maDB}'");
                        reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                        this.reportViewer1.RefreshReport();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

        }

        private void listOfThreePlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbSelect.Items.Clear();
            lbCBSelect.Text = "";
            cbSelect.Visible = false;
            isPlayer = false;
            isMatch = false;

            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "baitaplon.Reports.TopThreePlayer.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "TopThreePlayer";


                reportDataSource.Value = db.getTable($"select top(3) with ties MaCT,TenCT,MaViTri,NgaySinh,SoAo,SoBanThang,SoTheVang,SoTheDo,MaQuocTich,SoLanRaSan,Anh,MaDoi from CauThu order by SoBanThang desc");
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
