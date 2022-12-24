using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lesson2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addData();
        }

        private void addData()
        {
            lbMatHang.Items.Add("Kỹ thuật lập trình C#");
            lbMatHang.Items.Add("Tự học visual c# trong 21 ngày");
            lbMatHang.Items.Add("Bài tập c#");
            lbMatHang.Items.Add(".NET toàn tập-tập 1");
            lbMatHang.Items.Add(".NET toàn tập-tập 2");
            lbMatHang.Items.Add(".NET toàn tập-tập 3");
            lbMatHang.Items.Add(".NET toàn tập-tập 4");
            lbMatHang.Items.Add("Tin học cơ bản");
            lbMatHang.Items.Add("SQL server");
            lbMatHang.Items.Add("Cơ bản về XML");
            lbMatHang.Items.Add("Phân tích TKHT");
            lbMatHang.Items.Add("Sử dụng word");
            lbMatHang.Items.Add("Đến với word 2003");
        }

        private void lbMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }

        private void lbMatHang_MouseDoubleClick(object sender, EventArgs e)
        {

        }

        private void lbMatHang_MouseEnter(object sender, EventArgs e)
        {

        }


        private string HinhThucLL()
        {
            string a = "";
            if (cbDT.Checked == true)
            {
                a += "  " + cbDT.Text;
            }

            if (cbEmail.Checked == true)
            {
                a += "  " + cbEmail.Text;
            }

            if (cbFax.Checked == true)
            {
                a += "  " + cbFax.Text;
            }
            return a;
        }


        private string ThanhToan()
        {
            string s = "";
            if (rdTienMat.Checked == true)
            {
                s += rdTienMat.Text;
            }

            if (rdSec.Checked == true)
            {
                s += rdSec.Text;
            }

            if (rdthe.Checked == true)
            {
                s += rdthe.Text;
            }
            return s;
        }


        

        private void lbMatHang_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string curItem = lbMatHang.SelectedItem.ToString();

            int index = lbMua.FindString(curItem);
            if (index == -1)
            {
                lbMua.Items.Add(curItem);
            }
            else
            {
                MessageBox.Show("Hàng đặt mua đã có rồi");
            }
        }

        private void lbMua_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbMua.SelectedIndex;
            if(MessageBox.Show("Bạn có muốn xóa không ?" , "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
            {
                lbMua.Items.RemoveAt(index);
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if(txthoten.Text.Equals("") || txtdt.Text.Equals(""))
            {
                MessageBox.Show("Bạn cần nhập đủ thông tin", "Thông báo");
                txthoten.Focus();
            }
            else
            {
                string sb = "";
                foreach (object item in lbMua.Items)
                {
                    sb += item.ToString();
                    sb += "\n";
                }
                MessageBox.Show(txthoten.Text + " " +  txtdt.Text + " \n" + sb + " " + ThanhToan() + HinhThucLL(), "Thông báo" , MessageBoxButtons.OK);
            }

        }
    }
}
