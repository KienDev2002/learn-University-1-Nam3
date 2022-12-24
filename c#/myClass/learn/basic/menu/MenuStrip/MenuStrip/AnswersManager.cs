using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuStrip
{
    internal class AnswersManager
    {
        private string cauhoi;
        private string debai;
        private List<string> dapan;

        public string Cauhoi { get => cauhoi; set => cauhoi = value; }
        public string Debai { get => debai; set => debai = value; }
        public List<string> Dapan { get => dapan; set => dapan = value; }

        public AnswersManager(string cauhoi, string debai, List<string> dapan)
        {
            this.cauhoi = cauhoi;
            this.debai = debai;
            this.dapan = dapan;
        }
    }
}
