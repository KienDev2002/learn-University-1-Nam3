using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiemtralan1
{


    class Cauthu : Nguoi
    {
        private int sbt, sptd;

        public Cauthu()
        {
        }

        public Cauthu(string maCanCuoc, string hoten, int tuoi, int sbt, int sptd) : base(maCanCuoc, hoten, tuoi)
        {
            this.sbt = sbt;
            this.sptd = sptd;
        }

        public int getSbt()
        {
            return this.sbt;
        }

        public int getSptd()
        {
            return this.sptd;
        }

        public void setSbt(int sbt)
        {
            this.sbt = sbt;
        }

        public void setSptd(int sptd)
        {
            this.sptd = sptd;
        }


        public void nhap()
        {
            base.nhap();

            do
            {
                try
                {
                    Console.Write("Nhap so ban thang:");
                    this.sbt = int.Parse(Console.ReadLine());
                    break;

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Moi ban nhap lai la so");
                }

               
            } while (true);


            do
            {
                try
                {
                    Console.Write("Nhap so phut thi dau:");
                    this.sptd = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Moi ban nhap lai la so");
                }
                
            } while (true);

          

           
        }

        public void xuat()
        {
            base.xuat();
            Console.WriteLine(" " + this.sbt + " " + this.sptd);
        }

      
    }
}
