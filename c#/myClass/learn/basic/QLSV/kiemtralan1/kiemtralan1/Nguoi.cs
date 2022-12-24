class Nguoi
{
    private string maCanCuoc, hoten;
    private int tuoi;

    public Nguoi()
    {
    }

    public Nguoi(string maCanCuoc, string hoten, int tuoi)
    {
        this.maCanCuoc = maCanCuoc;
        this.hoten = hoten;
        this.tuoi = tuoi;
    }


    public string getMaCanCuoc()
    {
        return this.maCanCuoc;
    }

    public string getHoTen()
    {
        return this.hoten;
    }

    public int getTuoi()
    {
        return this.tuoi;
    }

    public void setMaCanCuoc(string maCanCuoc)
    {
        this.maCanCuoc = maCanCuoc;
    }

    public void setHoTen(string hoten)
    {
        this.hoten = hoten;
    }

    public void setTuoi(int tuoi)
    {
        this.tuoi = tuoi;
    }


    public void nhap()
    {
        Console.Write("Nhap ma can cuoc:");
        this.maCanCuoc = Console.ReadLine();


        Console.Write("Nhap ho ten:");
        this.hoten = Console.ReadLine();

        do
        {
            try
            {
                Console.Write("Nhap tuoi:");
                this.tuoi = int.Parse(Console.ReadLine());
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
        Console.Write(this.maCanCuoc + " " + this.hoten + " " + this.tuoi);
    }
}
