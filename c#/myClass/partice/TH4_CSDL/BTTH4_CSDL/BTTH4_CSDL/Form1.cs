using BTTH4_CSDL.database;
using BTTH4_CSDL.model;
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
using Syncfusion.XlsIO;

namespace BTTH4_CSDL
{
    public partial class frmMatHang : Form
    {
        public frmMatHang()
        {
            InitializeComponent();
        }

        Connection db = new Connection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\partice\\TH4_CSDL\\BTTH4_CSDL\\BTTH4_CSDL\\Database1.mdf\";Integrated Security=True");
   
        private void StateGroupBoxChiTiet(bool type)
        {
            gbChiTiet.Enabled = type;
        }


        private void StateButtonThemSuaXoa(bool type)
        {
            btnThem.Enabled = type;
            btnSua.Enabled = type;
            btnXoa.Enabled = type;
        }

      
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            dgvKetQua.DataSource = db.getTable("select * from SanPham");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.StateGroupBoxChiTiet(true);
            this.StateButtonThemSuaXoa(false);
            btnThem.Enabled = true;
            txtMaSP.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.StateGroupBoxChiTiet(true);
            this.StateButtonThemSuaXoa(false);
            btnSua.Enabled = true;
            txtMaSP.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.StateGroupBoxChiTiet(true);
            this.StateButtonThemSuaXoa(false);
            btnXoa.Enabled = true;
            txtMaSP.Enabled = false;
        }

        private bool isCheck()
        {
            if (txtMaSP.Text.Trim() == "")
            {
                MessageBox.Show("Mã sản phẩm không được đế trống");
                return false;
            }

            if (txtTenSP.Text.Trim() == "")
            {
                MessageBox.Show("Tên sản phẩm không được đế trống");
                return false;
            }

            if(dtpNgaySX.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sx không được lớn hơn ngày hiện tại");
                return false;
            }

            //tính xem ngày sx và ngày hh chênh nhau bao nhiêu ngày.
            TimeSpan diff = dtpNgayHH.Value.Subtract(dtpNgaySX.Value);

            if (diff.TotalDays < 30)
            {

                MessageBox.Show("Ngày hết hạn không được nhỏ hơn ngày sx 30 ngày!");
                return false;
            }

            if (txtDonVi.Text.Trim() == "")
            {
                MessageBox.Show("Đơn vị không được để trống!");
                return false;
            }

            if (txtDonGia.Text.Trim() == "")
            {
                MessageBox.Show("Đơn giá không được để trống!");
                return false;
            }

            return true;
        }


        private void reset()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            dtpNgaySX.Value = DateTime.Now;
            dtpNgayHH.Value = DateTime.Now;
            txtDonVi.Text = "";
            txtDonGia.Text = "";
            txtGhiChu.Text = "";
        }


        private SanPham sanPham()
        {
            string MaSP = txtMaSP.Text.Trim();
            string TenSP = txtTenSP.Text.Trim();
            string NgaySX = dtpNgaySX.Value.ToString("yyyy-MM-dd");
            string NgayHH = dtpNgayHH.Value.ToString("yyyy-MM-dd");
            string DonVi = txtDonVi.Text.Trim();
            string DonGia = txtDonGia.Text.Trim();
            string GhiChu = txtGhiChu.Text.Trim();

            return new SanPham(MaSP, TenSP, NgaySX, NgayHH, DonVi, DonGia, GhiChu);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled && isCheck())
            {
                SanPham sp = this.sanPham();

                string query = 
                    $"Insert into SanPham values('{sp.MaSP1}',N'{sp.TenSP1}','{sp.NgaySX1}','{sp.NgayHH1}','{sp.DonVi1}',{sp.DonGia1},N'{sp.GhiChu1}')";
                if (MessageBox.Show("Bạn có muốn thêm sản phẩm không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    try
                    {
                        db.Excute(query);
                        MessageBox.Show("Thêm thành công!");
                        frmMatHang_Load(sender, e);
                        reset();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi; " + ex.Message);
                    }
                   
                }
               
            }

            if (btnSua.Enabled && isCheck())
            {

               
                SanPham sp = this.sanPham();

                string query = $"update SanPham " +
                    $"set TenSP = N'{sp.TenSP1}' , " +
                    $"NgaySX = '{sp.NgaySX1}', " +
                    $"NgayHH = '{sp.NgayHH1}', " +
                    $"DonVi = '{sp.DonVi1}', " +
                    $"DonGia = {sp.DonGia1}, " +
                    $"GhiChu = N'{sp.GhiChu1}' " +
                    $"where MaSP = '{sp.MaSP1}'";

                if(MessageBox.Show("Bạn có sửa  sản phẩm không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information)== DialogResult.Yes){
                    try
                    {
                        db.Excute(query);
                        MessageBox.Show("Sửa thành công!");
                        frmMatHang_Load(sender, e);
                        reset();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi; " + ex.Message);
                    }

                }

            }
       
            if (btnXoa.Enabled)
            {

                SanPham sp = this.sanPham();

                string query = $"delete from SanPham " +
                    $"where MaSP = '{sp.MaSP1}' and " + 
                    $"TenSP = N'{sp.TenSP1}' and " +
                    $"NgaySX = '{sp.NgaySX1}' and " +
                    $"NgayHH = '{sp.NgayHH1}' and " +
                    $"DonVi = '{sp.DonVi1}' and " +
                    $"DonGia = {sp.DonGia1} and " +
                    $"GhiChu = N'{sp.GhiChu1}' ";

                if (MessageBox.Show($"Bạn có xóa sản phẩm có id là {sp.MaSP1} không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        db.Excute(query);
                        MessageBox.Show("Xóa thành công!");
                        frmMatHang_Load(sender, e);
                        reset();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi; " + ex.Message);
                    }

                }
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.StateGroupBoxChiTiet(false);
            this.StateButtonThemSuaXoa(true);
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtDonGia.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            
            if (!char.IsDigit(ch) && !char.IsDigit(ch) && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Text = dgvKetQua.SelectedRows[0].Cells[0].Value.ToString();
            txtTenSP.Text = dgvKetQua.SelectedRows[0].Cells[1].Value.ToString();
            dtpNgaySX.Value = DateTime.Parse(dgvKetQua.SelectedRows[0].Cells[2].Value.ToString());
            dtpNgayHH.Value = DateTime.Parse(dgvKetQua.SelectedRows[0].Cells[3].Value.ToString());
            txtDonVi.Text = dgvKetQua.SelectedRows[0].Cells[4].Value.ToString();    
            txtDonGia.Text = dgvKetQua.SelectedRows[0].Cells[5].Value.ToString();
            txtGhiChu.Text = dgvKetQua.SelectedRows[0].Cells[6].Value.ToString();
        
           
        }


        private void ExportExcel(DataTable dataTable , string path)
        {
            using(ExcelEngine exelEngine = new ExcelEngine())
            {
                IApplication application = exelEngine.Excel;

                // tạo 1 workBook
                IWorkbook workbook = application.Workbooks.Create(1);


                // sử dụng tạo worksheet đầu tiên
                IWorksheet worksheet = workbook.Worksheets[0];


                //nhập dữ liệu từ bảng vào file excel
                worksheet.ImportDataTable(dataTable, true, 1, 1);


                //show ra đầy đủ thông tin ko bị cắt.
                worksheet.UsedRange.AutofitColumns();

                //lưu workbook
                workbook.SaveAs(path);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export excel"
;           saveFileDialog.Filter = "Text file(*.xlsx)|*.xlsx|Word document(*.doc)|*.doc|All files(*.*)|*.*";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //tạo datatable để lưu vào cho excel
                    DataTable dataTable = db.getTable("select * from SanPham where DonGia< 300000");


                    ExportExcel(dataTable, saveFileDialog.FileName);
                    MessageBox.Show("Xuat file thanh cong");

                }

                catch(Exception ex)
                {
                    MessageBox.Show("lỗi: " + ex.Message);

                }
            }

        }

        private void dgvKetQua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTKTenSP.Text == "")
            {
                MessageBox.Show("Mời bạn nhập tên sản phẩm để tìm kiếm");
            }
            else
            {
                try
                {
                    string query = $"select * from SanPham where TenSP = N'{txtTKTenSP.Text}'";
                    dgvKetQua.DataSource = db.getTable(query);
                    if(dgvKetQua.Rows.Count == 0)
                    {
                        this.frmMatHang_Load(null,null);
                        throw new Exception ("Sản phẩm không có trong danh sách");
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm có trong danh sách");

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi; " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
}
