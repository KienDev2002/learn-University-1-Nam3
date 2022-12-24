
using System.Text.RegularExpressions;

class program
{
    public static void Main(string[] args)
    {
        String checkName = @"^\d+$";
        Console.Write(!Regex.IsMatch("456456456",checkName));
       

        app a = new app();
        a.input();
        a.show();
        Console.Write("Nhap id can tim:");
        String id = Console.ReadLine();
        a.search(id);

        Console.Write("Nhap id can xoa:");
        String id2 = Console.ReadLine();
        a.remove(id2);
    }
}