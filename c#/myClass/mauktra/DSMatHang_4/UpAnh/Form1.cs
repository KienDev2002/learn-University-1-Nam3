using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;

namespace DeThi1
{
    public partial class Form1 : Form
    {
        private Database dtb = new Database();

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
            txtMaHang.Enabled = true;
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
            txtMaHang.Enabled = false;
            txtMaHang.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenHang.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cboChatLieu.Text = dataGridView1.CurrentRow.Cells["Machatlieu"].Value.ToString();
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDonGiaNhap.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDonGiaBan.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtGhiChu.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtImg.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            pictureBox1.Visible = true;
            if (txtImg.Text.Length != 0)
            {
                pictureBox1.Image = Image.FromFile(txtImg.Text);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void exportExcel(DataGridView g)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "Excel Document(*.xls)|*.xls  |Word Document(*.doc) |*.doc|All files(*.*)|*.*";
            dlgSave.FilterIndex = 1;
            dlgSave.AddExtension = true;
            dlgSave.DefaultExt = ".xls";
            if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                obj.ActiveWorkbook.SaveCopyAs(dlgSave.FileName.ToString());
                obj.ActiveWorkbook.Saved = true;
                MessageBox.Show("Xuất file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có danh sách hàng để in");
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            exportExcel(dataGridView1);
        }

        private bool Validate()
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
            if (Validate())
            {
                sql += "insert into tblHang(Mahang,Tenhang,Machatlieu,Soluong,Dongianhap,Dongiaban,anh,ghichu)" +
                    " values ('" + txtMaHang.Text + "',N'" + txtTenHang.Text + "'," +
                    "(select MaChatLieu from tblChatlieu where TenChatLieu='" + cboChatLieu.Text + "')" +
                    ",'" + txtSoLuong.Text + "','" + txtDonGiaNhap.Text + "','" + txtDonGiaBan.Text +
                    "','" + txtImg.Text + "','" + txtGhiChu.Text + "')";
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
                if (Validate())
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sql = "update tblHang set Tenhang=N'" + txtTenHang.Text + "',Soluong=N'" + txtSoLuong.Text + "',Dongiaban=N'" + txtDonGiaNhap.Text + "',Dongianhap='" + txtDonGiaBan.Text + "',Anh=N'" + txtImg.Text + "',Ghichu='" + txtGhiChu.Text + "' WHERE Mahang = N'" + txtMaHang.Text + "'";
                    ResetData();
                    dtb.CapNhatDuLieu(sql);
                    MessageBox.Show("Bạn đã cập nhật thành công");
                    dataGridView1.DataSource = dtb.DocBang("select Mahang,Tenhang,h.Machatlieu,Soluong,Dongianhap,Dongiaban,Anh,Ghichu from tblChatlieu cl join tblHang h on cl.MaChatLieu=h.Machatlieu");
                }
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
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
            dlgOpen.InitialDirectory = "E:\\C#"; dlgOpen.FilterIndex = 2;
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

        private void Form1_Click(object sender, EventArgs e)
        {
            ResetData();
        }
    }
}