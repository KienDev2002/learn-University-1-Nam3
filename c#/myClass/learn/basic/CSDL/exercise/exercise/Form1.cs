using exercise.model;
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


namespace exercise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Connection db = new Connection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\learn\\basic\\CSDL\\exercise\\exercise\\Database1.mdf\";Integrated Security=True");


        private void Form1_Load(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = db.getTable("select * from ChatLieu");
            
        }

        private void notification(string noti)
        {
            MessageBox.Show(noti);
        }

        private bool Validate()
        {
            if(txtMaCL.Text == "" && txtSL.Text == "" && txtTenCL.Text == "")
            {
                this.notification("Không được để trống");
                return false;
            }

            return true;
        }

        private ChatLieu chatLieu()
        {
            string MaCL = txtMaCL.Text.Trim();
            string TenCL = txtTenCL.Text.Trim();
            string SL = txtSL.Text.Trim();

            return new ChatLieu(MaCL, TenCL, SL);   
        }


        private void stateInput(bool type)
        {
            panel3.Enabled=type;
        }


        private void stateBtn(bool type)
        {
            btnThem.Enabled=type;
            btnSua.Enabled=type;
            btnXoa.Enabled=type;
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            stateBtn(false);
            stateInput(true);
            btnThem.Enabled = true;
            reset();
        }


        private void reset()
        {
            txtMaCL.Text = "";
            txtTenCL.Text = "";
            txtSL.Text = "";
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(ch==46 && txtSL.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if(!char.IsDigit(ch) && ! char.IsControl(ch) && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if ( btnThem.Enabled &&  Validate())
            {
                ChatLieu cl = this.chatLieu();
                string query = $"Insert into ChatLieu values(N'{cl.MaCL1}',N'{cl.TenCL1}',{cl.SL1})";

                if (MessageBox.Show("Bạn có thêm chất liệu không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        db.Excute(query);
                        this.Form1_Load(null, null);
                        this.notification("Bạn đã thêm thành công!");

                    }

                    catch (Exception ex)
                    {
                        this.notification("Lỗi" + ex.Message);
                    }
                }
            }


            if (btnSua.Enabled && Validate())
            {
                ChatLieu cl = this.chatLieu();

                string query = $"update ChatLieu " +
                    $"set TenCL = N'{cl.TenCL1}' , " +
                    $"SoLuong = {cl.SL1} " +
                    $"where MaCL = '{cl.MaCL1}'";

                if (MessageBox.Show("Bạn có sửa chất liệu không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        db.Excute(query);
                        MessageBox.Show("Sửa thành công!");
                        Form1_Load(sender, e);
                        reset();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi; " + ex.Message);
                    }

                }
            }

            if (btnXoa.Enabled && Validate())
            {
 

                if(txtMaCL.Text.Trim() == "") {
                    notification("Chưa có mã CL để xóa");
                    return;
                }

                string query = $"delete from ChatLieu " +
                $"where MaCL = N'{txtMaCL.Text.Trim()}'";
                

                if (MessageBox.Show($"Bạn có xóa chất liệu {txtMaCL.Text.Trim()} không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        db.Excute(query);
                        MessageBox.Show("Xóa thành công!");
                        Form1_Load(sender, e);
                        reset();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi; " + ex.Message);
                    }

                }
            }


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            stateBtn(false);
            stateInput(true);
            btnSua.Enabled = true;
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCL.Text = dgvDanhSach.SelectedRows[0].Cells[0].Value.ToString();
            txtTenCL.Text = dgvDanhSach.SelectedRows[0].Cells[1].Value.ToString();
            txtSL.Text = dgvDanhSach.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            stateBtn(false);
            stateInput(true);
            btnXoa.Enabled = true;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            stateBtn(true);
            stateInput(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void exportExcel(DataTable dataTable , string filename)
        {
           using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];
                worksheet.ImportDataTable(dataTable, true, 1, 1);
                worksheet.UsedRange.AutofitColumns();
                workbook.SaveAs(filename);
            }
        }

        private void btnExportExel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export excel";
            saveFileDialog.Filter = "fileName(*.xlsx)|*.xlsx|All file(*.*)|*.*";
            saveFileDialog.InitialDirectory = "C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\learn\\basic\\CSDL\\exercise";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable dataTable = db.getTable("select * from ChatLieu");
                    exportExcel(dataTable, saveFileDialog.FileName);
                    MessageBox.Show("Xuat file thanh cong");

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Eroor " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
