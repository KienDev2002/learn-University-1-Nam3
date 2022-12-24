using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listViewQLVH
{
    public partial class Form1 : Form
    {
        List<string> dsmp = new List<string>() { "Mã 01"};
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaP.Text;
            string ten = txtTenP.Text;
            if (ma.Equals("") || ten.Equals(""))
            {
                MessageBox.Show("Hãy nhập đủ dữ liệu");
            }

            else
            {
                if (dsmp.Contains(ma) == true)
                {
                    MessageBox.Show(ma + " đã tồn tại");
                }
                else
                {
                    dsmp.Add(ma);
                    ListViewItem item = new ListViewItem();
                    item.Text = ma;
                    item.SubItems.Add(ten);
     

                    lvDS.Items.Add(item);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
                ListViewItem item = lvDS.SelectedItems[0];
                item.Text = txtMaP.Text;
                item.SubItems[1].Text = txtTenP.Text;
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
        
                if (MessageBox.Show("Bạn có xóa không", "tb", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ListViewItem item = new ListViewItem();
                    item = lvDS.SelectedItems[0];
                    lvDS.Items.Remove(item);
                    dsmp.Remove(item.Text);
                }

            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có thoát không", "tb", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void lvDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDS.SelectedItems.Count > 0)
            {
                ListViewItem item = new ListViewItem();
                item = lvDS.SelectedItems[0];
                txtMaP.Text = item.Text;
                txtTenP.Text = item.SubItems[1].Text;
             
            }
        }
    }
}
