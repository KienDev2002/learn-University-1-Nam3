using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiemtralan1
{
     class app
    {

        List<Cauthu> ct;
        int n;

        public app()
        {
        }

        public app(List<Cauthu> ct, int n)
        {
            this.ct = ct;
            this.n = n;
        }


        public void nhap()
        {

            do
            {
                try
                {
                    Console.Write("Moi ban nhap so luong cau thu:");
                    n = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Moi ban nhap lai la so");
                }
               
            } while (true);
           
            ct = new List<Cauthu>(); ;
            for (int i = 0; i < n; i++)
            {
                Cauthu cauthu = new Cauthu();
                Console.WriteLine("Moi ban nhap cau thu thu " + (i + 1) + ":");
                cauthu.nhap();
                ct.Add(cauthu);
            }
        }

        public void xuat()
        {
            Console.WriteLine("Danh sach cau thu la:");
            foreach (Cauthu cauthu in ct)
            {
                cauthu.xuat();
            }
        }

        public void searchYounger()
        {
            int age = int.MaxValue;
            for (int i = 0; i < ct.Count; i++)
            {
                if (ct[i].getTuoi() < age)
                {
                   
                    age = ct[i].getTuoi();
                }
            }

            for (int i = 0; i < ct.Count; i++)
            {
                if (ct[i].getTuoi() == age)
                {

                    ct[i].xuat();
                }
            }
        }
           

        public void  tinhtienThuong()
        {
           
            for (int i = 0; i < ct.Count; i++)
            {
                if ((ct[i].getSbt() >= 3 && ct[i].getSbt() < 5)  || (ct[i].getSptd() > 500))
                {
                    ct[i].xuat();
                    Console.WriteLine(5000000);

                }
                else if(ct[i].getSbt() >= 5)
                {
                    ct[i].xuat();
                    Console.WriteLine(7000000);
                }
                else
                {
                    ct[i].xuat();
                    Console.WriteLine(0);
                }


            }

           

        }
    }
}
