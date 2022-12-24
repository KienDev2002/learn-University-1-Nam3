using System;
using System.Collections.Generic;

namespace lesson2
{
    internal static partial class Program
    {
        partial class KHSDDIEN
        {
            class UngDung
            {
                List<KHSDDIEN> lst;
                int n;
                
                //KHSDDIEN[]

                public UngDung(List<KHSDDIEN> lst, int n)
                {
                    this.lst = lst;
                    this.n = n;
                }

                public UngDung()
                {
                }


                public void nhap()
                {
                    Console.Write("Nhap so khach hang:");
                    n = int.Parse(Console.ReadLine());

                    for(int i = 0; i < n; i++)
                    {
                        KHSDDIEN x = new KHSDDIEN();
                        Console.Write("Nhap khach hang thu " + i);
                        lst.Add(x);
                    }
                }

                public void timtien(string x)
                {
                    foreach(KHSDDIEN kh in lst)
                    {
                        if (kh.getTKH().Equals(x)){
                            kh.show();
                        }
                    }
                }

            }
            static void Main()
            {
                UngDung ob = new UngDung();
                string tenTim = "kien";
                ob.nhap();
                ob.timtien(tenTim);
                Console.ReadKey(); //dừng màn hình
            }
        }

    }
}
