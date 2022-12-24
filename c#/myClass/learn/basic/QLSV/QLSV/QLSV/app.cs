class app : Student
{
    List<Student> students;
    int n;

    public app()
    {
    }

    public app(List<Student> students, int n)
    {
        this.students = students;
        this.n = n;
    }

    public void input()
    {
        try
        {
            Console.Write("Moi ban nhap so luong sinh vien:");
            n = int.Parse(Console.ReadLine());
        }
        catch(FormatException e)
        {
            Console.WriteLine("Moi ban nhap lai la so");
        }
        students = new List<Student>(); ;
        for(int i = 0; i < n; i++)
        {
            Student student = new Student();
            Console.WriteLine("Moi ban nhap sinh vien thu " + (i + 1) + ":");
            student.input();
            students.Add(student);
        }
    }


    public void show()
    {
        Console.WriteLine("Danh sach sinh vien la:");
        foreach(Student student in students)
        {
            student.show();
        }
    }

    public  void search(string id)
    {

        bool check = false;
        
        foreach (Student student in students)
        {
            if(student.id.Equals(id))
            {
                check = true;
                student.show();
                break;
            }
        }
            if (check==false)
            {
                Console.WriteLine("Khong tim thay sinh vien nao co id la "+id);
        }
        else
        {
            Console.WriteLine("Sinh vien co id la " + id + " da tim thay");
        }
    }


    public void remove(string id)
    {

        bool check = false;

        foreach (Student student in students)
        {
            if (student.id.Equals(id))
            {
                students.Remove(student);
                check = true;
                break;
            }
        }
        if (check == false)
        {
            Console.WriteLine("Khong tim thay sinh vien nao co id la " + id + " nen khong the xoa");
        }
        else
        {
            Console.WriteLine("Sinh vien co id la " + id + " da bi xoa");
        }
    }
}
