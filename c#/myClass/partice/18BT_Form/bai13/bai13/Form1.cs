using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace bai13
{
    public partial class Form1 : Form
    {
        string isNumber = @"^[+-]?[0-9]*\.?[0-9]+$";
        List<double> dso = new List<double>();
        public Form1()
        {
            InitializeComponent();
        }

        private void reset()
        {
            lbDaySo.Text = "";
            lbSoDuongNN.Text = "";
            btnTim.Enabled = false;
            btnTimSoDuongNN.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
        }
        private void MessNotification(String message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
  
                if (MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode.Equals(Keys.T))
                {
                    btnThoat_Click(null, null);
                }
                if (e.KeyCode.Equals(Keys.L))
                {
                    btnLamLai_Click(null, null);


                }
                if (e.KeyCode.Equals(Keys.N))
                {
                    btnNhapDay_Click(null, null);
                }
                if (e.KeyCode.Equals(Keys.T))
                {
                    btnTim_Click(null, null);
                }
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void txtNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
               
                MessNotification("Không được là số");
                e.Handled = true;
            }
        }

        private void btnNhapDay_Click(object sender, EventArgs e)
        {
            dso.Clear();
            if (txtNhapSo.TextLength == 0)
            {
                MessNotification("Hãy nhập số");

            }
            else
            {
                int check = 1;
                String a = Interaction.InputBox("Nhập các phân tử của dãy", "Nhập dãy", "Nhập các số cách nhau bởi dấu ','");
                string[] a1 = a.Split(',');
                if(a1.Length != Convert.ToInt32(txtNhapSo.Text))
                {
                    MessageBox.Show("Chuỗi không hợp lệ! Phải nhâp " + txtNhapSo.Text + " số và cách nhau bởi dấu ','", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNhapSo.Text = "";
                    txtNhapSo.Focus();

                }
                else
                {
                    for(int i = 0; i< a1.Length; i++)
                    {
                        if (!Regex.IsMatch(a1[i], isNumber))
                        {
                            MessNotification("Hãy nhập số");
                            check = 0;
                            break;
                        }
                       
                    }
                    if(check == 1)
                    {
                        lbDaySo.Text = "Dãy số vừa nhập là: ";
                        for (int i = 0; i < a1.Length; i++)
                        {
                           lbDaySo.Text += a1[i] + " ";
                            btnTim.Enabled = true;
                            btnTimSoDuongNN.Enabled = true;
                           dso.Add(Convert.ToDouble(a1[i]));
                        }
                    }
                }
            }
        }

        private void btnTimSoDuongNN_Click(object sender, EventArgs e)
        {
            double min = 0;
            for(int i = 0; i< dso.Count; i++)
            {
                if (dso[i] > 0)
                {
                    min = dso[i];
                    break;
                }
            }
            for(int i = 0; i < dso.Count; i++)
            {
                if (dso[i] <= min && dso[i] > 0)
                {
                    min = dso[i];
                }
            }
            lbSoDuongNN.Text = "Số dương nhỏ nhất là: " +  min.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtNhapSoK.TextLength == 0)
            {
                MessNotification("Hãy nhập 1 số");

            }
            else
            {
            
                int[] indexs = new int[dso.Count];
                int index = 0;
                int dem = 0;
                double k = Convert.ToDouble(txtNhapSoK.Text);
                for (int i = 0; i < dso.Count; i++)
                {
                    if (dso[i] == k)
                    {
                        indexs[index] = i;
                        index++;
                        dem++;
                    }
                }
                string str = "";
                for(int i = 0;  i< dem; i++)
                {
                    str += indexs[i] + ",";
                }
                MessageBox.Show("Số phần từ có gtri bang " + k + " là " + dem +" phần tử "+" nằm ở vị trí: " + str);

            }
        }

        private void txtNhapSoK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {

                MessNotification("Không được là số");
                e.Handled = true;
            }
        }
    }
}
