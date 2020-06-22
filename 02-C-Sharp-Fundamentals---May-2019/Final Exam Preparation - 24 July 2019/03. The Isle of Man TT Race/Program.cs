using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([#$%*&])([A-Za-z]+)\1=(\d+)!!([\w\W]*?)$";

            
            while (true)
            {
                string line = Console.ReadLine();
                var isMatch = Regex.IsMatch(line, pattern);
                if (isMatch)
                {
                    foreach (Match m in Regex.Matches(line, pattern))
                    {
                        Console.WriteLine("Coordinates found! {0} -> {1}", m.Value, m.Index);
                        break;
                    }
                }
                Console.WriteLine("Nothing found!");
            }
        }
       
    }
    class RaceMessage
    {
        public string RacerName { get; set; }
        public string GeoHashCode { get; set; }
    }
}
