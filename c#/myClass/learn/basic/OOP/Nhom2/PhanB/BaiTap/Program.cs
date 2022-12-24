internal class Program
{

    class PhanSo
    {
        private int tuSo;
        private int mauSo;

        public PhanSo()
        {
        }

        public PhanSo(int tuSo, int mauSo)
        {
            this.TuSo = tuSo;
            this.MauSo = mauSo;
        }

        public int TuSo { get => tuSo; set => tuSo = value; }
        public int MauSo { get => mauSo; set => mauSo = value; }

        public void nhap()
        {
            do
            {
                Console.Write("Nhap tu so: ");
                try
                {
                    tuSo = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Nhap lai!");
                }
            } while (true);

            do
            {
                Console.Write("Nhap mau so: ");
                try
                {
                    mauSo = int.Parse(Console.ReadLine());
                    if(mauSo == 0)
                    {
                        Console.WriteLine("Nhap lai!");
                    } else
                    {
                        break;
                    }
                    
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Nhap lai!");
                }
            } while (true);
        }


        public void xuat()
        {
            Console.WriteLine(tuSo + "/" + mauSo);
        }

        public void xuat(int tu, int mau)
        {
            Console.WriteLine(tu + "/" + mau);
        }

        public void tong(PhanSo x)
        {
            int tu = this.tuSo * x.mauSo + x.TuSo * this.mauSo;
            int mau = this.mauSo * x.mauSo;

            xuat(tu, mau);

        }

        public void hieu(PhanSo x)
        {
            int tu = this.tuSo * x.mauSo - x.TuSo * this.mauSo;
            int mau = this.mauSo * x.mauSo;

            xuat(tu, mau);

        }

        public void tich(PhanSo x)
        {
            int tu = this.tuSo *  x.TuSo;
            int mau = this.mauSo * x.mauSo;

            xuat(tu, mau);

        }

        public void thuong(PhanSo x)
        {
            int tu = this.tuSo * x.mauSo;
            int mau = this.mauSo * x.TuSo;

            xuat(tu, mau);

        }

    }


    private static void Main(string[] args)
    {
        PhanSo ps1 = new PhanSo();
        PhanSo ps2 = new PhanSo();

        Console.WriteLine("Nhap phan so thu nhat:");
        ps1.nhap();
        Console.WriteLine("Nhap phan so thu hai:");
        ps2.nhap();

        Console.WriteLine("Tong 2 phan so: ");
        ps1.tong(ps2);

        Console.WriteLine("Hieu 2 phan so: ");
        ps1.hieu(ps2);

        Console.WriteLine("Tich 2 phan so: ");
        ps1.tich(ps2);

        Console.WriteLine("Thuong 2 phan so: ");
        ps1.thuong(ps2);
    }
}