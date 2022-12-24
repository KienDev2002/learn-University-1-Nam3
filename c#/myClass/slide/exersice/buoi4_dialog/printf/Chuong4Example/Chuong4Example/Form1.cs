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

namespace Chuong4Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Document (*.txt)|*.txt|All files(*.*) | *.* ";
            openFileDialog1.InitialDirectory = "C:\\Users\\DELL\\Documents";
            openFileDialog1.Title = "Chọn file";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                    textBox1.Text = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text file(*.txt)|*.txt |Word Document(*.doc) | *.doc | All files(*.*) | *.* ";
            saveFileDialog1.InitialDirectory = "C:\\Users\\DELL\\Documents";
            saveFileDialog1.Title = "Lưu";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".doc";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(saveFileDialog1.FileName);
                try
                {
                    file.Write(textBox1.Text);
                    MessageBox.Show("Thành công");
                }
                catch
                {
                    MessageBox.Show("Lỗi ghi file");
                }
                file.Close();
            }
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
                textBox1.ForeColor = fontDialog1.Color;
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {

  

            //   thuộc tính Document của hộp thoại PrintDialog làm tài liệu sẽ được in ra. Sau đó, ta có thể thiết lập các thuộc tính khác của đối tượng PrintDialog.
            printDialog1.Document = printDocument1;


            if (printDialog1.ShowDialog() == DialogResult.OK)
                //Trong C#, đối tượng PrintDocument đại diện cho một tài liệu sẽ được in, PrintDocument gói gọn tất cả các thông tin cần thiết để in một trang. 
                //Những thông tin này chứa đựng các nội dung có thể sẽ được in. Chúng xử lý các sự kiện và thực hiện hoạt động in ấn. Khi đối tượng PrintDocument được tạo ra,
                printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox1.Text, new Font("Time New Roman", 24, FontStyle.Underline), Brushes.Black, 150, 100);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }
    }
}
