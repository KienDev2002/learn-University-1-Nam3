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

namespace richTextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // là control tương tự như textbox nhưng nó có những đặc điểm nâng cao hơn.

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string filePath = "C:\\Users\\Dell Inspiron 5515\\Desktop\\rtb.rtf";
            bool isFileExists = File.Exists(filePath);
            try
            {
                if (isFileExists)
                {

                    richTextBox1.LoadFile(filePath, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Đọc file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("File này không tồn tại mời bạn sửa lại đường dẫn");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            richTextBox1.SaveFile("C:\\Users\\Dell Inspiron 5515\\Desktop\\rtbSaveFile.rtf", RichTextBoxStreamType.RichText);
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
