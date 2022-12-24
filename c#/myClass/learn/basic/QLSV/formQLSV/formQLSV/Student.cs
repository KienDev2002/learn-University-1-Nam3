using System;
using System.Text.RegularExpressions;

namespace formQLSV
{
    class Student : Person
    {
        public string university;
        public string id;

        public Student() : base()
        {
        }

        public string getId()
        {
            return this.id;
        }

        public string getUniversity()
        {
            return this.university;
        }

        public Student(string university, string id)
        {
            this.university = university;
            this.id = id;
        }



        public Student(string id,string university,string name, int age, string addresss, string sex) : base(name, age, addresss, sex)
        {
            this.id = id;
            this.university = university;
        }



        public override void input()
        {


            do
            {
                try
                {
                    Console.Write("Nhap id:");
                    this.id = Convert.ToString(Console.ReadLine());

                    if (string.IsNullOrEmpty(this.id))
                    {
                        throw new Exception("Moi ban nhap id khong de trong");
                    }


                    break;


                }



                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



            } while (true);


            do
            {
                try
                {
                    Console.Write("Nhap university:");
                    this.university = Convert.ToString(Console.ReadLine());

                    if (string.IsNullOrEmpty(this.university))
                    {
                        throw new Exception("Moi ban nhap university khong de trong");
                    }

                    if (Regex.IsMatch(this.university, @"^[0-9]+$"))
                    {
                        throw new Exception("Moi ban nhap university khong phai la so");
                    }

                    break;


                }



                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



            } while (true);

            base.input();
        }

        public override void show()
        {
            Console.Write(this.id + " " + this.university + " ");
            Console.WriteLine(base.ToString());

        }


    }
}
