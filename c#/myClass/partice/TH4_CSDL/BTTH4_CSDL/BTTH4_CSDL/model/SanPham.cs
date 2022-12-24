using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH4_CSDL.model
{
    class SanPham
    {
          private string MaSP;
          private string TenSP;
          private string NgaySX;
          private string NgayHH;
          private string DonVi;
          private string DonGia;
          private string GhiChu;

        public SanPham()
        {
        }

        public SanPham(string maSP, string tenSP, string ngaySX, string ngayHH, string donVi, string donGia, string ghiChu)
        {
            MaSP1 = maSP;
            TenSP1 = tenSP;
            NgaySX1 = ngaySX;
            NgayHH1 = ngayHH;
            DonVi1 = donVi;
            DonGia1 = donGia;
            GhiChu1 = ghiChu;
        }

        public string MaSP1 { get => MaSP; set => MaSP = value; }
        public string TenSP1 { get => TenSP; set => TenSP = value; }
        public string NgaySX1 { get => NgaySX; set => NgaySX = value; }
        public string NgayHH1 { get => NgayHH; set => NgayHH = value; }
        public string DonVi1 { get => DonVi; set => DonVi = value; }
        public string DonGia1 { get => DonGia; set => DonGia = value; }
        public string GhiChu1 { get => GhiChu; set => GhiChu = value; }
    }
}
