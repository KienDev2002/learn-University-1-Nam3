using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace printDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            SaveFileDialog output = new SaveFileDialog();
            output.Filter = "Text file(*.txt)|*.txt|Word document(*.doc)|*.doc|All files(*.*)|*.*";
            output.InitialDirectory = "C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\slide\\exersice\\buoi4";
            output.FilterIndex = 2;
            output.Title = "Chọn File để lưu";

            if (output.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(output.FileName);
                try
                {
                    file.Write(textBox1.Text);
                    MessageBox.Show("Thành công!", "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Lỗi ghi file!", "Thông báo");
                }
                file.Close();
            }
            else
            {
                MessageBox.Show("Bạn đã nhấn hủy!", "Thông báo");
            }
        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog input = new OpenFileDialog();
            input.Filter = "Text file(*.txt)|*.txt|Word document(*.doc)|*.doc|All files(*.*)|*.*";
            input.InitialDirectory = "C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\slide\\exersice\\buoi4";
            input.FilterIndex = 2;
            input.Title = "Chọn ảnh để hiển thị";
            if (input.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(input.FileName);
                try
                {
                    textBox1.Text =  file.ReadToEnd();
                    MessageBox.Show("Thành công!", "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Lỗi ghi file!", "Thông báo");
                }
                file.Close();
            }
            else
            {
                MessageBox.Show("Bạn đã nhấn hủy!", "Open Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog dlgFont = new FontDialog();
            dlgFont.ShowColor = true;
            if (dlgFont.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = dlgFont.Font;
                textBox1.ForeColor = dlgFont.Color;
            }
            else
                MessageBox.Show("You clicked Cancel", "Font Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlgColor = new ColorDialog();
            dlgColor.FullOpen = true;
            if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.BackColor = dlgColor.Color;
            else
                MessageBox.Show("You clicked Cancel ", "Color Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //PrintDialog printDialog1 = new PrintDialog();

            //Trong C#, đối tượng PrintDocument đại diện cho một tài liệu sẽ được in, PrintDocument gói gọn tất cả các thông tin cần thiết để in một trang. 
            //Những thông tin này chứa đựng các nội dung có thể sẽ được in. Chúng xử lý các sự kiện và thực hiện hoạt động in ấn. Khi đối tượng PrintDocument được tạo ra,
            //  ta có thể đặt thuộc tính Document của hộp thoại PrintDialog làm tài liệu sẽ được in ra. Sau đó, ta có thể thiết lập các thuộc tính khác của đối tượng PrintDialog.
            //PrintDocument printDocument1 = new PrintDocument();
            // thuộc tính Document của hộp thoại PrintDialog làm tài liệu sẽ được in ra
            //printDialog1.Document = printDocument1;
            //printDialog1.ShowDialog(): mở hộp thoại Print Dialog 
           // if (printDialog1.ShowDialog() == DialogResult.OK)
            //    printDocument1.Print();
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }
        // Sự kiện PrintPage được đưa ra cho mỗi trang được in.


        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox1.Text, new Font("Arial", 30, FontStyle.Bold), Brushes.Black, 150, 100);
        }
    }
}
