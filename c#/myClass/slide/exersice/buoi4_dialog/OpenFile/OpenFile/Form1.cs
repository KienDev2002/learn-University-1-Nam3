namespace OpenFile
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog input = new OpenFileDialog();
            input.Filter = "Bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            input.InitialDirectory = "C:\\Users\\Dell Inspiron 5515\\Desktop\\ki5\\Kì 1\\Ki-I-Nam-3\\C#\\myClass\\slide\\exersice\\buoi4";
            input.FilterIndex = 2;
            input.Title = "Chọn ảnh để hiển thị";
            if(input.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(input.FileName);
            } else
            {
                MessageBox.Show("Bạn đã nhấn hủy!", "Open Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}