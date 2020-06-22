using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> phones = new List<string>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries));
            List<string> urls = new List<string>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries));

            foreach (var p in phones)
            {
                if (p.Any(x=>char.IsLetter(x)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                if (p.Length==10)
                {

                    Call(new Smartphone(), p);
                }
                else if(p.Length==7)
                {
                    Call(new StationaryPhone(), p);
                }
                
            }

            foreach (var u in urls)
            {
                if (!(u.Any(x=>char.IsDigit(x))))
                {
                    Console.WriteLine(new Smartphone().Brows(u));
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
        public static void Call(ICalling phone,string number)
        {
            Console.WriteLine(phone.Call(number));
            
        }
    }
}
