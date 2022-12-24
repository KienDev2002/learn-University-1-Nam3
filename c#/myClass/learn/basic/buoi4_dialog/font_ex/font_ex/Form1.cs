using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace font_ex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            addFont();
            addSize();
        }

        private void addFont()
        {
            cbFont.Items.Add("Microsoft Sans Serif");
            cbFont.Items.Add("Mistral");
            cbFont.Items.Add("Microsoft Yi Baiti");
            cbFont.Items.Add("MS PGothic");
            cbFont.Items.Add("MS Reference Specialty");
            cbFont.Items.Add("Papyrus");

        }

        private void addSize()
        {
            cbSize.Items.Add("6");
            cbSize.Items.Add("7");
            cbSize.Items.Add("8");
            cbSize.Items.Add("9");
            cbSize.Items.Add("10");
            cbSize.Items.Add("15");
            cbSize.Items.Add("20");
            cbSize.Items.Add("25");
            cbSize.Items.Add("30");
            cbSize.Items.Add("35");
            cbSize.Items.Add("40");
            cbSize.Items.Add("45");
            cbSize.Items.Add("50");
         
        }

        private void cbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTitle.Text.Equals(""))
            {
                MessageBox.Show("Mời bạn nhập tiêu đề cần thay đổi", "thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string fontFamily = cbFont.SelectedItem.ToString();
                txtTitle.Font = new Font(fontFamily,txtTitle.Font.Size, txtTitle.Font.Style);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTitle.Text.Equals(""))
            {
                MessageBox.Show("Mời bạn nhập tiêu đề cần thay đổi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                float fontSize = Convert.ToSingle(cbSize.SelectedItem.ToString());
                txtTitle.Font = new Font(txtTitle.Font.FontFamily, fontSize, txtTitle.Font.Style);
            }
        }

        private void cbDam_CheckedChanged(object sender, EventArgs e)
        {
            if (txtTitle.Text.Equals(""))
            {
                MessageBox.Show("Mời bạn nhập tiêu đề cần thay đổi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //txtTitle.Font: là nó chứa toàn bộ gồm FontFamily, Size, và ^ là dấu phủ định trong rgex. Nếu như FontStyle.Bold = true thì FontStyle.Bold = false và ngược lại.
                txtTitle.Font = new Font(txtTitle.Font,txtTitle.Font.Style ^ FontStyle.Bold);
            }
        }

        private void cbNghieng_CheckedChanged(object sender, EventArgs e)
        {
            if (txtTitle.Text.Equals(""))
            {
                MessageBox.Show("Mời bạn nhập tiêu đề cần thay đổi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //txtTitle.Font: là nó chứa toàn bộ gồm FontFamily, Size, và ^ là dấu phủ định trong rgex. Nếu như FontStyle.Bold = true thì FontStyle.Bold = false và ngược lại.
                txtTitle.Font = new Font(txtTitle.Font, txtTitle.Font.Style ^ FontStyle.Italic);
            }
        }

        private void cbGachChan_CheckedChanged(object sender, EventArgs e)
        {
            if (txtTitle.Text.Equals(""))
            {
                MessageBox.Show("Mời bạn nhập tiêu đề cần thay đổi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //txtTitle.Font: là nó chứa toàn bộ gồm FontFamily, Size, và ^ là dấu phủ định trong rgex. Nếu như FontStyle.Bold = true thì FontStyle.Bold = false và ngược lại.
                txtTitle.Font = new Font(txtTitle.Font, txtTitle.Font.Style ^ FontStyle.Underline);
            }
        }

        private void rdXanh_CheckedChanged(object sender, EventArgs e)
        {
            if (txtTitle.Text.Equals(""))
            {
                MessageBox.Show("Mời bạn nhập tiêu đề cần thay đổi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtTitle.ForeColor = Color.Green;
            }
            
        }

        private void rdDo_CheckedChanged(object sender, EventArgs e)
        {

            if (txtTitle.Text.Equals(""))
            {
                MessageBox.Show("Mời bạn nhập tiêu đề cần thay đổi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtTitle.ForeColor = Color.Red;
            }
        }

        private void rdHong_CheckedChanged(object sender, EventArgs e)
        {

            if (txtTitle.Text.Equals(""))
            {
                MessageBox.Show("Mời bạn nhập tiêu đề cần thay đổi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtTitle.ForeColor = Color.Pink;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnChonFont_Click(object sender, EventArgs e)
        {
            FontDialog dlgFont = new FontDialog();
            dlgFont.ShowColor = true;
            if (dlgFont.ShowDialog() == DialogResult.OK)
            {
                txtTitle.Font = dlgFont.Font;
                txtTitle.ForeColor = dlgFont.Color;
            }
            else
                MessageBox.Show("You clicked Cancel", "Font Dialog",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
