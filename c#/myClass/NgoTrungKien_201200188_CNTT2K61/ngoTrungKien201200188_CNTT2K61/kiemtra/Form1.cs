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


        ProcessDatabase db = new ProcessDatabase("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Dell Inspiron 5515\\Desktop\\NgoTrungKien_201200188_CNTT2K61\\ngoTrungKien201200188_CNTT2K61\\kiemtra\\Database1.mdf\";Integrated Security=True");

        public void resetValue()
        {
            txtMK.Text = "";
            txtTK.Text = "";
            txtDC.Text = "";
            txtDD.Text = "";
        }

        public void btnHideShow(bool state)
        {
            btnSua.Enabled = state;
            btnXoa.Enabled = state;
            btnThem.Enabled = !state;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.DocBang("select * from tblKhachHang");
            btnHideShow(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            // 2 dòng đầu là title và tên trường tùy ứng biến
            worksheet.get_Range("I9:M10").Font.Bold = true;

            //Danh sách gì thì viết thêm
            worksheet.get_Range("I9").Value = "Danh sách Khách Hàng";
            worksheet.get_Range("I9").Font.Size = 20;
            worksheet.get_Range("I9").Font.Color = Color.Red;

            //trộn title tùy ứng biến chữ
            worksheet.get_Range("I9:M9").Merge(true);

            //căn giữa tuy ứng biến từ đâu đến đâu cho phù hợp các trường
            worksheet.get_Range("I9:M40").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Trường số thứ tự
            worksheet.get_Range("I10").Value = "STT";
            worksheet.get_Range("I10").ColumnWidth = 10;

            //trường dữ liệu thứ nhất
            worksheet.get_Range("J10").Value = "Mã Khách Hàng";
            worksheet.get_Range("J10").ColumnWidth = 20;

            //trường dữ liệu thứ hai
            worksheet.get_Range("K10").Value = "Tên Khách Hàng";
            worksheet.get_Range("K10").ColumnWidth = 25;

            worksheet.get_Range("L10").Value = "Địa chỉ";
            worksheet.get_Range("L10").ColumnWidth = 25;

            worksheet.get_Range("M10").Value = "Điện thoại";
            worksheet.get_Range("M10").ColumnWidth = 25;
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
                worksheet.get_Range("L" + (i + 11).ToString()).Value = dataGridView1.Rows[i].Cells[2].Value;
                worksheet.get_Range("M" + (i + 11).ToString()).Value = dataGridView1.Rows[i].Cells[3].Value;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách để tìm!");

            }
            else
            {
                db.DocBang($"select * from tblKhachHang where TenKH = N'{txtTK.Text.Trim()}'");
                Form1_Load(sender, e);
                resetValue();
                btnHideShow(false);
                MessageBox.Show("Bạn đã tìm thành công");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtMK.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTK.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDC.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDD.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            btnHideShow(true);
            txtMK.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtTK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách!");
            }
            else
            {
                if(txtDC.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ!");
                }
                else
                {
                    if(txtDD.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập số điện thoại!");
                    }
                    else
                    {
                        if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            db.CapNhatDuLieu($"update tblKhachHang set TenKH = N'{txtTK.Text.Trim()}', DiaChi = N'{txtDD.Text.Trim()}', DienThoai = N'{txtDD.Text.Trim()}' where MaKH = N'{txtMK.Text.Trim()}'");
                            Form1_Load(sender, e);
                            resetValue();
                            btnHideShow(false);
                            MessageBox.Show("Bạn đã sửa thành công");
                        }
                       

                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.CapNhatDuLieu($"delete from tblKhachHang where MaKH = N'{txtMK.Text.Trim()}'");
                Form1_Load(sender, e);
                resetValue();
                btnHideShow(false);
                MessageBox.Show("Bạn đã xóa thành công");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách!");

            }
            else
            {

                if (txtTK.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tên khách!");
                }
                else
                {
                    if (txtDC.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập địa chỉ!");
                    }
                    else
                    {
                        if (txtDD.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập số điện thoại!");
                        }
                        else
                        {
                            DataTable dataTable = db.DocBang($"select * from tblKhachHang where MaKH = N'{txtMK.Text.Trim()}'");
                            if (dataTable.Rows.Count > 0)
                            {
                                MessageBox.Show("Mã chất liệu này đã tồn tại, bạn hãy nhập mã khác!");
                                txtMK.Focus();
                            }
                            else
                            {
                                db.CapNhatDuLieu($"insert into tblKhachHang values (N'{txtMK.Text.Trim()}' , N'{txtTK.Text.Trim()}', N'{txtDC.Text.Trim()}', N'{txtDD.Text.Trim()}')");
                                Form1_Load(sender, e);
                                resetValue();
                                btnHideShow(false);
                                MessageBox.Show("Bạn đã thêm thành công");

                            }

                        }
                    }
                }
            }

        }

        private void txtDD_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && !char.IsDigit(ch))
             {
               e.Handled = true;
             }


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                
                    this.Close();
                
            }
        }
    }
}
