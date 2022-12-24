using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.model
{
    class ChatLieu
    {
            private string  SL;
            private string MaCL ;
            private string  TenCL;

        public ChatLieu()
        {
        }

        public ChatLieu(string maCL, string tenCL, string sL)
        {
            MaCL1 = maCL;
            TenCL1 = tenCL;
            SL1 = sL;
        }

        public string SL1 { get => SL; set => SL = value; }
        public string MaCL1 { get => MaCL; set => MaCL = value; }
        public string TenCL1 { get => TenCL; set => TenCL = value; }
    }
}
