using System;
using System.Collections.Generic;

namespace _00.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 3, 5, 7, 8, 13, 15 };
            
            list.RemoveAll(x=>x%2==1);

            Console.WriteLine(string.Join(' ',list));
        }
    }
}
