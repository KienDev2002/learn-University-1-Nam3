using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bai3_diemSV
{
    public partial class Form1 : Form
    {
        string checkIsNumber = @"^\d{1}\.{0,1}\d{0,1}$";
        int tongTC = 0;
        double tongD = 0;
        double DTB = 0;
        List<string> dsmh = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddComboBox()
        {
            cmbMH.Items.Add("Tin học đại cương");
            cmbMH.Items.Add("Giải tích F1");
            cmbMH.Items.Add("Tiếng Anh A0");
            cmbMH.Items.Add("Triết học Mác - Lênin");
            cmbMH.Items.Add("Vật lý F1");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddComboBox();
            txtTC.Enabled = false;
            this.KeyPreview = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //trả về true nếu bấm phím ALT
            if (e.Alt)
            {
               
                if (e.KeyCode.Equals(Keys.H))
                {
                    btnThoat_Click(null, null);
                }

                if (e.KeyCode.Equals(Keys.D))
                {
                   BtnTVDS_Click(null, null);
                }

                if (e.KeyCode.Equals(Keys.T))
                {
                    BtnTinh_Click(null, null);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void CmbMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (cmbMH.Text)
            {
                case "Tin học đại cương":
                    txtTC.Text = "2";
                    break;
                case "Giải tích F1":
                    txtTC.Text = "3";
                    break;
                case "Tiếng Anh A0":
                    txtTC.Text = "3";
                    break;
                case "Triết học Mác - Lênin":
                    txtTC.Text = "2";
                    break;
                case "Vật lý F1":
                    txtTC.Text = "3";
                    break;
            
            }

     
        }

        private void TxtDiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
           
            if (!char.IsDigit(c) && !char.IsControl(c) && c != 46) // 46 == "."
            {
                e.Handled = true;
               
            }
        }

        private void BtnTVDS_Click(object sender, EventArgs e)
        {
           

            int check = 1;
            if(cmbMH.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn môn học. Hãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = 0;

            }
            if (txtDiem.TextLength==0)
            {
                MessageBox.Show("Không được để trống điểm. Hãy thử lại!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                check = 0;
                return;
            }

            if (!Regex.IsMatch(txtDiem.Text, checkIsNumber))
            {
                MessageBox.Show("Điểm phải từ số 0 đến 10. Hãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = 0;
                return;

            }


            if (Convert.ToDouble(txtDiem.Text) > 10 || Convert.ToDouble(txtDiem.Text) < 0)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10. Hãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = 0;
            }

            if (check == 1)
            {
                if (dsmh.Contains(cmbMH.Text))
                {
                    MessageBox.Show("Môn học này đã tồn tại. Hãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                   

                    ListViewItem item = new ListViewItem();
                    item.Text = cmbMH.Text;
                    item.SubItems.Add(txtTC.Text);
                    item.SubItems.Add(txtDiem.Text);
                   
                    lvDS.Items.Add(item);
                    dsmh.Add(cmbMH.Text);
                }
            }


        }


        private void BtnTinh_Click(object sender, EventArgs e)
        {
           
            if(lvDS.Items.Count == 0)
            {
                MessageBox.Show("Bạn chưa nhập thông tin cho môn học nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tongTC = 0;
                tongD = 0;
                foreach (ListViewItem item1 in lvDS.Items)
                    {

                        tongTC += Convert.ToInt32(item1.SubItems[1].Text);
                        tongD += Convert.ToDouble(item1.SubItems[2].Text) * Convert.ToInt32(item1.SubItems[1].Text);

                    }
                    DTB = tongD / tongTC;
                    txtTongTC.Text = Convert.ToString(tongTC);
                    txtTongDiem.Text = Convert.ToString(tongD);
                    txtDTB.Text = Convert.ToString(DTB);
                
            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvDS.SelectedItems.Count > 0)
            {
                int check = 1;
                if (cmbMH.SelectedItem == null)
                {
                    MessageBox.Show("Chưa chọn môn học. Hãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = 0;

                }
                if (txtDiem.TextLength == 0)
                {
                    MessageBox.Show("Không được để trống điểm. Hãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = 0;
                    return;
                }

                if (!Regex.IsMatch(txtDiem.Text, checkIsNumber))
                {
                    MessageBox.Show("Điểm phải từ số 0 đến 10. Hãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = 0;
                    return;

                }


                if (Convert.ToDouble(txtDiem.Text) > 10 || Convert.ToDouble(txtDiem.Text) < 0)
                {
                    MessageBox.Show("Điểm phải từ 0 đến 10. Hãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = 0;
                }

                if (check == 1)
                {
                    ListViewItem item = new ListViewItem();
                    item = lvDS.SelectedItems[0];
                    item.SubItems[2].Text = txtDiem.Text;
                }
            
            }
        }

        private void lvDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDS.SelectedItems.Count > 0)
            {
                ListViewItem item = new ListViewItem();
                item = lvDS.SelectedItems[0];
                cmbMH.Text = item.Text;
                txtTC.Text = item.SubItems[1].Text;
                txtDiem.Text= item.SubItems[2].Text;



            

            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lvDS.SelectedItems.Count > 0)
            {
                if(MessageBox.Show("Bạn có muốn xóa không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ListViewItem item = new ListViewItem();
                    item = lvDS.SelectedItems[0];
                    lvDS.Items.Remove(item);
                    dsmh.Remove(item.Text);
                }

            }
        }

        private void lvDS_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
        
        }

        private void lvDS_SizeChanged(object sender, EventArgs e)
        {
           
        }
    }
}
