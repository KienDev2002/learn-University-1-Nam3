using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCB_b9
{
    class sach
    {
        private string tensach;
        private int giasach;
        private int soluong;



        public sach(string Tensach, int Giasach, int Soluong)
        {
            tensach = Tensach;
            giasach = Giasach;
            soluong = Soluong;
        }

        public string TS { get => tensach; set => tensach = value; }
        public int GS { get => giasach; set => giasach = value; }
        public int SL { get => soluong; set => soluong = value; }
    }
}
