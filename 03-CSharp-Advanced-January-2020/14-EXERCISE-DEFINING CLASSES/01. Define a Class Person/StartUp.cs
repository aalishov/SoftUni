using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family myFamily = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                string name = line[0];
                int age = int.Parse(line[1]);
                myFamily.AddMember(new Person(name, age));
            }
            Person oldest = myFamily.GetOldestMember();
            //Console.WriteLine($"{oldest.Name} {oldest.Age}");
            foreach (var person in myFamily.PeopleMoreThen30Ears())
            {
                Console.WriteLine(person);
            }
        }
    }
}
