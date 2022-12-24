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
namespace examine
{
    public partial class Form1 : Form
    {
        ProcessDataBase dataBase = new ProcessDataBase();
        public Form1()
        {
            InitializeComponent();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtgv.DataSource = dataBase.DocBang("SELECT MaHang, Tenhang, tblChatlieu.Machatlieu, Soluong, Dongiaban, Dongianhap FROM dbo.tblHang, dbo.tblChatlieu WHERE dbo.tblHang.Machatlieu = dbo.tblChatlieu.MaChatLieu");
            comboBox1.DataSource = dataBase.DocBang("select TenChatLieu from tblChatLieu");
            comboBox1.DisplayMember = "TenChatLieu";
            comboBox1.ValueMember = "TenChatLieu";
            cbbMaCL.DataSource = dataBase.DocBang("select MaChatLieu from tblChatLieu");
            cbbMaCL.DisplayMember = "MaChatLieu";
            cbbMaCL.ValueMember = "MaChatLieu";
        }
        private void clearTextBox()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtSoLuong.Text = "";
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            comboBox1.SelectedIndex = -1;
        }
        private void BtnEx_Click(object sender, EventArgs e)
        {
            DataTable dt = dataBase.DocBang("select * from tblHang");
            if (dt.Rows.Count > 0) //TH có dữ liệu để ghi
            {
                //Khai báo và khởi tạo các đối tượng 
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                //Định dạng chung
                Excel.Range tenCuaHang = (Excel.Range)exSheet.Cells[1, 1];
                tenCuaHang.Font.Size = 12;
                tenCuaHang.Font.Bold = true;
                tenCuaHang.Font.Color = Color.Blue;
                tenCuaHang.Value = "KẾT QUẢ XUẤT FILE";

                
                Excel.Range header = (Excel.Range)exSheet.Cells[5, 2];
                exSheet.get_Range("B5:G5").Merge(true); header.Font.Size = 13;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "BÁO CÁO DANH SÁCH HÀNG ";

                //Định dạng tiêu đề bảng 
                exSheet.get_Range("A7:E7").Font.Bold = true;
                exSheet.get_Range("A7:G7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A7").Value = "Mã hàng";
                exSheet.get_Range("B7").Value = "Tên hàng";
                exSheet.get_Range("B7").ColumnWidth = 20;
                exSheet.get_Range("C7").Value = "Số lượng";
                exSheet.get_Range("D7").Value = "Giá nhập";
                exSheet.get_Range("E7").Value = "Giá bán";
               

                //In dữ liệu
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 8).ToString() + ":G" + (i + 8).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 8).ToString()).Value = dt.Rows[i]["MaHang"].ToString();
                    exSheet.get_Range("B" + (i + 8).ToString()).Value = dt.Rows[i]["TenHang"].ToString();
                    exSheet.get_Range("C" + (i + 8).ToString()).Value = dt.Rows[i]["SoLuong"].ToString();
                    exSheet.get_Range("D" + (i + 8).ToString()).Value = dt.Rows[i]["DonGiaNhap"].ToString();
                    exSheet.get_Range("E" + (i + 8).ToString()).Value = dt.Rows[i]["DonGiaBan"].ToString();
                    
                }

                exSheet.Name = "Hang"; exBook.Activate();
                //Kích hoạt file Excel 
                //Thiết lập các thuộc tính của SaveFileDialog
                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.Filter = "Excel Document(*.xls)|*.xls  |Word Document(*.doc) |*.doc|All files(*.*)|*.*";
                dlgSave.FilterIndex = 1;
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = ".xls";
                if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    exBook.SaveAs(dlgSave.FileName.ToString());//Lưu file Excel     
                    exApp.Quit();//Thoát khỏi ứng dụng 
                    MessageBox.Show("Xuất báo cáo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có danh sách hàng để in");
                }
            }
        }

        private void TxtMaHang_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void TxtTenHang_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void TxtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text == "" || txtTenHang.Text == "" || txtSoLuong.Text == "" || txtGiaBan.Text == "" || txtGiaNhap.Text == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn cần điền đủ dữ liệu!");
            }
            else
            {
                dataBase.CapNhatDuLieu("INSERT [dbo].[tblHang] ([Mahang], [Tenhang], [Machatlieu], [Soluong], [Dongianhap], [Dongiaban]) VALUES (N'"+txtMaHang.Text+ "', N'" + txtTenHang.Text + "', N'" + cbbMaCL.Text + "'," +Int32.Parse( txtSoLuong.Text) + ", " + Int32.Parse(txtGiaNhap.Text) + ", " + Int32.Parse(txtGiaBan.Text) + ")");
                dtgv.DataSource = dataBase.DocBang("select * from tblHang");
            }
            this.clearTextBox();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbMaCL.SelectedIndex = comboBox1.SelectedIndex;
            }
            catch
            {

            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có sửa hàng không ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.clearTextBox();
            }
        }

        private void Dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHang.Text = dtgv.CurrentRow.Cells["Mahang"].Value.ToString();
            txtTenHang.Text = dtgv.CurrentRow.Cells["Tenhang"].Value.ToString();
            txtSoLuong.Text = dtgv.CurrentRow.Cells["Soluong"].Value.ToString();
            txtGiaBan.Text = dtgv.CurrentRow.Cells["DonGiaban"].Value.ToString();
            txtGiaNhap.Text = dtgv.CurrentRow.Cells["Dongianhap"].Value.ToString();
        }
        private void updateDTGV()
        {
            dtgv.DataSource = dataBase.DocBang("SELECT MaHang, Tenhang, tblChatlieu.Machatlieu, Soluong, Dongiaban, Dongianhap FROM dbo.tblHang, dbo.tblChatlieu WHERE dbo.tblHang.Machatlieu = dbo.tblChatlieu.MaChatLieu");
        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có xóa hàng không ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dataBase.CapNhatDuLieu("DELETE FROM dbo.tblHang WHERE Mahang = N'" + txtMaHang.Text + "'");
                dataBase.CapNhatDuLieu("DELETE FROM tblChitietHDBan WHERE Mahang = N'" + txtMaHang.Text + "'");
                dtgv.DataSource = dataBase.DocBang("SELECT MaHang, Tenhang, tblChatlieu.Machatlieu, Soluong, Dongiaban, Dongianhap FROM dbo.tblHang, dbo.tblChatlieu WHERE dbo.tblHang.Machatlieu = dbo.tblChatlieu.MaChatLieu");
                this.clearTextBox();
            }
            
        }
    }
}
