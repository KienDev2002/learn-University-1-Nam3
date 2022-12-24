using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lesson1
{


    public partial class Form1 : Form
    {
        string capital = "";
        string country = "";
        List<Conutry_Capital> ListConutry_Capitals  = new List<Conutry_Capital>();
        public Form1()
        {
            InitializeComponent();
            EmptyOption();
            addData();
        }

        private void addData()
        {
            
            ListConutry_Capitals.Add(new Conutry_Capital("France", "Paris"));
            ListConutry_Capitals.Add(new Conutry_Capital("Japan", "Tokyo"));
            ListConutry_Capitals.Add(new Conutry_Capital("Hungary", "Budapest"));
            ListConutry_Capitals.Add(new Conutry_Capital("Spain", "Madrid"));
            ListConutry_Capitals.Add(new Conutry_Capital("Turkey", "Ankara"));
            ListConutry_Capitals.Add(new Conutry_Capital("The UK", "London"));
            ListConutry_Capitals.Add(new Conutry_Capital("Italy", "Rome"));
            ListConutry_Capitals.Add(new Conutry_Capital("Arrgentina", "Buenos Aires"));
            ListConutry_Capitals.Add(new Conutry_Capital("Brazil", "Brazil"));
            ListConutry_Capitals.Add(new Conutry_Capital("The USA", "Washington"));
        }

        private void EmptyOption()
        {
          
            rdAnkara.Checked = false;
            rdBrazil.Checked = false;
            rdBuenos.Checked = false;
            rdTokyo.Checked = false;
            rdRome.Checked = false;
            rdWashington.Checked = false;
            rdMar.Checked = false;
            rdoLondon.Checked = false;
            rdoBudapest.Checked = false;
            rdParis.Checked = false;
        }

        private string getNotification(string country)
        {
            EmptyOption();
            return "Hãy chọn thành phố cho " + country;
        }


        bool check(string country, string capital)
        {

            foreach (Conutry_Capital item in ListConutry_Capitals)
            {
                if(item.Country.Equals(country) && item.Capital.Equals(capital)){
                    return true;
                }
            }
            return false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

      


        private void rdFance_CheckedChanged(object sender, EventArgs e)
        {
            country = rdFance.Text;
            label1.Text = getNotification(country);
        }
        private void rdJapan_CheckedChanged(object sender, EventArgs e)
        {
             country = rdJapan.Text;
            label1.Text = getNotification(country);
        }

        private void rdHungary_CheckedChanged(object sender, EventArgs e)
        {
             country = rdHungary.Text;
            label1.Text = getNotification(country);
        }

        private void rdSpain_CheckedChanged(object sender, EventArgs e)
        {
             country = rdSpain.Text;
            label1.Text = getNotification(country);
        }

        private void rdTurkey_CheckedChanged(object sender, EventArgs e)
        {
             country = rdTurkey.Text;
            label1.Text = getNotification(country);
        }

        private void rdTheUk_CheckedChanged(object sender, EventArgs e)
        {
             country = rdTheUk.Text;
            label1.Text = getNotification(country);
        }

        private void rdItaly_CheckedChanged(object sender, EventArgs e)
        {
             country = rdItaly.Text;
            label1.Text = getNotification(country);
        }

        private void rdArrgentina_CheckedChanged(object sender, EventArgs e)
        {
             country = rdArrgentina.Text;
            label1.Text = getNotification(country);
        }

        private void rdBra_CheckedChanged(object sender, EventArgs e)
        {
             country = rdBra.Text;
            label1.Text = getNotification(country);
        }

        private void rdUsa_CheckedChanged(object sender, EventArgs e)
        {
             country = rdUsa.Text;
            label1.Text = getNotification(country);
        }

        private void rdBrazil_CheckedChanged(object sender, EventArgs e)
        {
            capital = rdBrazil.Text;
            if (check(country, capital))
            {
                label1.Text = "Chúc mừng bạn, thủ đô của " + country + " là " + capital;
            }
            else
            {
                label1.Text = "Bạn sai rồi, thủ đô của " + country + " không phải là " + capital;

            }
        }

        private void rdTokyo_CheckedChanged(object sender, EventArgs e)
        {
            capital = rdTokyo.Text;
            if (check(country, capital))
            {
                label1.Text = ("Chúc mừng bạn, thủ đô của " + country + " là " + capital);
            }
            else
            {
                label1.Text = ("Bạn sai rồi, thủ đô của " + country + " không phải là " + capital);

            }
        }

        private void rdRome_CheckedChanged(object sender, EventArgs e)
        {
            capital = rdRome.Text;
            if (check(country, capital))
            {
                label1.Text = ("Chúc mừng bạn, thủ đô của " + country + " là " + capital);
            }
            else
            {
                label1.Text = ("Bạn sai rồi, thủ đô của " + country + " không phải là " + capital);

            }
        }

        private void rdWashington_CheckedChanged(object sender, EventArgs e)
        {
            capital = rdWashington.Text;
            if (check(country, capital))
            {
                label1.Text = ("Chúc mừng bạn, thủ đô của " + country + " là " + capital);
            }
            else
            {
                label1.Text = ("Bạn sai rồi, thủ đô của " + country + " không phải là " + capital);

            }
        }

        private void rdMar_CheckedChanged(object sender, EventArgs e)
        {
            capital = rdMar.Text;
            if (check(country, capital))
            {
                label1.Text = ("Chúc mừng bạn, thủ đô của " + country + " là " + capital);
            }
            else
            {
                label1.Text = ("Bạn sai rồi, thủ đô của " + country + " không phải là " + capital);

            }
        }

        private void rdoLondon_CheckedChanged(object sender, EventArgs e)
        {
            capital = rdoLondon.Text;
            if (check(country, capital))
            {
                label1.Text = ("Chúc mừng bạn, thủ đô của " + country + " là " + capital);
            }
            else
            {
                label1.Text = ("Bạn sai rồi, thủ đô của " + country + " không phải là " + capital);

            }
        }

        private void rdAnkara_CheckedChanged(object sender, EventArgs e)
        {
            capital = rdAnkara.Text;
            if (check(country, capital))
            {
                label1.Text = ("Chúc mừng bạn, thủ đô của " + country + " là " + capital);
            }
            else
            {
                label1.Text = ("Bạn sai rồi, thủ đô của " + country + " không phải là " + capital);

            }
        }

        private void rdoBudapest_CheckedChanged(object sender, EventArgs e)
        {
            capital = rdoBudapest.Text;
            if (check(country, capital))
            {
                label1.Text = ("Chúc mừng bạn, thủ đô của " + country + " là " + capital);
            }
            else
            {
                label1.Text = ("Bạn sai rồi, thủ đô của " + country + " không phải là " + capital);

            }
        }

        private void rdParis_CheckedChanged(object sender, EventArgs e)
        {
            capital = rdParis.Text;
            if (check(country, capital))
            {
                label1.Text = ("Chúc mừng bạn, thủ đô của " + country + " là " + capital);
            }
            else
            {
                label1.Text = ("Bạn sai rồi, thủ đô của " + country + " không phải là " + capital);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdBuenos_CheckedChanged(object sender, EventArgs e)
        {
            capital = rdBuenos.Text;
            if (check(country, capital))
            {
                label1.Text = ("Chúc mừng bạn, thủ đô của " + country + " là " + capital);
            }
            else
            {
                label1.Text = ("Bạn sai rồi, thủ đô của " + country + " không phải là " + capital);

            }
        }

        private void rdFance_CheckedChanged_1(object sender, EventArgs e)
        {
            country = rdFance.Text;
            label1.Text = getNotification(country);
        }
    }
}
