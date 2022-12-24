using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumericUpDown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //Trực quan hơn so với textbox như sẽ không cần xét
            //Điều kiện có phải là số không, textbox có phạm vi từ đâu đến đâu không vượt quá cái giới hạn mình yêu cầu.

            // interceeprt: true tức là có thể điều khiển lên xuống bằng phím.
            // increment: tăng theo bước nhảy cụ thể nào đó.
            // maximum: nhập 1 giá trị max nó tăng lên sẽ ko vượt quá max
            // tương tự là minximum
            // thousandSepartor: Khi vượt quá 1000 trở đi là có dấu chấm đánh dấu.
            // đặc biệt: kiểu dữ liệu mặc định nó là decimal có thể ép kiểu int, còn nếu cta chuyển về hexa decimal = true thì nó sẽ về số hệ 16. 
            
            
            
            
            
            
            
            
            
            
            
            
            
          //  int i = 0;
          //  i = (int)soA.Value; // cần ép kiểu

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            int a, b;
            float x;
            string str = "";
            a = Convert.ToInt16(soA.Value);
            b = Convert.ToInt16(soB.Value);
            if (a == 0)
            {
                if (b == 0)
                    str = str + "Phương trình vô số nghiệm";
                else
                    str = str + "Phương trình vô nghiệm";
            }
            else
            {
                x = (float)-b / a;
                str = str + "Phương trình có một nghiệm là: x=" + x.ToString();
            }
            result.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
