using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
       
        public static void Main()
        {
            //var k = new Kitten("Pepi", 12, "Male");
            //Console.WriteLine(k);

            List<Animal> animals = new List<Animal>();
            while (true)
            {
                try
                {
                    string type = Console.ReadLine();
                    if (type == "Beast!")
                    {
                        break;
                    }
                    string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        string name = info[0];
                        int age = int.Parse(info[1]);
                        string male = info[2];


                        if (type == "Dog")
                        {
                            animals.Add(new Dog(name, age, male));
                        }
                        else if (type == "Cat")
                        {
                            animals.Add(new Cat(name, age, male));
                        }
                        else if (type == "Frog")
                        {
                            animals.Add(new Frog(name, age, male));
                        }
                        else if (type == "Kitten")
                        {
                            animals.Add(new Kitten(name, age));
                        }
                        else if (type == "Tomcat")
                        {
                            animals.Add(new Tomcat(name, age));
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.ToString());
                }
            }
        }
}
