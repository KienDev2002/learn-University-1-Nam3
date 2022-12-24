




using kiemtralan1;

class program
{
    public static void Main(string[] args)
    {
        app ungdung = new app();
        ungdung.nhap();
        ungdung.xuat();

        Console.WriteLine("Tim cau thu tre nhat la:");
        ungdung.searchYounger();

        Console.WriteLine("Cho biet tien thuong cua cau thu:");
        ungdung.tinhtienThuong();

    }
}