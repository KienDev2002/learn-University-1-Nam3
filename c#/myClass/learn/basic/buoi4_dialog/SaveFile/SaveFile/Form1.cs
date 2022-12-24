namespace SaveFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog output = new SaveFileDialog();
            output.Filter = "Text file(*.txt)|*.txt|Word document(*.doc)|*.doc|All files(*.*)|*.*";
            output.InitialDirectory = "C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\slide\\exersice\\buoi4";
            output.FilterIndex = 2;
            output.Title = "Chọn File để lưu";
          
            if(output.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(output.FileName); 
                try
                {
                    file.Write(textBox1.Text);
                    MessageBox.Show("Thành công!", "Thông báo");
                } catch {
                    MessageBox.Show("Lỗi ghi file!", "Thông báo");
                }
                file.Close();
            } else
            {
                MessageBox.Show("Bạn đã nhấn hủy!", "Thông báo");
            }
        }
    }
}