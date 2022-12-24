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

namespace bai3_QLTour
{
    public partial class Form1 : Form
    {
        private List<KhachHang> khachHangs = new List<KhachHang>();

        double DonGia = 0;
        double Tien = 0;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void TbGiaDuThuyen_TextChanged(object sender, EventArgs e)
        {
        }

        private void addComboBox()
        {
            cbbDoUong.Items.Add("Coca cola");
            cbbDoUong.Items.Add("Pepsi");
            cbbDoUong.Items.Add("Seven up");

            cbbSoLuong.Items.Add("1");
            cbbSoLuong.Items.Add("2");
            cbbSoLuong.Items.Add("3");
            cbbSoLuong.Items.Add("4");
            cbbSoLuong.Items.Add("5");
            cbbSoLuong.Items.Add("6");
            cbbSoLuong.Items.Add("7");
            cbbSoLuong.Items.Add("8");
            cbbSoLuong.Items.Add("9");
            cbbSoLuong.Items.Add("10");
        }

        private void RBtnCaNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnCaNgay.Checked == true)
            {
                tbGiaDuThuyen.Text = "200";
            }
        }



        private void RBtnNuaNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnNuaNgay.Checked == true)
            {
                tbGiaDuThuyen.Text = "100";
            }
        }

      

        private void CbbDoUong_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(cbbDoUong.SelectedIndex != -1)
            {
                switch (cbbDoUong.Text)
                {
                    case "Coca cola":
                        DonGia = 0.5;
                        break;
                    case "Pepsi":
                        DonGia = 0.8;
                        break;
                    case "Seven up":
                        DonGia = 1.0;
                        break;
                }
            }


            if (cbbSoLuong.SelectedIndex != -1)
            {
                int sl = Convert.ToInt32(cbbSoLuong.Text);

                Tien = sl * DonGia;
                TinhTien();
            }
        }

        private void CbbSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbSoLuong.SelectedIndex != -1 && cbbDoUong.SelectedIndex != -1)
            {
                int sl = Convert.ToInt32(cbbSoLuong.Text);
                
                Tien = sl * DonGia;
                TinhTien();
            }

        }

        private void TbTien_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            addComboBox();
            tbGiaDuThuyen.Enabled = false;
            tbTien.Enabled = false;
        }




        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode.Equals(Keys.H))
                {
                    BtnThoat_Click(null, null);
                }

                if (e.KeyCode.Equals(Keys.M))
                {
                    btnThemMoi_Click(null, null);
                }
            }
        }


        private void TinhTien()
        {
            tbTien.Text = Tien > 0 ? Tien.ToString() : "";
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            tbHoTen.Text = "";
            tbGiaDuThuyen.Text = "";

            tbTien.Text = "";
            tbHoTen.Focus();
            rBtnCaNgay.Checked = false;
            rBtnNuaNgay.Checked = false;
            cbbDoUong.SelectedIndex = -1;
            cbbSoLuong.SelectedIndex = -1;
            
        }

        private void btnThemVaoDS_Click(object sender, EventArgs e)
        {
            int check = 1;
            if (tbHoTen.TextLength == 0 || tbGiaDuThuyen.TextLength==0 || tbTien.TextLength==0)
            {
                MessageBox.Show("Nhập lại vì tên hoặc giá du thuyền hoặc tiền rỗng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                check = 0;
            }
            if (check == 1)
            {
                KhachHang kh = new KhachHang(tbHoTen.Text, Convert.ToInt64(tbGiaDuThuyen.Text), cbbDoUong.Text, cbbSoLuong.Text);
                khachHangs.Add(kh);
                kh.tinhTienDoUong = Convert.ToDouble(tbTien.Text);
                double TongTien = kh.tongTien();
                lbDSKH.Items.Add(kh.HoTen + " | " + (rBtnCaNgay.Checked ? rBtnCaNgay.Text : rBtnNuaNgay.Text) + " | " + kh.GiaDuThuyen + "$ | Đồ uống " + tbTien.Text + "$" + " | Tổng " + TongTien + "$");

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
