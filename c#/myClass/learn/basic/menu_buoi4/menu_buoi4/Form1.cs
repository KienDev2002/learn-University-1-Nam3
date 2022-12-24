using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menu_buoi4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void dTBai1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillWord fw = new FillWord();
            fw.ShowDialog();
        }
    }
}
