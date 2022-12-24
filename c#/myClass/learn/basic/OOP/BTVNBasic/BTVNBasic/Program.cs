// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


class phanso
{
    private double ts, ms;

    public phanso() { }
    public phanso(double ts, double ms) { this.ts = ts; this.ms = ms; }
    public double getTs() { return ts; }
    public double getMs() { return ms; }
    public void set(double ts, double ms) { this.ts = ts; this.ms = ms; }
    
   
    public void input()
    {
        Console.Write("Nhap tu so:");
        this.ts = Convert.ToDouble(Console.ReadLine());

        do
        {
            Console.Write("Nhap mau so:");
            this.ms = Convert.ToDouble(Console.ReadLine());
            if(this.ms == 0)
            {
                Console.Write("Moi ban nhap lai ma so:");
              
            }
        }while(this.ms==0);


    }

    public void show()
    {
        if (this.ms < 0)
        {
            this.ts *= -1;
            this.ms *= -1;
        }
        this.rutgon(this);
        Console.WriteLine("Phan so co dang: " + this.ts + "/" +  this.ms);
    }
    

    public void rutgon(phanso a)
    {
        if(a.ts >= a.ms)
        {
            for(double i = a.ms; i >0 ; i--)
            {
                if(a.ts % i == 0)
                {
                    a.ts/= i;
                    a.ms/= i;
                }
            }
        }
        else
        {
            for (double i = 0; i < a.ts; i++)
            {
                if (a.ms % i == 0)
                {
                    a.ts /= i;
                    a.ms /= i;
                }
            }
        }
    }

    public phanso tong(phanso a)
    {
        phanso temp = new phanso();
        temp.ts = this.ts * a.ms + this.ms * a.ts;
        temp.ms = this.ms * a.ms;

        return temp;
    }

    public phanso hieu(phanso a)
    {
        phanso temp = new phanso();
        temp.ts = this.ts * a.ms - this.ms * a.ts;
        temp.ms = this.ms * a.ms;
        return temp;
    }

    public phanso tich (phanso a)
    {
        phanso temp = new phanso();
        temp.ts = this.ts  * a.ts;
        temp.ms = this.ms * a.ms;
        return temp;
    }

    public phanso thuong(phanso a)
    {
        phanso temp = new phanso();
        temp.ts = this.ts * a.ms;
        temp.ms = this.ms * a.ts;
        return temp;
    }


    public static void Main(string [] args)
    {
        phanso a = new phanso();
        phanso b = new phanso();
        a.input();
        b.input();

        a.show();
        b.show();

        phanso sum = new phanso();
        sum = a.tong(b);
        Console.Write("Tong 2 phan so la: ");
        sum.show();

        phanso hieu = new phanso();
        Console.Write("Hieu 2 phan so la: ");
        hieu = a.hieu(b);
        hieu.show();


        phanso tich = new phanso();
        tich = a.tich(b);
        Console.Write("Tich 2 phan so la: ");
        tich.show();



        phanso thuong = new phanso();
        thuong = a.thuong(b);
        Console.Write("Thuong 2 phan so la: ");
        thuong.show();


    }
}