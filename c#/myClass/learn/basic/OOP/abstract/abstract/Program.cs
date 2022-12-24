
using System;

namespace @abstract
{

    abstract public class shape
    {
        abstract public void Nhap();
        abstract public double DienTich();

    }

    public class triangle : shape
    {
        private double a, b, c;
        public override void Nhap()
        {
            Console.Write("Nhap canh thu nhat: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhap canh thu hai: ");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap canh thu ba: ");
            c = Convert.ToDouble(Console.ReadLine());

        }
        public override double DienTich()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            triangle tr = new triangle();
            tr.Nhap();
            Console.WriteLine("Dien tich la: ", tr.DienTich());
        }
    }
}
