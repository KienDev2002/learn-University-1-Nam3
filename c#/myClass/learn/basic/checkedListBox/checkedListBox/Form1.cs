using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkedListBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkListBoxLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkListBoxLeft.Items.Add("Ngo Kien");
            checkListBoxLeft.Items.Add("Ngoc Hiep");
            checkListBoxLeft.Items.Add("Bao Quoc");
            checkListBoxLeft.Items.Add("Phuong Bac");
        }

        private void checkListBoxRight_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnFromLeftToRight_Click(object sender, EventArgs e)
        {
         
            /*

            CheckedListBox.CheckedIndexCollection
           indexCollection = checkListBoxLeft.CheckedIndices;
            string strChecked = "";
            foreach (int i in indexCollection)
                strChecked += i + ";";
            MessageBox.Show(strChecked);
            */


            for (int i = 0; i < checkListBoxLeft.Items.Count; i++)
            {
                if (checkListBoxLeft.GetItemChecked(i))
                {
                    checkListBoxRight.Items.Add(checkListBoxLeft.Items[i]);
                    checkListBoxLeft.Items.RemoveAt(i);
                }
            }


           

        }

        private void btnFromRightToLeft_Click(object sender, EventArgs e)
        {
            

            CheckedListBox.CheckedItemCollection Checked = checkListBoxRight.CheckedItems;

            foreach (var item in Checked)
            {
                checkListBoxLeft.Items.Add(item);
            }
                while(Checked.Count > 0)
                {
                    checkListBoxRight.Items.Remove(Checked[0]);
                }
        }
    }
}
