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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace checkradio_checkbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool validate(string txtBox, string nameBox, string kindIOf)
        {
            bool check = true;
            switch (kindIOf)
            {
                case "Radio":

                    if (!radio1.Checked || !radio2.Checked)
                    {
                        check = false;
                    }
                    break;
            }
              
            return check;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool check1 = true;
            bool check2 = true;
            if (!radio1.Checked && !radio2.Checked)
            {
                check1 = false;
            }
            if (!checkBox3.Checked && !checkBox4.Checked)
            {
                check2 = false;
            }

            result.Text = "" + check1 + check2;



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void remale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
