
using bai1_QLBH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai1_QLKH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void AddComboBox()
        {
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("6");
            comboBox1.Items.Add("12");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AddComboBox();
            this.KeyPreview = true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            int kt = 1;
            if (textBox1.TextLength < 6)
            {
                MessageBox.Show("Nhập lại vì mã < 6");
                kt = 0;
                if (textBox2.TextLength == 0 && textBox3.TextLength == 0)
                {
                    MessageBox.Show("Nhập lại vì tên hoặc địa chỉ rỗng");
                    kt = 0;
                }
            }

            double tienlai = 0;
            if (kt == 1)
            {
                if (radioButton1.Checked == true)
                {
                    if (comboBox1.SelectedItem == "1")
                    {
                        tienlai = Convert.ToInt32(textBox4.Text) * 0.06;
                    }
                    if (comboBox1.SelectedItem == "3")
                    {
                        tienlai = Convert.ToInt32(textBox4.Text) * 0.07;
                    }

                    if (comboBox1.SelectedItem == "6")

                    {
                        tienlai = Convert.ToInt32(textBox4.Text) * 0.08;
                    }

                    if (comboBox1.SelectedItem == "12")

                    {
                        tienlai = Convert.ToDouble(textBox4.Text) * 0.09;
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    if (comboBox1.SelectedItem == "1")
                    {
                        tienlai = Convert.ToInt32(textBox4.Text) * 0.07;
                    }
                    if (comboBox1.SelectedItem == "3")
                    {
                        tienlai = Convert.ToInt32(textBox4.Text) * 0.08;
                    }

                    if (comboBox1.SelectedItem == "6")

                    {
                        tienlai = Convert.ToInt32(textBox4.Text) * 0.09;
                    }

                    if (comboBox1.SelectedItem == "12")

                    {
                        tienlai = Convert.ToInt32(textBox4.Text) * 0.1;
                    }
                }

                listBox1.Items.Add(textBox1.Text + " | " + textBox2.Text + " | " + textBox3.Text + " | " + dateTimePicker1.Text + " | " + textBox4.Text + " | " + comboBox1.Text + " tháng | " + tienlai);
                List<NguoiGui> listNguoiGuis = new List<NguoiGui>();

                listNguoiGuis.Add(new NguoiGui(Convert.ToInt32(textBox1.Text),
                textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text),
                dateTimePicker1.Text, comboBox1.Text, tienlai
                ));
                StaticData.NguoiGuis = listNguoiGuis;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            dateTimePicker1.Text = "";
            listBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}