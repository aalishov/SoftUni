using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_BirthdayCelebrations
{
 public   class Program
    {
      public  static void Main(string[] args)
        {
            List<IBirthable> inhabitants = new List<IBirthable>();
            while (true)
            {

                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = line[0].ToLower();
                if (cmd == "end")
                {
                    break;
                }
                string name = line[0];
                if (line.Length ==5 )
                {                   
                    inhabitants.Add(new Citizen() {  BirthDay = line[4] });
                }
                else if (line.Length == 3 &&name=="Pet")
                {
                    
                    inhabitants.Add(new Pet() { BirthDay=line[2]});
                }
            }
            string year = Console.ReadLine();

            if (inhabitants.Any(x=>x.IsInCurrentYear(year)))
            {
                foreach (var i in inhabitants)
                {
                    if (i.IsInCurrentYear(year))
                    {
                        Console.WriteLine(i.PrintBirthDate());
                    }
                }
            }
            //else
            //{
            //    Console.WriteLine("<empty output>");
            //}
            
        }
    }
}
