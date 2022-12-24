using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timer
{
    public partial class Form1 : Form
    {
        int h, m, s, ms;

        private void timer1_Tick(object sender, EventArgs e)
        {
            ms++;
            if(ms == 100)
            {
                ms = 0;
                s += 1;
            }

            if (s == 60)
            {
                s = 0;
                m += 1;
            }

            if (m == 60)
            {
                m = 0;
                h += 1;
            }
            label1.Text = String.Format("{0}:{1}:{2}:{3}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'), ms.ToString().PadLeft(2, '0'));
        
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            h = 0;
            m = 0;
            s = 0;
            ms = 0;
            label1.Text = "00:00:00:00";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public Form1()
        {
            InitializeComponent();
        }


















        // interval = 100 tức là sau 1 khoảng 1/10 giây là nó thực hiện event tick cứ như vậy sau khoảng tg đó là gọi, giống như sleep vậy

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }
}
