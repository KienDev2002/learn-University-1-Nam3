using baitaplon.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class Layout : Form
    {
        private Form currenFormChild;
        private Control currenControl;
        bool sideBar;
        public Layout()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            this.Size = new System.Drawing.Size(1509, 804);
            panel_left.Size = new System.Drawing.Size(250, 827);
            panel_top.Size = new System.Drawing.Size(1319, 50);
            panel_bottom.Size = new System.Drawing.Size(1319, 130);
            picImage_official.Size = new System.Drawing.Size(190, 230); 
            */
            StateSearch(false);
        }

        

        private void StateSearch(bool s)
        {

            PictureBox imageControl = new PictureBox();
            PictureBox imageControl2 = new PictureBox();
            cbSeacrh1.Visible = s;
            cbSearch2.Visible = s;
            cbSearch3.Visible = s;
 
            panel_bottom_right.Visible = s;
            panel_bottom_center.Visible = s;
            if (s == false)
            {
                imageControl.SizeMode = PictureBoxSizeMode.StretchImage;
                Bitmap image = new Bitmap("C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\BTL\\baitaplon\\baitaplon\\baitaplon\\Resources\\logo_home_1.png");
                imageControl.Dock = DockStyle.Fill;
                imageControl.Image = (Image)image;
                panel_bottom.Controls.Add(imageControl);
                
            }
            else
            {
                imageControl.Visible = !s;
                imageControl2.Visible = !s;
                picHome.Visible = !s;

            }
        }


        private void OpenChildForm(Form childForm)
        {
            if(currenFormChild != null)
            {
                currenFormChild.Close();
            }
            currenFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

      

        private void btnClub_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Club());
            lbtitle.Text = btnClub.Text;

            panel_bottom.Visible = true;
            StateSearch(true);
            cbSeacrh1.Items.Clear();
            cbSeacrh1.Items.Add("Manchester Uninted");
            cbSeacrh1.Items.Add("Manchester city");
            cbSeacrh1.Items.Add("Barca");
            cbSeacrh1.Text = "Search by name";
            cbSearch2.Text = "Search by team";
            cbSearch3.Text = "Search by goal";
        }

       

        private void btnPlayer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Player());
            lbtitle.Text = btnPlayer.Text;

            StateSearch(false);
            cbSeacrh1.Items.Clear();

            panel_bottom_right.Visible = true;
            panel_bottom_center.Visible = true;

            panel_bottom.Visible = true;
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Match());
            lbtitle.Text = btnMatch.Text;

            StateSearch(true);
            cbSeacrh1.Text = "Search by home team";
            cbSearch2.Text = "Serach by goal";
            cbSearch3.Text = "Serach by red card";

            panel_bottom.Visible = true;
        }

        private void picImage_official_Click(object sender, EventArgs e)
        {
            if (currenFormChild != null)
            {
                currenFormChild.Close();
            }
            lbtitle.Text = "Home";
            StateSearch(false);
            picHome.Visible = true;

            panel_bottom.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel_body_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel_bottom_center_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbSeacrh1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (currenFormChild != null)
            {
                currenFormChild.Close();
            }
            lbtitle.Text = "Home";
            StateSearch(false);
            picHome.Visible = true;
            panel_bottom.Visible = true;
            if (MessageBox.Show("Bạn có muốn đăng xuất không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login login = new Login();
                this.Hide();
                login.Show();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Report());
            lbtitle.Text = btnReport.Text;

            StateSearch(false);
            panel_bottom.Visible = false;
        }

        private void stateMenu(bool s,string club, string player, string match, string logout, string report) { 
        
            picImage_official.Visible = s;
            btnClub.Text = club;
            btnPlayer.Text = player;
            btnMatch.Text = match;
            btnLogout.Text = logout;
            btnReport.Text = report;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            timerSidebar.Start();
        }

        private void timerSidebar_Tick(object sender, EventArgs e)
        {
            if (sideBar)
            {
                stateMenu(false, "", "", "", "", "");
                panel_left.Padding = new Padding(0,200, 0, 0);
                panel_left.Width -= 10;
                if(panel_left.Width == panel_left.MinimumSize.Width)
                {
                    sideBar = false;
                    timerSidebar.Stop();
                }

            }
            else
            {
                stateMenu(true, "Club", "Player", "Match", "Logout", "Report");

                panel_left.Padding = new Padding(0, 0, 0, 0);
                panel_left.Width += 10;
                if(panel_left.Width == panel_left.MaximumSize.Width)
                {
                    sideBar=true;
                    timerSidebar.Stop();
                }
            }
        }

        private void panel_bottom_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
