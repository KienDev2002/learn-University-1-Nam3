using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace htcolor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlgColor = new ColorDialog();
            dlgColor.FullOpen = true;
            if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.BackColor = dlgColor.Color;
            else
                MessageBox.Show("You clicked Cancel ", "Color Dialog",MessageBoxButtons.OK, MessageBoxIcon.Information);
                
        }

        private void lbMaunen_Click(object sender, EventArgs e)
        {
        }

        private void btnMauchu_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
   

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void rdMauxanh_CheckedChanged(object sender, EventArgs e)
        {
            if(rdMauxanh.Checked)
                this.BackColor= Color.Green;
        }

        private void rdMaudo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMaudo.Checked)
                this.BackColor = Color.Red;
        }

        private void rdMauvang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMauvang.Checked)
                this.BackColor = Color.Yellow;
        }
    }
}
