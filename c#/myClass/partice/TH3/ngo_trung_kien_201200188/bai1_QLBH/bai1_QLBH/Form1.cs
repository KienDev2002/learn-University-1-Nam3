using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bai1_QLBH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void addComboBox()
        {
            cbTGG.Items.Add("1");
            cbTGG.Items.Add("3");
            cbTGG.Items.Add("6");
            cbTGG.Items.Add("12");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addComboBox();
            this.KeyPreview = true;

        }

        //Các TextBox mã khách hàng, Số tiền gửi chỉ cho phép người dùng nhập vào các số nguyên
        private void tbMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            //IsDigit: Phương pháp này được sử dụng để kiểm tra xem ký tự Unicode được chỉ định có khớp với chữ số thập phân hay không. Nếu nó khớp thì nó trả về True, ngược lại thì trả về False.
            //e.keychar: Ký tự ASCII được tạo thành. Ví dụ: nếu người dùng nhấn SHIFT + K, thuộc tính này trả về chữ K viết hoa.
            //e.iscoltrol(): Cho biết ký tự Unicode được chỉ định có được phân loại là ký tự điều khiển hay không.
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                //true nếu sự kiện được xử lý; nếu không false,.
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int check = 1 ;
            if (tbMaKH.TextLength < 6)
            {
                MessageBox.Show("Nhập lại vì mã < 6");
                check = 0;
            }
            if (tbDC.TextLength == 0 || tbHoTenKH.TextLength == 0)
            {
                MessageBox.Show("Nhập lại vì tên hoặc địa chỉ rỗng");
                check = 0;
            }

            double tl = 0;
            if (check == 1)
            {
                if (rdThuong.Checked == true)
                {
                    switch (cbTGG.SelectedItem)
                    {
                        case "1":
                            tl = Convert.ToInt32(tbSTG.Text) * 0.06;
                            break;
                        case "3":
                            tl = Convert.ToInt32(tbSTG.Text) * 0.07;
                            break;
                        case "6":
                            tl = Convert.ToInt32(tbSTG.Text) * 0.08;
                            break;
                        case "12":
                            tl = Convert.ToInt32(tbSTG.Text) * 0.09;
                            break;
                    }

                }
                else if (rdPhatLoc.Checked==true)
                {
                    switch (cbTGG.SelectedItem)
                    {
                        case "1":
                            tl = Convert.ToInt32(tbSTG.Text) * 0.07;
                            break;
                        case "3":
                            tl = Convert.ToInt32(tbSTG.Text) * 0.08;
                            break;
                        case "6":
                            tl = Convert.ToInt32(tbSTG.Text) * 0.09;
                            break;
                        case "12":
                            tl = Convert.ToInt32(tbSTG.Text) * 0.1;
                            break;
                    }
                }

                lbDSKH.Items.Add(
                        tbMaKH.Text + " | "
                        + tbHoTenKH.Text + " | "
                        + tbDC.Text
                        + " | " + dtmNG.Text + " | "
                        + tbSTG.Text + " | "
                        + cbTGG.Text + " tháng | " + tl);
                List<NguoiGui> listNguoiGuis = new List<NguoiGui>();
                listNguoiGuis.Add(
                    new NguoiGui(Convert.ToInt32(tbMaKH.Text), tbHoTenKH.Text, tbDC.Text, Convert.ToInt32(tbSTG.Text), dtmNG.Text, cbTGG.Text, tl)
                );
                StaticData.NguoiGuis = listNguoiGuis;
            }
            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                this.Close();
            }
        }

        private void btnNewAdd_Click(object sender, EventArgs e)
        {
            tbMaKH.Text = "";
            tbHoTenKH.Text = "";
            tbDC.Text = "";
            tbSTG.Text = "";
            dtmNG.Text = "";
            cbTGG.Text = "";
            cbTGG.SelectedIndex = -1;
            rdThuong.Checked = false;
            rdPhatLoc.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
