using System;
using System.Text.RegularExpressions;

namespace formQLSV
{
    abstract class Person
    {
        private string name;
        private int age;
        private string addresss;
        public string sex;

        public Person()
        {
        }
        public Person(string name, int age, string addresss, string sex)
        {
            this.name = name;
            this.age = age;
            this.addresss = addresss;
            this.sex = sex;
        }

        public string getName() { return name; }
        public int getAge() { return age; }
        public string getAddresss() { return addresss; }
        public string getSex() { return sex; }

        public void setAge(int age) { this.age = age; }
        public void setName(string name) { this.name = name; }
        public void setSex(string sex) { this.sex = sex; }
        public void setAddress(string address) { this.addresss = address; }


        public virtual void input()
        {
            do
            {
                try
                {
                    Console.Write("Nhap name:");
                    this.name = Convert.ToString(Console.ReadLine());

                    if (string.IsNullOrEmpty(this.name))
                    {
                        throw new Exception("Moi ban nhap name khong de trong");
                    }

                    if (Regex.IsMatch(this.name, @"^[0-9]+$"))
                    {
                        throw new Exception("Moi ban nhap name khong phai la so");
                    }

                    break;


                }

                catch (FormatException e)
                {
                    Console.WriteLine("");
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
                    Console.Write("Nhap age:");
                    this.age = int.Parse(Console.ReadLine());

                    if (this.age == 0)
                    {
                        throw new Exception("Moi ban nhap lai age lon hon 0");
                    }


                    break;


                }

                catch (FormatException e)
                {
                    Console.WriteLine("Moi ban nhap lai la so");
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
                    Console.Write("Nhap address:");
                    this.addresss = Convert.ToString(Console.ReadLine());

                    if (string.IsNullOrEmpty(this.name))
                    {
                        throw new Exception("Moi ban nhap name khong de trong");
                    }

                    if (Regex.IsMatch(this.name, @"^[0-9]+$"))
                    {
                        throw new Exception("Moi ban nhap name khong phai la so");
                    }

                    break;


                }

                catch (FormatException e)
                {
                    Console.WriteLine("");
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
                    Console.Write("Nhap sex 1 la Nam, 0 la Nu:");
                    this.sex = Console.ReadLine();



                    break;


                }

                catch (FormatException e)
                {
                    Console.WriteLine("Moi ban nhap lai la so.");
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



            } while (true);

        }


        public abstract void show();

        public override string ToString()
        {
            return this.name + " " + this.age + " " + this.addresss + " " + this.age;
        }

    }
}
