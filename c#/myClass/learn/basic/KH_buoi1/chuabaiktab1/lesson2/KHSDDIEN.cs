using System;

namespace lesson2
{
    internal static partial class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        partial class KHSDDIEN
        {
            string maK, tenK, address;
            DateTime ngaychot;
            int sTruoc, sSau;

            public string TenK { get => tenK; set => tenK = value; }

            public KHSDDIEN()
            {
            }

            public KHSDDIEN(string maK, string tenK, string address, DateTime ngaychot, int sTruoc, int sSau)
            {
                this.maK = maK;
                this.tenK = tenK;
                this.address = address;
                this.ngaychot = ngaychot;
                this.sTruoc = sTruoc;
                this.sSau = sSau;
            }

            public string getTKH()
            {
                return this.tenK;
            }

            public void input()
            {
                Console.Write("Nhap ma khach:");
                maK = Console.ReadLine();

                Console.Write("Nhap ten khach:");
                tenK = Console.ReadLine();

                Console.Write("Nhap địa chỉ khach:");
                address = Console.ReadLine();

                Console.Write("Nhap ngay chot:");
                ngaychot = DateTime.Parse(Console.ReadLine());

                Console.Write("Nhap so truoc:");
                sTruoc = int.Parse(Console.ReadLine());

                Console.Write("Nhap so sau:");
                sSau = Convert.ToInt16(Console.ReadLine()); //convert sang int.
            }

            public float tinhtien()
            {
                float tt=0;
                int sd = sSau - sTruoc;
                if (sd <= 50) tt = 1000 * sd;
                else if (sd <= 100) tt = 50 * 1000 + (sd - );
                else if (sd <= 200) tt = 50 * 1000 + 50 * 1200 + sd;
                else tt = 50 * 1000 + 50 * 1200 + 100 * 1300 + (sd - 200)*5400;
                return tt * 1.1F;
            }

            /*
            public override string ToString()
            {
                return maK + " " + tenK + " " + address + " " + (sSau - sTruoc).ToString() + " " + tinhtien().ToString(); 
            }
            */

            public void show()
            {
                //           Console.Write(this.ToString());
                Console.Write(maK + " " + tenK + " " + address + " " + (sSau - sTruoc) + " " + tinhtien());
            }
            
        }
    }
}
