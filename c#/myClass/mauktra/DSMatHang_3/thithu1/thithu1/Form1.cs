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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;


namespace thithu1
{
    public partial class Form1 : Form
    {
        OpenFileDialog fileDialog = new OpenFileDialog();
        ProcessDataBase dtBase = new ProcessDataBase();
        string thumuc = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn thoát không?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btThem.Image = Image.FromFile("C:\\Users\\Thao\\Desktop\\thithu1\\thithu1\\bin\\Debug\\Button\\Them.jpg");
            btThem.ImageAlign = ContentAlignment.MiddleRight;
            btThem.TextAlign = ContentAlignment.MiddleLeft;

            btSua.Image = Image.FromFile("C:\\Users\\Thao\\Desktop\\thithu1\\thithu1\\bin\\Debug\\Button\\Sua.jpg");
            btSua.ImageAlign = ContentAlignment.MiddleRight;
            btSua.TextAlign = ContentAlignment.MiddleLeft;

            btXoa.Image = Image.FromFile("C:\\Users\\Thao\\Desktop\\thithu1\\thithu1\\bin\\Debug\\Button\\Xoa.jpg");
            btXoa.ImageAlign = ContentAlignment.MiddleRight;
            btXoa.TextAlign = ContentAlignment.MiddleLeft;

            btThoat.Image = Image.FromFile("C:\\Users\\Thao\\Desktop\\thithu1\\thithu1\\bin\\Debug\\Button\\Thoat.jpg");
            btThoat.ImageAlign = ContentAlignment.MiddleRight;
            btThoat.TextAlign = ContentAlignment.MiddleLeft;

            string sql = "select * from tblhang";
            DataTable dataTable = new DataTable();
            dataTable = dtBase.DocBang(sql);
            dtgvDSHangHoa.DataSource = dataTable;
            dtgvDSHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlDataReader reader = dtBase.command("select tenchatlieu from tblchatlieu").ExecuteReader();
            if (reader.HasRows)
            {
                // Đọc kết quả
                while (reader.Read())
                {
                    cbbChatlieu.Items.Add(reader[0].ToString());
                }
            }
        }

        private void dtgvDSHangHoa_Click(object sender, EventArgs e)
        {
            txtmahang.Text = dtgvDSHangHoa.CurrentRow.Cells[0].Value.ToString();
            txttenhang.Text = dtgvDSHangHoa.CurrentRow.Cells[1].Value.ToString();
            SqlDataReader reader = dtBase.command("select tenchatlieu from tblchatlieu where machatlieu = '" + dtgvDSHangHoa.CurrentRow.Cells[2].Value.ToString() + "'").ExecuteReader();
            if (reader.HasRows)
            {
                // Đọc kết quả
                while (reader.Read())
                {
                    cbbChatlieu.Text = reader[0].ToString();
                }
            }
            txtsoluong.Text = dtgvDSHangHoa.CurrentRow.Cells[3].Value.ToString();
            txtDongianhap.Text = dtgvDSHangHoa.CurrentRow.Cells[4].Value.ToString();
            txtdongiaban.Text = dtgvDSHangHoa.CurrentRow.Cells[5].Value.ToString();
            txtGhiChu.Text = dtgvDSHangHoa.CurrentRow.Cells[6].Value.ToString();
            if (dtgvDSHangHoa.CurrentRow.Cells[7].Value.ToString().Length != 0)
                pbAnh.Image = new Bitmap(dtgvDSHangHoa.CurrentRow.Cells[7].Value.ToString());
            else pbAnh.Image = null;
            thumuc = dtgvDSHangHoa.CurrentRow.Cells[7].Value.ToString();
        }

