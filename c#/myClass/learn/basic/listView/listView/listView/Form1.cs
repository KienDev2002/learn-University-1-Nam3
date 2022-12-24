using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listView
{
    public partial class Form1 : Form
    {
        List<string> dsmh = new List<string>() { "Mã 01","Mã 02","Mã 03" };
        public Form1()
        {
            InitializeComponent();
        }

        private void lvDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            if(lvDS.SelectedItems.Count > 0)
            {
                item = lvDS.SelectedItems[0];
                txtMaH.Text = item.Text;
                txtTenH.Text = item.SubItems[1].Text;
                txtSL.Text = item.SubItems[2].Text;
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaH.Text;
            string ten = txtTenH.Text;
            string sl = txtSL.Text;
            if(ma.Equals("")|| ten.Equals("")||sl.Equals(""))
            {
                MessageBox.Show("Hãy nhập đủ dữ liệu");
            }

            else
            {
                if (dsmh.Contains(ma) == true)
                {
                    MessageBox.Show( ma + " đã tồn tại");
                }
                else
                {
                    dsmh.Add(ma);
                    ListViewItem item = new ListViewItem();
                    item.Text = ma;
                    item.SubItems.Add(ten);
                    item.SubItems.Add(sl);
                    lvDS.Items.Add(item);
                }
            }
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar == (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvDS.SelectedItems.Count > 0)
            {
                ListViewItem item = lvDS.SelectedItems[0];
                item.SubItems[1].Text = txtTenH.Text;
                item.SubItems[2].Text = txtSL.Text;
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDS.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có xóa không","tb",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    ListViewItem item = new ListViewItem();
                    item = lvDS.SelectedItems[0];
                    lvDS.Items.Remove(item);
                    dsmh.Remove(item.Text);
                }

            }
            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
