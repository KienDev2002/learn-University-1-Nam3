using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace menu_buoi4
{
    class QLFile
    {
        public string readCH(string tentep)
        {
            string s = "";

            StreamReader sr = new StreamReader(tentep);
            s = sr.ReadToEnd();

            sr.Close();
            return s;
        }

        public List<string> readTL(string tentep)
        {
            List<string> ls = new List<string>();
            string s = "";
            StreamReader sr = new StreamReader(tentep);

            while( (s =sr.ReadLine()) != null)
            {
                ls.Add(s);
            }
            sr.Close();
            return ls;
        }
    }
}
