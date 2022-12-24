using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuaBaiKS
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Ungdung ob=new Ungdung ();
            string tentim="Kien";
            ob.nhap();
            ob.timTen(tentim);
            Console.ReadKey();
            
    
        }
    }
}
