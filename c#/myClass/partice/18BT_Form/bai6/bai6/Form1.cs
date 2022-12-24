using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai6
{
    public partial class Form1 : Form
    {
        List<double> number = new List<double>();
        int check = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void hide()
        {
            btnRemove.Enabled = false;
            for(int i = 0; i< 3; i++)
            {
                lbDS.Items.Add(i*2);
                number.Add(i*2);
            }
            lbSearch.Text = "";
            txtNhapSo.Text = " ";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            hide();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode.Equals(Keys.L))
                {
                    hide();
                }
                if (e.KeyCode.Equals(Keys.H))
                {
                    this.btnExit_Click(null, null);
                }
                if (e.KeyCode.Equals(Keys.X))
                {
                    this.btnRemove_Click(null, null);
                }
            }
        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            check = 1;
            if (txtNhapSo.TextLength == 0)
            {
                check = 0;
                this.MessNotification("Mời bạn nhập lại không để trống");
            }
            if (check == 1)
            {
                lbDS.Items.Add(this.txtNhapSo.Text);
                number.Add(Convert.ToDouble(txtNhapSo.Text));
                txtNhapSo.Text = "";
                txtNhapSo.Focus();
            }
        }

        private void MessNotification(String message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            check = 1;
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                check = 0;
                MessNotification("Không được là số");
            }
        }

        private void lbDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbDS.SelectedIndices.Count != 0)
            {
                btnRemove.Enabled = true;
            }
       
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int i = lbDS.SelectedIndex;
                lbDS.Items.RemoveAt(i);
                number.RemoveAt(i);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbSearch.Enabled = true;
            lbSearch.Text = "Giá trị lớn nhất của dãy là : " + number.Max().ToString();
        }
    }
}