        private void pbAnh_Click(object sender, EventArgs e)
        {
            fileDialog.Filter = "Image Files(*.jpg; *.gif; *.png;) | *.jpg; *.gif; *.png;";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                pbAnh.Image = new Bitmap(fileDialog.FileName);

            }

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtmahang.Text.Length == 0) MessageBox.Show("Chưa nhập mã hàng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else if (txttenhang.Text.Length == 0) MessageBox.Show("Chưa nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (cbbChatlieu.Text.Length == 0) MessageBox.Show("Chưa chọn chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtsoluong.Text.Length == 0) MessageBox.Show("Chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtDongianhap.Text.Length == 0) MessageBox.Show("Chưa nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtdongiaban.Text.Length == 0) MessageBox.Show("Chưa nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SqlDataReader reader1 = dtBase.command("select mahang from tblhang where mahang = N'" + txtmahang.Text + "'").ExecuteReader();
                if (reader1.HasRows)
                {
                    MessageBox.Show("Mã hàng đã có","Message",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }
                else
                {
                    string machatlieu = "";
                    SqlDataReader reader = dtBase.command("select machatlieu from tblchatlieu where tenchatlieu = N'" + cbbChatlieu.Text + "'").ExecuteReader();
                    if (reader.HasRows)
                    {
                        // Đọc kết quả
                        while (reader.Read())
                        {
                            machatlieu = reader[0].ToString();
                        }
                    }
                    if (fileDialog.FileName.Length != 0)
                    {
                        string sql = "insert into tblhang values('" + txtmahang.Text + "','" + txttenhang.Text + "','" + machatlieu + "','" + txtsoluong.Text + "','" + txtDongianhap.Text + "','" + txtdongiaban.Text + "','" + txtGhiChu.Text + "','" + fileDialog.FileName + "')";
                        dtBase.CapNhatDuLieu(sql);
                        dtgvDSHangHoa.DataSource = dtBase.DocBang("select * from tblHang");
                        dtgvDSHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        fileDialog.FileName = null;
                        pbAnh.Image = null;

                    }
                    else
                    {
                        string sql = "insert into tblhang values('" + txtmahang.Text + "','" + txttenhang.Text + "','" + machatlieu + "','" + txtsoluong.Text + "','" + txtDongianhap.Text + "','" + txtdongiaban.Text + "','" + txtGhiChu.Text + "','')";
                        dtBase.CapNhatDuLieu(sql);
                        dtgvDSHangHoa.DataSource = dtBase.DocBang("select * from tblHang");
                        dtgvDSHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        fileDialog.FileName = null;
                        pbAnh.Image = null;
                    }

                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa không?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (txtmahang.Text.Length == 0)
                {
                    MessageBox.Show("Chưa nhập mã hàng");
                }

                else
                {
                    string sql = "delete from tblhang where mahang = '" + txtmahang.Text + "'";
                    dtBase.CapNhatDuLieu(sql);
                    MessageBox.Show("Xóa thành công!","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    dtgvDSHangHoa.DataSource = dtBase.DocBang("select * from tblhang");
                    dtgvDSHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    pbAnh.Image = null;
                }
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (txttenhang.Text.Length == 0 && cbbChatlieu.Text.Length == 0 && txtsoluong.Text.Length == 0 && txtDongianhap.Text.Length == 0 && txtdongiaban.Text.Length == 0 && txtGhiChu.Text.Length == 0 && fileDialog.FileName.Length == 0)
            {
                MessageBox.Show("Không có giá trị nào thay đổi");
            }
            else
            {
                string sql = "update tblhang set ";

                if (txttenhang.Text.Length != 0)
                    sql += "tenhang = '" + txttenhang.Text + "',";
                if (cbbChatlieu.Text.Length != 0)
                {
                    string machatlieu = "";
                    SqlDataReader reader = dtBase.command("select machatlieu from tblchatlieu where tenchatlieu = N'" + cbbChatlieu.Text + "'").ExecuteReader();
                    if (reader.HasRows)
                    {
                        // Đọc kết quả
                        while (reader.Read())
                        {
                            machatlieu = reader[0].ToString();
                        }
                    }
                    sql += "machatlieu = '" + machatlieu + "',";
                }
                    
                if (txtsoluong.Text.Length != 0)
                    sql += "soluong = '" + txtsoluong.Text + "',";
                if (txtDongianhap.Text.Length != 0)
                    sql += "dongianhap = '" + txtDongianhap.Text + "',";
                if (txtdongiaban.Text.Length != 0)
                    sql += "dongiaban = '" + txtdongiaban.Text + "',";
                if (txtGhiChu.Text.Length != 0)
                    sql += "ghichu = '" + txtGhiChu.Text + "',";
                if (fileDialog.FileName.Length != 0)
                    sql += "anh = '" + fileDialog.FileName + "',";
                sql.Remove(sql.Length - 1);
                string query = sql.Remove(sql.Length - 1);
                query += " where mahang = '" + txtmahang.Text + "'";
                dtBase.CapNhatDuLieu(query);
                MessageBox.Show("sửa thành công");
                dtgvDSHangHoa.DataSource = dtBase.DocBang("select * from tblhang");
                dtgvDSHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                pbAnh.Image = null;
            }
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (dtgvDSHangHoa.Rows.Count > 1) //TH có dữ liệu để ghi
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
                tenCuaHang.Value = "Dao_Duc_Thao_CNTT1-K58";

                Excel.Range header = (Excel.Range)exSheet.Cells[2, 2];
                exSheet.get_Range("B5:G5").Merge(true);
                header.Font.Size = 13;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "DANH SÁCH HÀNG HÓA";

                //Định dạng tiêu đề bảng

                exSheet.get_Range("A7:H7").Font.Bold = true;
                exSheet.get_Range("A7:E7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("B7").Value = "Mã hàng";
                exSheet.get_Range("C7").Value = "Tên hàng";
                exSheet.get_Range("D7").Value = "Chất liệu";
                exSheet.get_Range("E7").Value = "Số lượng";
                exSheet.get_Range("F7").Value = "Giá nhập";
                exSheet.get_Range("G7").Value = "Giá bán";
                exSheet.get_Range("H7").Value = "Ghi chú";
                exSheet.get_Range("I7").Value = "Ảnh";

                //In dữ liệu
                for (int i = 0; i < dtgvDSHangHoa.Rows.Count - 1; i++)
                {
                    exSheet.get_Range("A" + (i + 8).ToString() + ":G" + (i + 8).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 8).ToString()).Value =
                        dtgvDSHangHoa.Rows[i].Cells[0].Value;
                    exSheet.get_Range("C" + (i + 8).ToString()).Value = dtgvDSHangHoa.Rows[i].Cells[1].Value;
                    exSheet.get_Range("D" + (i + 8).ToString()).Value = dtgvDSHangHoa.Rows[i].Cells[2].Value;
                    exSheet.get_Range("E" + (i + 8).ToString()).Value = dtgvDSHangHoa.Rows[i].Cells[3].Value;
                    exSheet.get_Range("F" + (i + 8).ToString()).Value = dtgvDSHangHoa.Rows[i].Cells[4].Value;
                    exSheet.get_Range("G" + (i + 8).ToString()).Value = dtgvDSHangHoa.Rows[i].Cells[5].Value;
                    exSheet.get_Range("H" + (i + 8).ToString()).Value = dtgvDSHangHoa.Rows[i].Cells[6].Value;
                    exSheet.get_Range("I" + (i + 8).ToString()).Value = dtgvDSHangHoa.Rows[i].Cells[7].Value;
                }
                exSheet.Name = "Điểm thi";
                exBook.Activate(); //Kích hoạt file Excel
                //Thiết lập các thuộc tính của SaveFileDialog
                dlgSave.Filter = "Excel Document(*.xls)|*.xls  |Word Document(*.doc) |*.doc|All files(*.*)|*.*";
                dlgSave.FilterIndex = 1;
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = ".xls";
                if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    exBook.SaveAs(dlgSave.FileName.ToString());//Lưu file Excel
                    MessageBox.Show("Đã lưu file !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                exApp.Quit();//Thoát khỏi ứng dụng
            }
            else
                MessageBox.Show("Danh sách rỗng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDongianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtdongiaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
