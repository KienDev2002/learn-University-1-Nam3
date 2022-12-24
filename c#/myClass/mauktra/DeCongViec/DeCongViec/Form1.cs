using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeCongViec
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
            txtMaCV.ResetText();
            txtTenCV.ResetText();
            txtLuong.ResetText();
            txtMaCV.Enabled = true;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (Validate())
            {
                sql += "insert into tblCongViec(MaCV,TenCV,Luong)" +
                    " values ('" + txtMaCV.Text + "',N'" + txtTenCV.Text + "','" + txtLuong.Text + "')";
                dtb.CapNhatDuLieu(sql);
                MessageBox.Show("Bạn đã thêm thành công");
                dataGridView1.DataSource = dtb.DocBang("select * from tblCongViec");
                ResetData();
            }
            else
            {
                MessageBox.Show("Kiểm tra lại dữ liệu nhập vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = dtb.DocBang("select * from tblCongViec");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Mã công việc";
            dataGridView1.Columns[1].HeaderText = "Tên công việc";
            dataGridView1.Columns[2].HeaderText = "Mức lương";
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCV.Enabled = false;
            txtMaCV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenCV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtLuong.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private bool Validate()
        {
            if (txtMaCV.Text == "" || txtTenCV.Text == "" || txtLuong.Text == "")
            {
                return false;
            }

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == txtMaCV.Text)
                {
                    return false;
                }
            return true;
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
                    sql = "update tblCongViec set TenCV=N'" + txtTenCV.Text + "',Luong=N'" + txtLuong.Text + "' WHERE MaCV = N'" + txtMaCV.Text + "'";
                    ResetData();
                    dtb.CapNhatDuLieu(sql);
                    MessageBox.Show("Bạn đã cập nhật thành công");
                    dataGridView1.DataSource = dtb.DocBang("select * from tblCongViec");
                }
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có xóa hàng không ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtb.CapNhatDuLieu("DELETE FROM dbo.tblCongViec WHERE MaCV = N'" + txtMaCV.Text + "'");
                dataGridView1.DataSource = dtb.DocBang("select * from tblCongViec");
                this.ResetData();
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.ResetData();
        }
    }
}