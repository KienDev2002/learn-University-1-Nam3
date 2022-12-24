using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai2_TH2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            DriveInfo[] drives = DriveInfo.GetDrives(); // lấy ra các ổ
            foreach (DriveInfo dr in drives)
            {
                cmbOdia.Items.Add(dr.Name);//lấy tên ổ đĩa vào cmb
            }
           

        }

        private void cmbOdia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbThuMuc.SelectedItem = -1;
            DirectoryInfo directory = new DirectoryInfo(cmbOdia.Text);
            DirectoryInfo[] directories = directory.GetDirectories("*.*");
            FileInfo[] files = directory.GetFiles();
            foreach (DirectoryInfo dir in directories)
            {
                cmbThuMuc.Items.Add(cmbOdia.Text + dir.Name);
            }
        }

        private void cmbThuMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOdia.Text == "")
            {
                MessageBox.Show("Vui lòng chọn ổ đĩa trước !", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                cmbThuMuc.SelectedIndex = -1;
            }
            else
            {
                lstFiles.Items.Clear();
                rtbLoiBaiHat.Text = "";
                string[] files = Directory.GetFiles(cmbThuMuc.Text);
                foreach (string str in files)
                {
                    lstFiles.Items.Add(str);
                }
            }
        }

        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            
            List<string> s1 = splitString('.');

            string giaitri;
            if ("txt".Equals(s1[s1.Count - 1]))
            {
                FileStream fs = new FileStream(s1[s1.Count - 2] + ".txt", FileMode.Open);
                StreamReader rd = new StreamReader(fs, Encoding.UTF8);
                giaitri = rd.ReadToEnd();
                rtbLoiBaiHat.Text = giaitri;

            }
            else if ("mp3".Equals(s1[s1.Count - 1]))
            {
                axWindowsMediaPlayer1.URL = s1[s1.Count - 2] + ".mp3";
            }
            else
            {
                MessageBox.Show("Tệp không hợp lệ!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            

        }

        private List<string> splitString(char c)
        {
            List<string> s = new List<string>();
            string taptin = lstFiles.SelectedItem.ToString();
            string[] str = taptin.Split(c);
            foreach (string lst in str)
            {
                s.Add(lst);
            }
            return s;
        }
    }
}
