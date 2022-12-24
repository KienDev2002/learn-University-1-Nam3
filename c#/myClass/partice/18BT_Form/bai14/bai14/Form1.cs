using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai14
{
    public partial class Form1 : Form
    {
        int stt = 0;
        List<string> DS = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void setDataCB()
        {
            cbKhoaHoc.Items.Add("Công trình");
            cbKhoaHoc.Items.Add("Công nghệ thông tin");
            cbKhoaHoc.Items.Add("Vận tải kinh tế");

            cbKhoa.Items.Add("53");
            cbKhoa.Items.Add("54");
            cbKhoa.Items.Add("55");

            lbDSGT.Items.Add("Tin học đại cương");
            lbDSGT.Items.Add("Cơ lý thuyết");
            lbDSGT.Items.Add("Triết học");
            lbDSGT.Items.Add("Vật lý đại cương");
            lbDSGT.Items.Add("Giải tích");
            lbDSGT.Items.Add("Cơ sở dữ liệu");
            lbDSGT.ScrollAlwaysVisible = true; //tạo thanh scrollbar
        }

        //chọn nhiều trong combobox: vào properties chọn  selectMode: multi
        private void Form1_Load(object sender, EventArgs e)
        {
            setDataCB();
            this.KeyPreview = true;
            listView1.MultiSelect = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes ==
              MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Application.Exit();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode.Equals(Keys.H))
                {
                    btnThoat_Click(null, null);
                }
                if (e.KeyCode.Equals(Keys.L))
                {
                    btnLamLai_Click(null, null);
                }
                if (e.KeyCode.Equals(Keys.K))
                {
                    btnDangKy_Click(null, null);
                }
                if (e.KeyCode.Equals(Keys.X))
                {
                    btnXoa_Click(null, null);
                }
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            txtHTen.Text = "";
            cbKhoa.SelectedIndex = -1;
            cbKhoaHoc.SelectedIndex = -1;
            lbDSGT.SelectedIndex = -1;
        }
        private void MessNotification(String message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            stt++;
            int check = 1;
            if(txtHTen.TextLength==0 || cbKhoa.SelectedIndex ==-1 || cbKhoaHoc.SelectedIndex == -1)
            {
                MessNotification("Hãy điền và chọn đầy đủ thông tin");
                check = 0;
               
            }
            if(lbDSGT.SelectedIndices.Count == 0)
            {
                MessNotification("Hãy chọn giáo trình");
                check = 0;

            }

            if(check == 1)
            {
                string HoTen = txtHTen.Text;
                string KhoaHoc = cbKhoaHoc.SelectedItem.ToString();
                string Khoa = cbKhoa.SelectedItem.ToString();
                string DanhSach = "";

                ListViewItem item = new ListViewItem();
                item.Text = HoTen;
                item.SubItems.Add(KhoaHoc);
                item.SubItems.Add(Khoa);

                foreach(Object o in lbDSGT.SelectedItems)
                {
                    DanhSach+=o.ToString() + ", ";
                }
                item.SubItems.Add(DanhSach);
                item.SubItems.Add(stt.ToString());

                listView1.Items.Add(item);
                DS.Add(HoTen + "|" + KhoaHoc + "|" +
                         Khoa + "|" + DanhSach +  "|"+ stt.ToString());
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                if (listView1.SelectedIndices.Count == 0)
                {
                    MessNotification("Bạn hãy chọn người muốn xóa");
                }
                else
                {
                    int index = 0;
                    if (DialogResult.Yes ==
                     MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        ListViewItem item = new ListViewItem();
                        item = listView1.SelectedItems[0];
                        int i = item.Index;
                        listView1.Items.Remove(item);
                        DS.RemoveAt(i);
                    }
                    listView1.Items.Clear();
                    stt = 1; 
                    String[]a = new string[DS.Count];
                    for(int i = 0; i< DS.Count; i++)
                    {
                        a = DS[i].Split('|');
                        string HoTen = a[0];
                        string KhoaHoc = a[1];
                        string Khoa = a[2];
                        string DanhSach = a[3];
                        ListViewItem item = new ListViewItem();
                        item.Text = HoTen;
                        item.SubItems.Add(KhoaHoc);
                        item.SubItems.Add(Khoa);
                        item.SubItems.Add(DanhSach);
                        item.SubItems.Add(stt.ToString());
                        listView1.Items.Add(item);
                        stt++;
                    }
                }
            }
        }
    }
}
