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


        ProcessDatabase db = new ProcessDatabase("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\exercise\\CSDL_Export\\kiemtra\\kiemtra\\Database1.mdf\";Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.DocBang("select * from tblChatLieu");
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
            btnThem.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            worksheet.get_Range("I9:K10").Font.Bold = true;
            worksheet.get_Range("I9").Value = "Danh sách chất liệu";
            worksheet.get_Range("I9").Font.Size = 20;
            worksheet.get_Range("I9").Font.Color = Color.Red;

            //trộn
            worksheet.get_Range("I9:K9").Merge(true);

            //căn giữa
            worksheet.get_Range("I9:K40").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


            worksheet.get_Range("I10").Value = "STT";
            worksheet.get_Range("I10").ColumnWidth = 10;

            //trường dữ liệu thứ nhất
            worksheet.get_Range("J10").Value = "Mã chất liệu";
            worksheet.get_Range("J10").ColumnWidth = 20;

            //trường dữ liệu thứ hai
            worksheet.get_Range("K10").Value = "Tên Chất liệu";
            worksheet.get_Range("K10").ColumnWidth = 25;

            int n = dataGridView1.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                worksheet.get_Range("I" + (i + 11).ToString()).Value = (i + 1).ToString();
                worksheet.get_Range("J" + (i + 11).ToString()).Value = dataGridView1.Rows[i].Cells[0].Value;
                worksheet.get_Range("K" + (i + 11).ToString()).Value = dataGridView1.Rows[i].Cells[1].Value;
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

        void ResetValue()
        {
            txtMaCL.Text = "";
            txtTenCL.Text = "";
        }


        private void button7_Click(object sender, EventArgs e)
        {
            if (txtTenCL.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenCL.Focus();

            }
            else
            {
                db.CapNhatDuLieu($"update tblChatLieu set TenCL = N'{txtTenCL.Text.Trim()}' where MaCL = N'{txtMaCL.Text.Trim()}'");
                ResetValue();
                Form1_Load(null, null);
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtMaCL.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenCL.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            txtMaCL.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chất liệu có mã là:" +
                txtMaCL.Text + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.Yes)
            {
                db.CapNhatDuLieu($"delete from tblChatLieu where MaCL = N'{txtMaCL.Text.Trim()}'");
                ResetValue();
                Form1_Load(null, null);

            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtMaCL.Enabled = true;
            txtMaCL.Focus();
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaCL.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu");
                txtMaCL.Focus();
            }
            else
            {
                if (txtTenCL.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập tên chất liệu");
                    txtMaCL.Focus();
                }
                else
                {
                    DataTable dataTable = db.DocBang($"select * from tblChatLieu where MaCL = N'{txtMaCL.Text.Trim()}'");
                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã chất liệu này đã tồn tại, bạn hãy nhập mã khác!");
                        txtMaCL.Focus();
                    }
                    else
                    {
                        db.CapNhatDuLieu($"insert into tblChatLieu values(N'{txtMaCL.Text.Trim()}',N'{txtTenCL.Text.Trim()}')");
                        Form1_Load(null, null);
                        ResetValue();
                        btnXoa.Enabled = false;
                        btnSua.Enabled = false;
                        btnLuu.Enabled = false;
                        btnBoQua.Enabled = false;
                        btnThem.Enabled = true;

                    }
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (btnLuu.Enabled == true)
                {
                    if (MessageBox.Show("Bạn có muốn Lưu lại chất liệu đang thêm mới không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        btnLuu_Click(sender, e);
                    else
                        this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
