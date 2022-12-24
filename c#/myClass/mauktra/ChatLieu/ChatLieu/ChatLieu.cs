using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeThiHK
{
    class ChatLieu
    {
        string MaCL;
        string TenCL;

        public ChatLieu(string maCL, string tenCL)
        {
            MaCL1 = maCL;
            TenCL1 = tenCL;
        }

        public string MaCL1 { get => MaCL; set => MaCL = value; }
        public string TenCL1 { get => TenCL; set => TenCL = value; }
    }
}
