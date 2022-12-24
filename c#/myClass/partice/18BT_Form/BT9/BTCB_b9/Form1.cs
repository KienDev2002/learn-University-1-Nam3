using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTCB_b9
{
    public partial class Form1 : Form
    {
        int tong = 0;
        int tongtien = 0;
        List<sach> SACH = new List<sach>();
        List<int> TTien = new List<int>();
        List<string> Tenmh = new List<string>();
        public Form1()
        {
            InitializeComponent();
            addcbox();
        }

        public void addTT()
        {

        }

        private void addcbox()
        {
            cbTenSach.Items.Add("Tin đại cương");
            cbTenSach.Items.Add("Tiếng Anh F2");
            cbTenSach.Items.Add("Giải tích F1");
            cbTenSach.Items.Add("Đại số tuyến tính");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listSACH.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn mục nào để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    listSACH.Items.RemoveAt(listSACH.SelectedIndex);
                    SACH.RemoveAt(Convert.ToInt32(listSACH.SelectedValue));
                    TTien.RemoveAt(Convert.ToInt32(listSACH.SelectedValue));
                }
            }
        }

        private void BtThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToString(cbTenSach.SelectedItem))
            {
                case "Tin đại cương":
                    tbGia.Text = "22000";
                    break;
                case "Tiếng Anh F2":
                    tbGia.Text = "27000";
                    break;
                case "Giải tích F1":
                    tbGia.Text = "25000";
                    break;
                case "Đại số tuyến tính":
                    tbGia.Text = "26000";
                    break;

            }
            /*
            if (Convert.ToString(cbTenSach.SelectedItem) == "Tiếng Anh F2")
            {
                tbGia.Text = "27000";
            }
            if (Convert.ToString(cbTenSach.SelectedItem) == "Giải tích F1")
            {
                tbGia.Text = "25000";
            }
            if (Convert.ToString(cbTenSach.SelectedItem) == "Đại số tuyến tính")
            {
                tbGia.Text = "26000";
            }
            */
        }

        private void RadioButton1_Click(object sender, EventArgs e)
        {
                if (rbATM.Checked == true)
                {
                    rbATM.Checked = false;
                    rbTM.Checked = true;
                }
                else rbTM.Checked = true;
                tbGG.Text = "5";
        }

        private void RadioButton2_Click(object sender, EventArgs e)
        {
            if (rbTM.Checked == true)
            {
                rbTM.Checked = false;
                rbATM.Checked = true;
            }
            else rbATM.Checked = true;
            tbGG.Text = "10";
        }

        private void BtThem_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(cbTenSach.SelectedIndex) == null || tbSL.TextLength == 0 || rbTM.Checked == false && rbATM.Checked == false)
            {
                if (cbTenSach.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn sách muốn mua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbSL.TextLength == 0)
                {
                    MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (rbTM.Checked == false && rbATM.Checked == false)
                {
                    MessageBox.Show("Bạn chưa chọn loại thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int check = 1;
                for(int i = 0; i < Tenmh.Count; i++)
                {
                    if (cbTenSach.Text.Contains(Tenmh[i]))
                    {
                        MessageBox.Show("Môn học đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        check = 0;
                    }
                    
                }
                if(check == 1)
                {
                    if (rbATM.Checked == true)
                    {
                        tong = (Convert.ToInt32(tbGia.Text) * Convert.ToInt32(tbSL.Text)) * 95 / 100;
                        listSACH.Items.Add(cbTenSach.Text + "," + tbGia.Text + "-" + tong);
                        SACH.Add(new sach(cbTenSach.Text, Convert.ToInt32(tbGia.Text), Convert.ToInt32(tbSL.Text)));
                        TTien.Add(tong);
                        Tenmh.Add(cbTenSach.Text);
                    }
                    else if (rbTM.Checked == true)
                    {
                        tong = (Convert.ToInt32(tbGia.Text) * Convert.ToInt32(tbSL.Text)) * 90 / 100;
                        listSACH.Items.Add(cbTenSach.Text + "," + tbGia.Text + "-" + tong);
                        SACH.Add(new sach(cbTenSach.Text, Convert.ToInt32(tbGia.Text), Convert.ToInt32(tbSL.Text)));
                        TTien.Add(tong);
                        Tenmh.Add(cbTenSach.Text);
                    }
                }
                
                
            }
        }

        private void BtTinhtong_Click(object sender, EventArgs e)
        {
            tongtien = TTien.Sum();
            tbTT.Text = Convert.ToString(tongtien);
        }

        private void TbSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbSL.Text = "";
                tbSL.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode.Equals(Keys.H))
                {
                    BtThoat_Click(null, null);
                }
            }
        }

        private void cbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbTM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbATM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listSACH_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
