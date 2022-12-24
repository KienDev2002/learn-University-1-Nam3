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

namespace DeThi1
{
    public partial class Form1 : Form
    {
        Database dtb = new Database();
        public Form1()
        {
            InitializeComponent();
        }
        private void ResetData()
        {
            txtTenHang.ResetText();
            txtMaHang.ResetText();
            txtSoLuong.ResetText();
            txtDonGiaNhap.ResetText();
            txtDonGiaBan.ResetText();
            txtGhiChu.ResetText();
            cboChatLieu.ResetText();
            pictureBox1.Visible = false;
            txtImg.ResetText();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = dtb.DocBang("select Mahang,Tenhang,h.Machatlieu,Soluong,Dongianhap,Dongiaban,Anh,ghichu from tblChatlieu cl join tblHang h on cl.MaChatLieu=h.Machatlieu");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Mã hàng";
            dataGridView1.Columns[1].HeaderText = "Tên hàng";
            dataGridView1.Columns[2].HeaderText = "Mã chất liệu";
            dataGridView1.Columns[3].HeaderText = "Số lượng";
            dataGridView1.Columns[4].HeaderText = "Giá nhập";
            dataGridView1.Columns[5].HeaderText = "Giá bán";
            dataGridView1.Columns[6].HeaderText = "Ảnh";
            dataGridView1.Columns[7].HeaderText = "Ghi chú";
            DataTable dtMaCL = dtb.DocBang("Select TenChatLieu from tblChatLieu");
            cboChatLieu.DataSource = dtMaCL;
            cboChatLieu.ValueMember = "TenChatLieu";
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         

            txtMaHang.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenHang.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString().Equals("CL1"))
            {
                cboChatLieu.Text = "Vang";
            }
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString().Equals("CL2"))
            {
                cboChatLieu.Text = "Bac";
            }
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString().Equals("CL3"))
            {
                cboChatLieu.Text = "Bach Kim";
            }
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString().Equals("CL4"))
            {
                cboChatLieu.Text = "Dong";
            }
            
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDonGiaNhap.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDonGiaBan.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtGhiChu.Text= dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtImg.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            pictureBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(txtImg.Text);
            // if (dataGridView1.CurrentRow.Cells[6].Value.ToString().Length != 0) ;
            //pictureBox1.Image = new Bitmap(dataGridView1.CurrentRow.Cells[7].Value.ToString());

        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            DataTable data = dtb.DocBang("select Mahang,Tenhang,h.Machatlieu,Soluong,Dongianhap,Dongiaban,anh,ghichu from tblChatlieu cl join tblHang h on cl.MaChatLieu=h.Machatlieu");
            if (data.Rows.Count > 0) //TH có dữ liệu để ghi
            {
                //Khai báo và khởi tạo các đối tượng 
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                Excel.Range header = (Excel.Range)exSheet.Cells[5, 2];
                exSheet.get_Range("B5:G5").Merge(true); header.Font.Size = 13;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "DANH SÁCH ";

                //Định dạng tiêu đề bảng 
                exSheet.get_Range("A7:G7").Font.Bold = true;
                exSheet.get_Range("A7:G7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A7").Value = "STT";
                exSheet.get_Range("B7").Value = "Mã hàng";
                exSheet.get_Range("B7").ColumnWidth = 20;
                exSheet.get_Range("C7").Value = "Tên hàng";
                exSheet.get_Range("C7").ColumnWidth = 20;
                exSheet.get_Range("D7").Value = "Mã CL";
                exSheet.get_Range("E7").Value = "Số lượng";
                exSheet.get_Range("E7").ColumnWidth = 20;
                exSheet.get_Range("F7").Value = "Giá nhập";
                exSheet.get_Range("G7").Value = "Giá bán";
                exSheet.get_Range("H7").Value = "Ghi chú";
                //In dữ liệu
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 8).ToString() + ":G" + (i + 8).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 8).ToString()).Value = data.Rows[i]["MaHang"].ToString();
                    exSheet.get_Range("C" + (i + 8).ToString()).Value = data.Rows[i]["TenHang"].ToString();
                    exSheet.get_Range("D" + (i + 8).ToString()).Value = data.Rows[i]["MaChatLieu"].ToString();
                    exSheet.get_Range("E" + (i + 8).ToString()).Value = data.Rows[i]["SoLuong"].ToString();
                    exSheet.get_Range("F" + (i + 8).ToString()).Value = data.Rows[i]["DonGiaNhap"].ToString();
                    exSheet.get_Range("G" + (i + 8).ToString()).Value = data.Rows[i]["DonGiaBan"].ToString();
                    exSheet.get_Range("H" + (i + 8).ToString()).Value = data.Rows[i]["GhiChu"].ToString();

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
                    MessageBox.Show("Xuất file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có danh sách hàng để in");
                }
            }
        }
        private bool ktdl()
        {
            if (txtMaHang.Text == "" || txtTenHang.Text == "" || cboChatLieu.Text == "" || txtSoLuong.Text == "" || txtDonGiaNhap.Text == "" || txtDonGiaBan.Text == "")
            {
                return false;
            }
            
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == txtMaHang.Text)
                {
                    return false;
                }
            return true;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (ktdl() == true)
            {

                sql += "insert into tblHang(Mahang,Tenhang,Machatlieu,Soluong,Dongianhap,Dongiaban,anh,ghichu) values ('" + txtMaHang.Text + "',N'" + txtTenHang.Text + "',(select MaChatLieu from tblChatlieu where TenChatLieu='" + cboChatLieu.Text + "'),'" + txtSoLuong.Text + "','" + txtDonGiaNhap.Text + "','" + txtDonGiaBan.Text + "','"+txtImg.Text +"','" + txtGhiChu.Text + "')";
                dtb.CapNhatDuLieu(sql);
                MessageBox.Show("Bạn đã thêm thành công");
                dataGridView1.DataSource = dtb.DocBang("select Mahang,Tenhang,h.Machatlieu,Soluong,Dongianhap,Dongiaban,anh,ghichu from tblChatlieu cl join tblHang h on cl.MaChatLieu=h.Machatlieu");
                ResetData();
            }
            
            else
            {
                MessageBox.Show("Kiểm tra lại dữ liệu nhập vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (dataGridView1.SelectedRows != null)
            {
                if (ktdl() == true)
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    sql = "update tblHang set Tenhang=N'" + txtTenHang.Text + "',Soluong=N'" + txtSoLuong.Text + "',Dongiaban=N'" + txtDonGiaNhap.Text + "',Dongianhap='" + txtDonGiaBan.Text + "',Ghichu='"+txtGhiChu+"' WHERE Mahang = N'" + txtMaHang.Text + "'";
                    ResetData();
                    dtb.CapNhatDuLieu(sql);
                    MessageBox.Show("Bạn đã cập nhật thành công");
                    //Xóa dữ liệu ở các ô nhập TextBox 
                    //Sau khi update cần lấy lại dữ liệu để hiển thị lên lưới             
                    dataGridView1.DataSource = dtb.DocBang("select Mahang,Tenhang,h.Machatlieu,Soluong,Dongianhap,Dongiaban,Anh,Ghichu from tblChatlieu cl join tblHang h on cl.MaChatLieu=h.Machatlieu");

                    
                   
                }
            }

        }

        private void BtnXua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có xóa hàng không ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtb.CapNhatDuLieu("DELETE FROM dbo.tblHang WHERE Mahang = N'" + txtMaHang.Text + "'");
                dtb.CapNhatDuLieu("DELETE FROM tblChitietHDBan WHERE Mahang = N'" + txtMaHang.Text + "'");
                dataGridView1.DataSource = dtb.DocBang("SELECT MaHang, Tenhang, tblChatlieu.Machatlieu, Soluong, Dongiaban, Dongianhap,Anh,Ghichu FROM dbo.tblHang, dbo.tblChatlieu WHERE dbo.tblHang.Machatlieu = dbo.tblChatlieu.MaChatLieu");
                this.ResetData();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|Gif(*.jpg) |*.jpg|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "E:\\BaiGiang"; dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh để hiển thị";
            if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile(dlgOpen.FileName);
                txtImg.Text = dlgOpen.FileName;
            }
            else MessageBox.Show("You clicked Cancel", "Open Dialog",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
    }
}
