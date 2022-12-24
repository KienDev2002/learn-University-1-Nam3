using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Excel=Microsoft.Office.Interop.Excel;

namespace kiemtralan_3
{
    public partial class kiemtralan3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OSRNAUL\SQLEXPRESS;Initial Catalog=Quanlybanhang;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter dap;
        DataSet ds;
        
        public kiemtralan3()
        { 
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            code.Text = "";
            name.Text = "";
            address.Text = "";
            mobile.Text = "";
        }

        private void Kiemtralan3_Load(object sender, EventArgs e)
        {
            con.Open();
            string sql = " SELECT * FROM tblKhach ";
            this.LoadData(sql);
            dataGridView1.DataSource = ds.Tables[0];
            code.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            name.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            address.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            mobile.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            con.Close();
        }
        private void LoadData(string sql)
        {
            ds = new DataSet();
            dap = new SqlDataAdapter(sql, con);
            dap.Fill(ds);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(checkBeforeSave())
            {
                if(checkIsvalid())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(" insert into tblKhach values " +
                        "(N'" + code.Text + "',N'" + name.Text + "'," +
                        "N'" + address.Text + "'," +
                        "N'" +mobile.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    LoadData("SELECT * FROM tblKhach");
                    dataGridView1.DataSource = ds.Tables[0];
                    MessageBox.Show("thêm thành công");
                    con.Close();
                } else
                {
                    MessageBox.Show("valid Code", "ERROR", MessageBoxButtons.OK);
                }
            } else
            {
                MessageBox.Show("loi nhap!", "ERROR", MessageBoxButtons.OK);
            }
        }
        public Boolean checkBeforeSave()
        {
            if(string.IsNullOrEmpty(code.Text))
            {
                code.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(name.Text))
            {
                name.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(address.Text))
            {
                address.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(mobile.Text))
            {
                mobile.Focus();
                return false;
            }
            return true;
        }
        public Boolean checkIsvalid()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(code.Text.Equals(row.Cells["MaKhach"].Value))
                {
                    return false;
                }
            }
            return true;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo",
                MessageBoxButtons.YesNo);
            if (h == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0) //TH có dữ liệu để ghi
            {
                //Khai báo và khởi tạo các đối tượng
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                //Định dạng chung
                
               
                Excel.Range header = (Excel.Range)exSheet.Cells[5, 2];
                exSheet.get_Range("B5:G5").Merge(true);
                header.Font.Size = 13;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "DANH SÁCH KHÁCH HÀNG";

                //Định dạng tiêu đề bảng

                exSheet.get_Range("A7:E7").Font.Bold = true;
                exSheet.get_Range("A7:G7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A7").Value = "STT";
                exSheet.get_Range("B7").Value = "Mã khách";
                exSheet.get_Range("C7").Value = "Tên Khách";
                exSheet.get_Range("C7").ColumnWidth = 20;
                exSheet.get_Range("D7").Value = "Địa chỉ";
                exSheet.get_Range("E7").Value = "Số Điện thoại";
                
                //In dữ liệu
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 8).ToString() + ":G" + (i + 8).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 8).ToString()).Value = dt.Rows[i]["MaKhach"].ToString();
                    exSheet.get_Range("C" + (i + 8).ToString()).Value = dt.Rows[i]["TenKhach"].ToString();
                    exSheet.get_Range("D" + (i + 8).ToString()).Value = dt.Rows[i]["Diachi"].ToString();
                    exSheet.get_Range("E" + (i + 8).ToString()).Value = dt.Rows[i]["Dienthoai"].ToString();
                    
                }

                exSheet.Name = "KHang";
                exBook.Activate(); //Kích hoạt file Excel
                //Thiết lập các thuộc tính của SaveFileDialog
                dlgSave.Filter = "Excel Document(*.xls)|*.xls  |Word Document(*.doc) |*.doc|All files(*.*)|*.*";
                dlgSave.FilterIndex = 1;
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = ".xls";
                if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    exBook.SaveAs(dlgSave.FileName.ToString());//Lưu file Excel
                exApp.Quit();//Thoát khỏi ứng dụng
            }
            else
                MessageBox.Show("Không có danh sách hàng để in");

        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            code.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            address.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            mobile.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void Ignore_Click(object sender, EventArgs e)
        {
            code.Text = "";
            name.Text = "";
            address.Text = "";
            mobile.Text = "";
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc chắn muốn xoas không?", "Thông báo",
                MessageBoxButtons.YesNo);
            if (h == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" delete from tblKhach where MaKhach='"+code .Text +"'", con);
                cmd.ExecuteNonQuery();
                LoadData("SELECT * FROM tblKhach");
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
                MessageBox.Show("ban da xoa thanh cong");
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            //string query = "UPDATE FROM KHACHHANG SET TENKHACH = N'"+txtTenKhach.Text+"', DIACHI = N'"+txtDiaChi.Text+"', DIENTHOAI = N'"+txtDienThoai.Text+"' WHERE MAKHACH = '"+txtMaKhach.Text+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(" UPDATE tblKhach SET " +
                "TENKHACH = N'" + name.Text + "'," +
                " Diachi = N'" + address.Text + "', " +
                "DIENTHOAI = N'" +mobile.Text + "' " +
                "WHERE MAKHACH = '" + code.Text + "'", con);
            cmd.ExecuteNonQuery();
            LoadData("SELECT * FROM tblKhach");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            MessageBox.Show("ban da sửa thanh cong");
        }
    }
}
