using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuStrip
{
    public partial class DienTu : Form
    {
        List<string> lstDapAn;
        List<TextBox> textTL;
        public DienTu(string tepCH , string tepDA)
        {
            InitializeComponent();
            FileManager file = new FileManager();
            string str = file.ReadQuestions(tepCH);

            richTextBox1.Text = str;
            lstDapAn = new List<string>();
            lstDapAn = file.ReadAnswers(tepDA);
            textTL = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DienTu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for( int i = 0; i < lstDapAn.Count; i++)
            {
                textTL[i].Text = lstDapAn[i];
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int diem = 0;
            for (int i = 0; i< lstDapAn .Count; i++)
            {
                if (lstDapAn[i].Equals(textTL[i].Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    diem++;
                    textTL[i].BackColor = Color.GreenYellow;
                }
                else
                {
                    textTL[i].BackColor = Color.Orange;
                }

            }
            MessageBox.Show("Số điểm có " + diem.ToString());
        }
    }
}
