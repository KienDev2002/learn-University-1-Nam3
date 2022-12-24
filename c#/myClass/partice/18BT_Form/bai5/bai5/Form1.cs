using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai5
{
    public partial class Form1 : Form
    {
        List<double> number = new List<double>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Exit()
        {
            if(MessageBox.Show("Bạn có muốn thoát không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.hide();
            lbMax.Text = "";
            lbSum.Text = "";
          
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode.Equals(Keys.A))
                {
                    this.Exit();
                }

                if (e.KeyCode.Equals(Keys.L))
                {
                    this.Reset();
                }

                if (e.KeyCode.Equals(Keys.D))
                {
                    this.btnAdd_Click(null, null);
                }

                if (e.KeyCode.Equals(Keys.X))
                {
                    this.btnRemove_Click(null, null);
                }

                if (e.KeyCode.Equals(Keys.N))
                {
                    this.btnAdd_Click(null, null);
                }

                if (e.KeyCode.Equals(Keys.A))
                {
                    this.btnSearchMax_Click(null, null);
                }
            }
        }

        private void Reset()
        {
            txtNhapSo.Text = "";
            this.hide();
            lbMax.Text = "";
            lbSum.Text = "";
            lvDS.Items.Clear();
            txtNhapSo.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void MessNotification(String message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int check = 1;
            if (txtNhapSo.TextLength == 0)
            {
                this.MessNotification("Không được để trống txt số");
                check = 0;
            }

            if (check == 1)
            {
                    
                    lvDS.Items.Add(this.txtNhapSo.Text);
                    number.Add(Double.Parse(this.txtNhapSo.Text));
                    txtNhapSo.Text = "";
                    txtNhapSo.Focus();
                    this.show();
            }
        }

        private void hide()
        {
            btnSum.Enabled = false;
            btnSearchMax.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void show()
        {
            btnSum.Enabled = true;
            btnSearchMax.Enabled = true;
            btnRemove.Enabled = true;
        }

        private void txtNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được nhập số", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(lvDS.SelectedIndices.Count == 0)
            {
                this.MessNotification("Mời bạn chọn mục để xóa");
            }
            else
            {
                int so = lvDS.SelectedIndex;
                lvDS.Items.RemoveAt(lvDS.SelectedIndex);
                number.RemoveAt(so);
                
            }

            if (lvDS.Items.Count == 0)
            {

                this.hide();
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSum_Click(object sender, EventArgs e)
        {
 
     
            lbSum.Text = "Tổng : " + number.Sum().ToString();
        }

        private void btnSearchMax_Click(object sender, EventArgs e)
        {
            lbMax.Text = "Max :" + number.Max().ToString();
        }

        private void txtNhapSo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
