using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai14
{
    class DSSV
    {
        int STT;
        string HoTen, KhoaHoc, Khoa, SachMuon;

        public DSSV()
        {

        }

        public DSSV(int sTT, string hoTen, string khoaHoc, string khoa, string sachMuon)
        {
            STT1 = sTT;
            HoTen1 = hoTen;
            KhoaHoc1 = khoaHoc;
            Khoa1 = khoa;
            SachMuon1 = sachMuon;
        }

        public int STT1 { get => STT; set => STT = value; }
        public string HoTen1 { get => HoTen; set => HoTen = value; }
        public string KhoaHoc1 { get => KhoaHoc; set => KhoaHoc = value; }
        public string Khoa1 { get => Khoa; set => Khoa = value; }
        public string SachMuon1 { get => SachMuon; set => SachMuon = value; }
    }


}
