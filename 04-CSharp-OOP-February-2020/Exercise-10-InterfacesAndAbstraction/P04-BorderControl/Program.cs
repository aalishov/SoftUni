using System;
using System.Collections.Generic;

namespace P04_BorderControl
{
    public class Program
    {
        public static void Main()
        {
            List<Inhabitant> inhabitants = new List<Inhabitant>();
            while (true)
            {
                
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = line[0].ToLower();
                if (cmd == "end")
                {
                    break;
                }
                string name = line[0];
                if (line.Length == 3)
                {
                    int age = int.Parse(line[1]);
                    string id = line[2];
                    inhabitants.Add(new Citizen() { Id = id, Name = name, Age = age });
                }
                else if (line.Length == 2)
                {
                    string id = line[1];
                    inhabitants.Add(new Robot() { Id=id,Model=name});
                }
            }
            string fakeId = Console.ReadLine();

            foreach (var i in inhabitants)
            {
                if (i.IsDetained(fakeId))
                {
                    Console.WriteLine(i.ToString());
                }
            }
        }
    }
}
