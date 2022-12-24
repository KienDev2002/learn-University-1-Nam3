using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTbuoi3
{
    internal class Program
    {    
        static void Main(string[] args)
        {
            int n;
            float[] a;
            Console.Write("Nhap vao so phan tu cua day n = ");
            n = int.Parse(Console.ReadLine());
            a = new float[n + 1];
            Console.WriteLine("Nhap vao cac phan tu cua day: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[" + i + "] = ");
                a[i] = float.Parse(Console.ReadLine());
            }
            float maxArr, totalArr, soPTam;
            totalArr = 0;
            soPTam = 0;
            maxArr = a[0];
            for (int i = 0; i < n; i++)
            {
                if (a[i] > maxArr) maxArr = a[i];
                if (a[i] < 0) soPTam++;
                totalArr += a[i];
            }
            Console.WriteLine("Phan tu lon nhat cua day la: " + maxArr);
            Console.WriteLine("Tong cua day la: " + totalArr);
            Console.WriteLine("So phan tu am cua day: " + soPTam);
            Console.ReadKey();
        }
    }
}
