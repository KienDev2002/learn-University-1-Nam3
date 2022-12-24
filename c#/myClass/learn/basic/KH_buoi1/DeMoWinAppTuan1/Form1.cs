using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChuaBaiKS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DeMoWinAppTuan1
{
    public partial class Form1 : Form
    {
        List<KHSDDIEN> lst = new List<KHSDDIEN>();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //thêm thông tin vào ds sau khi ng dùng nhập đủ dl và ấn nút thêm vào DS
            string ma, ten, dc;
            DateTime nc;
            int st, ss;
            ma = textBox1.Text;
            ten = textBox2.Text;
            dc = textBox3.Text;
            nc = dateTimePicker1.Value;

            st = int.Parse(textBox4.Text);
            bool k = int.TryParse(textBox5.Text, out ss);

            bool check = true;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Bạn chưa nhâp ma khách hàng","thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                check = false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Bạn chưa nhâp tên khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                check = false;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Bạn chưa nhâp địa chỉ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                check = false;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Bạn chưa nhâp tháng trước", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                check = false;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Bạn chưa nhâp tháng sau", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                check = false;
            }
            if (check)
            {
                KHSDDIEN x = new KHSDDIEN(ma,ten,dc,nc,st,ss);
                listBox1.Items.Add(x.ToString());
                lst.Add(x);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Bạn chưa nhâp tên khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                check = false;
            }
            if (check)
            {
                string name = textBox2.Text;
                bool k = true;
            
                foreach (string item in listBox1.Items)
                    if (item.Equals(name))
                    {
                        textBox6.Text = "da tim thay";
                        k = true;
                    }
                if (k == false) textBox6.Text = "khong tim thay";

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
