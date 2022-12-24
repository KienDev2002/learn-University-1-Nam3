using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3_QLTour
{
    class KhachHang
    {
        private String hoTen;
        private long giaDuThuyen;
        private String doUong;
        private String soLuongDoUong;

        public KhachHang() { }

        public KhachHang(string hoTen, long giaDuThuyen, string doUong, string soLuongDoUong)
        {
            this.hoTen = hoTen;
            this.giaDuThuyen = giaDuThuyen;
            this.doUong = doUong;
            this.soLuongDoUong = soLuongDoUong;
        }

        public string HoTen { get => hoTen; set => hoTen = value; }
        public long GiaDuThuyen { get => giaDuThuyen; set => giaDuThuyen = value; }
        public string DoUong { get => doUong; set => doUong = value; }
        public string SoLuongDoUong { get => soLuongDoUong; set => soLuongDoUong = value; }

        public double tinhTienDoUong = 0;
        public double tongTien()
        {
            return tinhTienDoUong + giaDuThuyen;
        }

    }
}
