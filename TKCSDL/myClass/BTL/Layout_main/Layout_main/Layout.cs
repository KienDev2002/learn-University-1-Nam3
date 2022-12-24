using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layout_main
{
    public partial class Layout : Form
    {
        private Form currenFormChild;
        private Control currenControl;
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
            StateSearch(false, "","","");
        }

        private void StateSearch(bool s, string s1, string s2, string s3)
        {
            cbSeacrh1.Visible = s;
            cbSearch2.Visible = s;
            cbSearch3.Visible = s;
            lbSearch1.Text = s1;
            lbSearch2.Text = s2;
            lbSearch3.Text = s3;
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

            StateSearch(true, "Serach by name", "Serach by team", "Serach by goal");
            cbSeacrh1.Items.Add("Manchester Uninted");
            cbSeacrh1.Items.Add("Manchester city");
            cbSeacrh1.Items.Add("Barca");
        }

       

        private void btnPlayer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Player());
            lbtitle.Text = btnPlayer.Text;

            StateSearch(false, "", "", "");
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Match());
            lbtitle.Text = btnMatch.Text;

            StateSearch(true, "Search by home team", "Serach by goal", "Serach by red card");
        }

        private void picImage_official_Click(object sender, EventArgs e)
        {
            if (currenFormChild != null)
            {
                currenFormChild.Close();
            }
            lbtitle.Text = "Home";
            StateSearch(false, "", "", "");

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

            StateSearch(false, "", "", "");
            lbtitle.Text = btnLogout.Text;
        }
    }
}
