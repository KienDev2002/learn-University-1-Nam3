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
    public partial class Form2 : Form
    {
        List<NguoiGui> listNguoiGuis = new List<NguoiGui>();
        public Form2()
        {
            InitializeComponent();
            listNguoiGuis = StaticData.NguoiGuis;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int timthay = 0;
            foreach (NguoiGui i in listNguoiGuis)
            {
                if (i.MaKH1 == Convert.ToInt32(txtMaKH.Text))
                {
                    timthay = 1;
                    tbResult.Text = "Khách hàng " + i.TenKH1 + " phải trả " + i.Tien1 + " nghìn đồng ";
                    break;
                }
            }
            if (timthay == 0)
            {
                tbResult.Text = "Khách hàng " + txtMaKH.Text + " không có trong danh sách";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
