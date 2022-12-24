using System;

namespace ChuaBaiKS
{
    class Ungdung
    {
        KHSDDIEN[] lst;//List<KHSDDIEN> lst;
        int n;

        public Ungdung()
        {
        }

        /*public Ungdung(List<KHSDDIEN> lst, int n)
        {
            this.lst = lst;
            this.n = n;
        }*/
        public void nhap()
        {
            Console.Write("nhap so khach hang ");
            n = int.Parse(Console.ReadLine());
            lst = new KHSDDIEN[n];
            for(int i=0;i<n;i++)
            {
                //KHSDDIEN x=new KHSDDIEN();
                lst[i] = new KHSDDIEN();
                Console.WriteLine("nhap tt cho kh thu " + (i + 1));
                lst[i].nhap();
                //lst.Add(x);
            }
         }
        public void timTen(string x)
        {
            bool k = false;
            foreach (KHSDDIEN kh in lst)
                if (kh.TenK.Equals(x))
                {
                    kh.TenK = "ngo trung kien";
                    kh.xuat();
                    k = true;
                }
            if (k == false) Console.WriteLine("ko tim thay");
        }
    }
}
