using System;
using System.Linq;
using System.Text;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(PrintMatrix(n));
        }
        private static string PrintMatrix(int n)
        {
            StringBuilder s = new StringBuilder();
            string c = n.ToString();
            for (int i = 1; i <= n; i++)
            {
                StringBuilder v = new StringBuilder();
                for (int j = 1; j <= n; j++)
                {
                    v = v.Append(c + " ");
                }
                s.Append(v + "\n");
            }
            return s.ToString();
        }
    }
}
