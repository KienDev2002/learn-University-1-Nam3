using chuaTestL2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DeThiHK
{
    public partial class Form1 : Form
    {
             Database data = new Database();
            List<ChatLieu> list = new List<ChatLieu>();
        public Form1()
        {
            InitializeComponent();
            data.KetNoiCSDL();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fill();

        }

        private void fill()
        {
            dataGridView1.DataSource = data.DocBang("select * from tblChatLieu");
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                list.Add(new ChatLieu(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString()));
            }
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = data.DocBang("select * from tblHang");
            for (int i = 0; i < list.Count; i++)
            {
                cbbChatLieu.Items.Add(list[i].TenCL1);
            }
        }

        private void BtThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.DongKetNoiCSDL();
                this.Close();
            }
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = false;
            txtMa.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string machatlieu = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            for (int i = 0; i < list.Count; i++)
            {
                if (machatlieu == list[i].MaCL1)
                {
                    cbbChatLieu.Text = list[i].TenCL1;
                    break;
                }
            }
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtNhap.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtBan.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void BtSua_Click(object sender, EventArgs e)
        {
            if (ktra() == true)
            {
                string sql = "update tblHang set TenHang=N'" + txtTen.Text + "',MaChatLieu=N'" + cbbChatLieu.Text + "',GiaNhap='" + txtNhap.Text + "',GiaBan='" + txtBan.Text + "',SoLuong='" + txtSoLuong.Text + "' where MaHang=N'" + txtMa.Text + "'";
                data.CapNhatDuLieu(sql);
                fill();
            }
            //else
            //{
            //    MessageBox.Show("vui lòng nhập đầy đủ thông tin", "thông báo");
            //}
        }

        private void BtXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "")
                MessageBox.Show("Mời bạn chọn hàng cần xóa");
            else
            {
                if (MessageBox.Show("Bạn có chắc xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String sql = "delete from tblHang where MaHang=N'" + txtMa.Text + "'";
                    data.CapNhatDuLieu(sql);
                    fill();
                }
            }
        }
        private void BtThem_Click(object sender, EventArgs e)
        {
            bool check = true;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (txtMa.Text.Equals(dataGridView1.Rows[i].Cells[0].Value.ToString().Trim()))
                {
                    check = false;
                    MessageBox.Show("đã có mã này", "thông báo");
                    break;
                }
            }
            if (check == true)
            {
                if (ktra() == true)
                {
                    string sql = "insert into tblHang values(N'" + txtMa.Text + "',N'" + txtTen.Text + "',N'" + cbbChatLieu.Text + "',N'" + txtSoLuong.Text + "',N'" + txtNhap.Text + "',N'" + txtBan.Text + "')";
                    data.CapNhatDuLieu(sql);
                    fill();
                }
                //else
                //{
                //    MessageBox.Show("vui lòng nhập đầy đủ thông tin", "thông báo");
                //}

            }
        }

        private bool ktra()
        {
            double n1, n2,n3;
            bool check = true;
            if (txtMa.Text != "" && txtTen.Text != "" && cbbChatLieu.Text != "" && txtNhap.Text != "" && txtBan.Text != "" && txtSoLuong.Text != "")
            {
                check = true;
                
            }
            else
            {
                check = false;
                MessageBox.Show("Ban can nhap thong tin ");
            }
            if(txtSoLuong.Text!="" && (double.TryParse(txtSoLuong.Text, out n1) == true))
            {
                check = true;
            }
            else
            {
                check = false;
                MessageBox.Show("Ban can nhap so");
            }
            if (txtSoLuong.Text != "" && (double.TryParse(txtNhap.Text, out n2) == true))
            {
                check = true;
            }
            else
            {
                check = false;
                MessageBox.Show("Ban can nhap so");
            }
            if (txtSoLuong.Text != "" && (double.TryParse(txtSoLuong.Text, out n3) == true))
            {
                check = true;
            }
            else
            {
                check = false;
                MessageBox.Show("Ban can nhap so");
            }
            return check;
        }

        private void BtExport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) //TH có dữ liệu để ghi
            {
                //Khai báo và khởi tạo các đối tượng
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                //Định dạng chung
                Excel.Range tenCuaHang = (Excel.Range)exSheet.Cells[1, 1];
                tenCuaHang.Font.Size = 14;
                tenCuaHang.Font.Bold = true;
                tenCuaHang.Font.Color = Color.Blue;
                tenCuaHang.Value = "";

                Excel.Range dcCuaHang = (Excel.Range)exSheet.Cells[2, 1];
                dcCuaHang.Font.Size = 14;
                dcCuaHang.Font.Bold = true;
                dcCuaHang.Font.Color = Color.Blue;
                dcCuaHang.Value = "";

                Excel.Range dtCuaHang = (Excel.Range)exSheet.Cells[3, 1];
                dtCuaHang.Font.Size = 14;
                dtCuaHang.Font.Bold = true;
                dtCuaHang.Font.Color = Color.Blue;
                dtCuaHang.Value = "";


                Excel.Range header = (Excel.Range)exSheet.Cells[5, 2];
                exSheet.get_Range("B5:G5").Merge(true);
                header.Font.Size = 13;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "DANH SÁCH ĐIỂM CÁC MẶT HÀNG";

                //Định dạng tiêu đề bảng

                exSheet.get_Range("A7:E7").Font.Bold = true;
                exSheet.get_Range("A7:E7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A7").Value = "Mã Hàng";
                exSheet.get_Range("B7").Value = "Tên Hàng";
                exSheet.get_Range("C7").Value = "Chất Liệu";
                exSheet.get_Range("C7").ColumnWidth = 20;
                exSheet.get_Range("D7").Value = "Giá Nhập";
                exSheet.get_Range("E7").Value = "Giá Bán";
                exSheet.get_Range("F7").Value = "Số Lượng";

                //In dữ liệu
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    exSheet.get_Range("A" + (i + 8).ToString() + ":G" + (i + 8).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 8).ToString()).Value = dataGridView1.Rows[i].Cells[0].Value;
                    exSheet.get_Range("C" + (i + 8).ToString()).Value = dataGridView1.Rows[i].Cells[1].Value;
                    exSheet.get_Range("D" + (i + 8).ToString()).Value = dataGridView1.Rows[i].Cells[2].Value;
                    exSheet.get_Range("E" + (i + 8).ToString()).Value = dataGridView1.Rows[i].Cells[3].Value;
                    exSheet.get_Range("F" + (i + 8).ToString()).Value = dataGridView1.Rows[i].Cells[4].Value;
                }
                exSheet.Name = "Hàng Hóa";
                exBook.Activate(); //Kích hoạt file Excel
                //Thiết lập các thuộc tính của SaveFileDialog
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel Document(*.xls)|*.xls  |Word Document(*.doc) |*.doc|All files(*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.DefaultExt = ".xls";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    exBook.SaveAs(saveFileDialog1.FileName.ToString());//Lưu file Excel
                exApp.Quit();//Thoát khỏi ứng dụng
            }
            else
                MessageBox.Show("Không có danh sách hàng để in");
        }

        private void BtMoi_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = true;
            txtMa.Text = "";
            txtTen.Text = "";
            cbbChatLieu.Text = "";
            txtSoLuong.Text = "";
            txtNhap.Text = "";
            txtBan.Text = "";
            //txtTH.Text = "";
            //txtMH.Text = "";
            txtMa.Focus();
            fill();
        }

        //private void BtTim_Click(object sender, EventArgs e)
        //{
        //    string sql = "select * from tblHang where MaHang is not null ";
        //    if (txtMH.Text.Trim() != "")
        //    {
        //        sql += " and MaHang=N'" + txtMH.Text + "'";
        //    }
        //    if (txtTH.Text.Trim() != "")
        //    {
        //        sql += " and TenHang like '%" + txtTH.Text + "%'";
        //    }
        //    dataGridView1.DataSource = data.DocBang(sql);
        //    if (dataGridView1.RowCount == 0)
        //    {
        //        MessageBox.Show("Khong tim thay", "Thong bao");
        //    }
        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|Gif(*.jpg) |*.jpg|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "E:\\BaiGiang"; dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh để hiển thị";
            if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile(dlgOpen.FileName);
                // txtImg.Text = dlgOpen.FileName;
            }
            else MessageBox.Show("You clicked Cancel", "Open Dialog",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
