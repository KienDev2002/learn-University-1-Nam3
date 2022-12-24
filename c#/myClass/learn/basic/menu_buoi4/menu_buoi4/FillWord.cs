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
    public partial class FillWord : Form
    {
        public FillWord()
        {
            InitializeComponent();
            QLFile qLFile = new QLFile();
            string s = qLFile.readCH(@"C:\Users\Dell Inspiron 5515\Desktop\ki5\Kì 1\Ki-I-Nam-3\C#\myClass\learn\basic\menu\CauHoi1");
            question.Text = s;
        }

        private void FillWord_Load(object sender, EventArgs e)
        {

        }
    }
}
