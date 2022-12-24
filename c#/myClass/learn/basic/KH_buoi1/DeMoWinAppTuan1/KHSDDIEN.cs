using System;

namespace ChuaBaiKS
{
    class KHSDDIEN
    {
        string maK, tenK, diaChi;
        DateTime ngayChot;
        int sTruoc, sSau;

        public string TenK { get => tenK; set => tenK = value; }

        public KHSDDIEN()
        {
        }
        public KHSDDIEN(string maK, string tenK, string diaChi, DateTime ngayChot, int sTruoc, int sSau)
        {
            this.maK = maK;
            this.tenK = tenK;
            this.diaChi = diaChi;
            this.ngayChot = ngayChot;
            this.sTruoc = sTruoc;
            this.sSau = sSau;
        }
       public void nhap()
        {
            Console.Write("nhap ma khach: ");
            maK=Console.ReadLine();
            Console.Write("nhap ten khach: ");
            tenK = Console.ReadLine();
            Console.Write("nhap dia chi: ");
            diaChi = Console.ReadLine();
            Console.Write("nhap ngay chot: ");
            ngayChot =DateTime .Parse( Console.ReadLine());

            Console.Write("nhap so thang trc: ");
            sTruoc = int.Parse(Console.ReadLine());
            Console.Write("nhap so thang sau: ");
            sSau = Convert.ToInt16(Console.ReadLine());

        }
        public float tinhtien()
        {
            float tt=0;
            int sd = sSau - sTruoc;
            if (sd <= 50) tt = 1000 * sd;
            else if (sd <= 100) tt = 50 * 1000 + (sd - 50) * 1200;
            else if (sd <= 200) tt = 50 * 1000 + 50 * 1200 + (sd - 100) * 1300;
            else tt = 50 * 1000 + 50 * 1200 + 100 * 1300+(sd-200)*5400;
            return tt*1.1F;
        }
        public override string ToString()
        {
            return maK + " " + tenK + " " + diaChi +" "+(sSau-sTruoc).ToString()+" "+tinhtien().ToString();
        }
        public void xuat()
        {
            Console.WriteLine(maK + " " + tenK + " " + diaChi + " " + (sSau - sTruoc).ToString() + " " + tinhtien().ToString());//this.ToString());
        }
       public string getten()
        {
            return tenK;
        }
    }
}
