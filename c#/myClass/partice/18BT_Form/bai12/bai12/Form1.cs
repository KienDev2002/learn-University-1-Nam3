using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai12
{
    public partial class Form1 : Form
    {
        List<int> ds = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void BtThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void BtThem_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(tbNhap.Text);
                ds.Add(Convert.ToInt32(tbNhap.Text));
                listBox1.Items.Add(Convert.ToInt32(tbNhap.Text));
                tbNhap.Text = "";
                tbNhap.Focus();
            }
            catch
            {
                MessageBox.Show("Phải nhập số nguyên!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbNhap.Text = "";
                tbNhap.Focus();
            }
        }

        private void BtXoa_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Chưa có số trong danh sách", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (listBox1.SelectedIndex==-1){
                MessageBox.Show("Bạn chưa chọn số muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                 DialogResult dialog1 = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (dialog1 == DialogResult.Yes)
                 {
                     int i = listBox1.SelectedIndex;
                     listBox1.Items.RemoveAt(i);
                     ds.RemoveAt(i);
                 }
             }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {   
            if (e.Alt)
            {
                if (e.KeyCode.Equals(Keys.H))
                {
                    BtThoat_Click(null, null);
                }
                if (e.KeyCode.Equals(Keys.T))
                {
                    BtThem_Click(null, null);
                }
                if (e.KeyCode.Equals(Keys.X))
                {
                    BtXoa_Click(null, null);
                }
            }
        }

        private void BtTangdv_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < ds.Count; i++)
            {
                ds[i] = ds[i] + 3;
                listBox1.Items.Add(ds[i]);
            }
        }

        private void BtChon_Click(object sender, EventArgs e)
        {
            List<int> dsChan = new List<int>();
            for(int i = 0; i < ds.Count() ; i++)
            {
                int a;
                a = Convert.ToInt32(ds[i]);
                if (a % 2 == 0)
                {
                    dsChan.Add(i);
                }   
            }
            foreach(int item in dsChan)
            {
                listBox1.SetSelected(item, true);   
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.lbSnt.Text = "";
        }

        private bool ktrasnt(double a)
        {
            if (a < 2)
            {
                return false;
            }
            else
            {
                for(int i = 2; i <= a/2; i++)
                {
                    if (a % i == 0)
                    {
                        return false;
                        break;
                    }
                }
            }
            return true;
        }
        private void btnKtra_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Chưa có số trong danh sách", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (listBox1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Mời bạn chọn số", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                this.lbSnt.Text = "";

                int i = listBox1.SelectedIndex;
                double so = ds[i];
                if (ktrasnt(so)==false)
                {
                    lbSnt.Text = so + " không phải số nguyên tố ";
                }
                else
                {
                    lbSnt.Text = so + " là số nguyên tố ";

                }
            }
        }
    }
}
