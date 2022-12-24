using QLBanDienThoai.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanDienThoai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Connection db = new Connection("Data Source=DESKTOP-OSRNAUL\\SQLEXPRESS;Initial Catalog=QLBanDienThoai;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            CbbMaKH();
            CbbMaNV();
            CbbMaDH();
            CbbMaSP();
            ShowHD();
        }

        private void ShowHD()
        {

            dgvCTHDB.DataSource = db.DocBang("select * from ChiTietHDB");
            dgvHDB.DataSource = db.DocBang("select * from HoaDonBan");
        }

        private void CbbMaKH()
        {
            DataTable dt  = db.DocBang("select MaKH from KhachHang");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbMaKhachHang.Items.Add(dt.Rows[i]["MaKH"].ToString());
            }

        }

        private void CbbMaNV()
        {
            DataTable dt = db.DocBang("select MaNV from NhanVien");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbMaNVien.Items.Add(dt.Rows[i]["MaNV"].ToString());
            }
        }


        private void CbbMaDH()
        {
            DataTable dt = db.DocBang("select MaDH from DonDatHang");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbMaDonHang.Items.Add(dt.Rows[i]["MaDH"].ToString());
            }
        }

        private void CbbMaSP()
        {
            DataTable dt = db.DocBang("select MaSP from SanPham");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbMaSP.Items.Add(dt.Rows[i]["MaSP"].ToString());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ResetValueHDB()
        {
            txtSoHDB.Text = "";
            txtNgayBan.Text = "";
            cbbMaKhachHang.Text = "";
            cbbMaNVien.Text = "";
            cbbMaDonHang.Text = "";
            txtHTTT.Text = "";


        }
         private void ResetValueCTHDB()
          {
                txtSoHDBCTHDB.Text = "";
                cbbMaSP.Text = "";
                txtSL.Text = "";

          }

            private void button2_Click(object sender, EventArgs e)
        {
            if(txtSoHDB.Text == "")
            {
                MessageBox.Show("Mời bạn nhập SoHDB!");
            }
            else
            {
                if(txtNgayBan.Text == "")
                {
                    MessageBox.Show("Mời bạn nhập ngày bán!");

                }
                else
                {
                    if (cbbMaKhachHang.Text == "")
                    {
                        MessageBox.Show("Mời bạn chọn khách hàng!");

                    }
                    else
                    {
                        if(cbbMaNVien.Text == "")
                        {
                            MessageBox.Show("Mời bạn chọn nhân viên!");

                        }
                        else
                        {
                            if (cbbMaDonHang.Text == "")
                            {
                                MessageBox.Show("Mời bạn chọn mã đơn hàng!");

                            }
                            else
                            {
                                if(txtHTTT.Text == "")
                                {
                                    MessageBox.Show("Mời bạn nhập hình thức thanh toán!");

                                }
                                else
                                {
                                    db.CapNhatDuLieu($"insert into HoaDonBan(SoHDB,NgayBan,HinhThucThanhToan,MaKH,MaNV,MaDH)" +
                                        $"values (N'{txtSoHDB.Text.Trim()}' , '{txtNgayBan.Value}' , N'{txtHTTT.Text.Trim()}' , N'{cbbMaKhachHang.Text.Trim()}'" +
                                        $", N'{cbbMaNVien.Text.Trim()}', N'{cbbMaDonHang.Text.Trim()}')"
                                        );

                                    ShowHD();

                                    MessageBox.Show("Bạn đã thêm hóa đơn bán thành công!");
                                    ResetValueHDB();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSoHDB.Text == "")
            {
                MessageBox.Show("Mời bạn nhập SoHDB để tìm kiếm!");

            }
            else
            {
                DataTable dt = db.DocBang($"select * from HoaDonBan where SoHDB = '{txtSoHDB.Text.Trim()}'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Số HDB có trong HĐB");
                }
                else
                {
                    MessageBox.Show("Số HDB không có trong HĐB");

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtSoHDBCTHDB.Text == "")
            {
                MessageBox.Show("Mời bạn nhập SoHDB!");
            }
            else
            {
                if (cbbMaSP.Text == "")
                {
                    MessageBox.Show("Mời bạn nhập sản phẩm!");

                }
                else
                {
                    if (txtSL.Text == "")
                    {
                        MessageBox.Show("Mời bạn nhập số lượng!");

                    }
                    else
                    {

                        try
                        {
                            SqlCommand cmd = new SqlCommand();
                            SqlConnection sqlConnect = new SqlConnection("Data Source=DESKTOP-OSRNAUL\\SQLEXPRESS;Initial Catalog=QLBanDienThoai;Integrated Security=True");
                

                            cmd.Connection = sqlConnect;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "procedure4";

                            cmd.Parameters.Add("@SoHDB", SqlDbType.NVarChar).Value = txtSoHDBCTHDB.Text.Trim();
                            cmd.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = cbbMaSP.Text.Trim();
                            cmd.Parameters.Add("@SLBan", SqlDbType.Int).Value = int.Parse(txtSL.Text.Trim());
                            sqlConnect.Open();
                            cmd.ExecuteNonQuery();
                            sqlConnect.Close();
                            MessageBox.Show("Bạn đã thêm cthdb thành công!");
                            ShowHD();
                            ResetValueCTHDB();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thêm cthdb thất bại " + ex.Message);
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
