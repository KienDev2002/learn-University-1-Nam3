using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace formQLSV
{
    public partial class Form1 : Form
    {
        List<Student> students = new List<Student>();

        public void lockControl()
        {
            edit.Visible = false;
            remove.Visible = false;
            search.Visible = false;
            button3.Visible = false;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        

        private bool validate( string txtBox, string nameBox, string kindIOf)
        {
            string checkIsNumber = @"^\d+$";
            string checkIsNumberAge = @"^100|[1-9]?\d$";
            bool check = true;
            switch (kindIOf)
            {
                case "IsEmpty":
                    if (string.IsNullOrWhiteSpace(txtBox))
                    {
                        MessageBox.Show(nameBox + " không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        check = false;
                    }
                    break;




                case "IsNumber":
                    if (Regex.IsMatch(txtBox, checkIsNumber))
                    {
                        MessageBox.Show(nameBox + " không được viết số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        check = false;
                    }
                    break;
                case "checkAge":
                    if (!Regex.IsMatch(txtBox, checkIsNumberAge))
                    {
                        MessageBox.Show(nameBox + " không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        check = false;
                    }
                    break;

                
                case "checkComboBox":
                    bool checkComboBox = false;
                    if (groupBox1.Controls.Contains(txtSex))
                    {
                        for(int i = 0; i< txtSex.Items.Count; i++)
                        {
                            if (txtSex.Items[i].Equals(txtSex.Text) )
                            {

                                checkComboBox = false;
                                
                                break;
                                
                            }
                            else
                            {
                                checkComboBox = true;
                            }

                        }

                    }
                        if (checkComboBox==true)
                        {
                            MessageBox.Show(nameBox + " không hợp lệ (Nam hoặc Nữ)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            check = false;
                        }
  
                    break;

               
            }

            return check;

        }


        public bool checkValid(string id, string name, string address, string sex, string age, string university)
        {
            bool check = true;
            if (!validate(id, "id", "IsEmpty"))
            {
                check = false;

            }

            if (!validate(name, "name", "IsEmpty"))
            {
                check = false;

            }
            if (!validate(name, "name", "IsNumber"))
            {
                check = false;

            }
            if (!validate(sex, "sex", "IsEmpty"))
            {
                check = false;

            }
            if (!validate(sex, "sex", "IsNumber"))
            {
                check = false;

            }

            if (!validate(sex, "sex", "checkComboBox"))
            {
                check = false;
            

            }


            if (!validate(age, "age", "IsEmpty"))
            {
                check = false;

            }
            if (!validate(age, "age", "checkAge"))
            {
                check = false;

            }
            if (!validate(address, "address", "IsEmpty"))
            {
                check = false;

            }
            if (!validate(university, "university", "IsEmpty"))
            {
                check = false;

            }
            return check;
        }

        private void button1_Click(object sender, EventArgs e)
        {

           


            string id, name, address, university, sex;
            int age;
            id = txtMSV.Text;
            name = txtName.Text;
            sex = txtSex.Text;

            address = txtAddress.Text;
            university = txtUniversity.Text;
 
           
            do
            {
                if (checkValid(id, name, address, sex, txtAge.Text, university))
                {
                    for (int i = 0; i < dataGridViewSV.Rows.Count - 1; i++)
                    {
                        if (dataGridViewSV[0, i].Value.Equals(id))
                        {
                            MessageBox.Show("Mời bạn nhập lại id" + id + " đã tồn tại trong danh sách", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            return;
                        }

                    }
                  
                    age = Convert.ToInt32(txtAge.Text);
                    Student student = new Student(id, university, name, age, address, sex);
                    students.Add(student);
                   // dataGridViewSV.DataSource = null;
                   // dataGridViewSV.DataSource = students;
                
                   
                    //dataGridViewSV.RefreshEdit();
                    dataGridViewSV.Rows.Add(id, name, sex, age, address, university);
                }
                break;
            } while (!checkValid(id, name, address, sex, txtAge.Text, university));

       
            unlockControl();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void remove_Click(object sender, EventArgs e)
        {
            txtMSV.Text = "";
            txtName.Text = "";
            txtSex.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            txtUniversity.Text = "";
            resultSearch.Text = "";

   



        }

        private void search_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (String.IsNullOrWhiteSpace(txtMSV.Text))
            {
                MessageBox.Show("Mời bạn nhập id để tìm kiếm", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                check = false;
            }

            if (check)
            {
                string id;
                bool checkID = false;
                id = txtMSV.Text;
                foreach (Student student in students)
                {
                    if (student.getId().Equals(id))
                    {
                        checkID = true;
                        resultSearch.Text = "Sinh viên có id là " + id + " có trong danh sách.";
                        break;
                    }
                }
                if (checkID == false)
                {
                    MessageBox.Show("Mời bạn nhập lại id, id này không tồn tại", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }

        }

        private void resultSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void show_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSV.Text))
            {
                MessageBox.Show("Mời bạn nhập id cần sửa", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
                
                string id, name, address, university, sex;
                int age;
                id = txtMSV.Text;
                name = txtName.Text;
                sex = txtSex.Text;

                address = txtAddress.Text;
                university = txtUniversity.Text;
                bool check = false;
               
                do
                {
                    if (checkValid(id, name, address, sex, txtAge.Text, university))
                    {
                    for(int i = 0; i < dataGridViewSV.Rows.Count-1; i++)
                    {
                        if (dataGridViewSV[0, i].Value.Equals(id)){
                            check = true;
                            dataGridViewSV[0, i].Value = id;
                            dataGridViewSV[1, i].Value = name;
                            dataGridViewSV[2, i].Value = sex;
                            dataGridViewSV[3, i].Value = txtAge.Text;
                            dataGridViewSV[4, i].Value = address;
                            dataGridViewSV[5, i].Value = university;
                            break;
                        }

                    }
                    if (check==false)
                    {     
                        MessageBox.Show("Mời bạn nhập lại id" + id + " không tồn tại trong danh sách", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }

                }
                    break;
                } while (!checkValid(id, name, address, sex, txtAge.Text, university));



        }

        public void unlockControl()
        {
            edit.Visible = true;
            remove.Visible = true;
            search.Visible = true;
            button3.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lockControl();
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSV.Text))
            {
                MessageBox.Show("Mời bạn nhập id cần xóa", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            string id;
            id = txtMSV.Text;
            bool check = false;

            
                    for (int i = 0; i < dataGridViewSV.Rows.Count - 1; i++)
                    {
                        if (dataGridViewSV[0, i].Value.Equals(id))
                        {
                            check = true;
                            dataGridViewSV.Rows.RemoveAt(i);
                            break;
                        }

                    }
                    if (check == false)
                    
                        MessageBox.Show("Mời bạn nhập lại id" + id + " không tồn tại trong danh sách", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }

        

        
    }
}
