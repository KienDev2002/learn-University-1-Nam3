using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MenuStrip
{
    internal class FileManager
    {
        public string ReadQuestions(string fileName)
        {
            string s = "";
            try
            {
                StreamReader streamReader = new StreamReader(fileName);
                s = streamReader.ReadToEnd();
            } catch
            {
                MessageBox.Show("Error");
            }
            

            return s;
        }

        public List<string> ReadAnswers(String fileName)
        {
            List<string> list = new List<string>();
            StreamReader streamReader = new StreamReader(fileName);
            string s = "";
            while( (s = streamReader.ReadLine()) != null)
            {
                list.Add(s);
            }
            streamReader.Close();
            return list;
        }
    }
}
