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
using Excel = Microsoft.Office.Interop.Excel;

namespace connectQLChatLieu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProcessDatabase db = new ProcessDatabase("Data Source=DESKTOP-OSRNAUL\\SQLEXPRESS;Initial Catalog=QLChatLieu;Integrated Security=True");


        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.DocBang("select * from BangChatLieu");
            btnRemove.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnSkip.Enabled = false;
            btnAdd.Enabled = true;

        }

        private bool validate()
        {
            if(txtMaChatLieu.Text  == "" || txtTenChatLieu.Text == "")
            {
                MessageBox.Show("Không được để trống");
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtMaChatLieu.Enabled = true;
            txtMaChatLieu.Focus();
            btnRemove.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnSkip.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        void ResetValue()
        {
            txtTenChatLieu.Text = "";
            txtTenChatLieu.Text = "";
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtTenChatLieu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenChatLieu.Focus();

            }
            else
            {
                db.CapNhatDuLieu("update BangChatLieu set TenChatLieu=N'" + txtTenChatLieu.Text + "' where MaChatLieu='" + txtMaChatLieu.Text + "'");
                ResetValue();//Xóa dữ liệu ở các ô nhập TextBox
                             //Sau khi update cần lấy lại dữ liệu để hiển thị lên lưới

                Form1_Load(null, null);
                btnRemove.Enabled = false;
                btnEdit.Enabled = false;
                btnSkip.Enabled = false;
                btnSave.Enabled = false;
                btnAdd.Enabled = true;
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chất liệu có mã là:" +
                txtMaChatLieu.Text + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.Yes)
            {
                db.CapNhatDuLieu("delete from BangChatLieu where MaChatLieu='" + txtMaChatLieu.Text + "'");
                dataGridView1.DataSource = db.DocBang("Select * from BangChatLieu");
                ResetValue();
                btnRemove.Enabled = false;
                btnEdit.Enabled = false;
                btnSkip.Enabled = false;
                btnSave.Enabled = false;
                btnAdd.Enabled = true;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtMaChatLieu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu");
                txtMaChatLieu.Focus();
            }
            else
            {
                if (txtTenChatLieu.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập tên chất liệu");
                    txtTenChatLieu.Focus();
                }
                else
                {
                    DataTable dtChatLieu = db.DocBang("select * from BangChatLieu where" + " MaChatLieu=N'" + (txtMaChatLieu.Text).Trim() + "'");
                    if (dtChatLieu.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã chất liệu này đã có, hãy nhập mã khác!");
                        txtMaChatLieu.Focus();
                    }
                    else
                    {
                        db.CapNhatDuLieu("insert into BangChatLieu values(N'" + txtMaChatLieu.Text + "',N'" + txtTenChatLieu.Text + "')");
                        MessageBox.Show("Bạn đã thêm mới thành công");
                        dataGridView1.DataSource = db.DocBang("select * from BangChatLieu");
                        ResetValue();
                        btnRemove.Enabled = false;
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        btnSkip.Enabled = false;
                        btnAdd.Enabled = true;
                    }
                }
            }
            

        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnRemove.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnSkip.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                if (btnSave.Enabled == true)
                {
                    if (MessageBox.Show("Bạn có muốn Lưu lại chất liệu đang thêm mới không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        btnSave_Click(sender, e);
                    else
                        this.Close();

                }
                else
                    this.Close();
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtMaChatLieu.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenChatLieu.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            txtMaChatLieu.Enabled = false;
            btnRemove.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnSkip.Enabled = true;
            btnAdd.Enabled = false;

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            worksheet.get_Range("I9:K10").Font.Bold = true;
            worksheet.get_Range("I9").Value = "Danh sách các chất liệu";
            worksheet.get_Range("I9").Font.Size = 20;
            worksheet.get_Range("I9").Font.Color = Color.Red;
     
            //trộn
            worksheet.get_Range("I9:K9").Merge(true);

            //căn giữa
            worksheet.get_Range("I9:K40").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


            worksheet.get_Range("I10").Value = "STT";
            worksheet.get_Range("I10").ColumnWidth = 10;
            worksheet.get_Range("J10").Value = "Mã chất liệu";
            worksheet.get_Range("J10").ColumnWidth = 20;
            worksheet.get_Range("K10").Value = "Tên chất liệu";
            worksheet.get_Range("K10").ColumnWidth = 25;

            int n = dataGridView1.Rows.Count;
            for (int i = 0; i< n; i++)
            {
                worksheet.get_Range("I" + (i + 11).ToString()).Value = (i + 1).ToString();
                worksheet.get_Range("J" + (i + 11).ToString()).Value = dataGridView1.Rows[i].Cells[0].Value;
                worksheet.get_Range("K" + (i + 11).ToString()).Value = dataGridView1.Rows[i].Cells[1].Value;
            }

            worksheet.Activate();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "chatlieu(*.xlsx)|*.xlsx";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                worksheet.SaveAs(saveFileDialog.FileName.ToString());
                MessageBox.Show("Lưu file thành công");
            }
        }
    }
}
