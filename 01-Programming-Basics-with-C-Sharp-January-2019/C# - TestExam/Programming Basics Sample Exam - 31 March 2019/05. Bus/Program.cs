using System;

namespace _05._Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int passangers = int.Parse(Console.ReadLine());
            int station = int.Parse(Console.ReadLine());
            for (int i = 1; i <= station; i++)
            {

                int newPassangerAdd = int.Parse(Console.ReadLine());
                int newPassangerRemove = int.Parse(Console.ReadLine());
                if (i%2==1)
                {
                    passangers += 2;
                    
                }
                else
                {
                    passangers -= 2;
                  
                }
                passangers -= newPassangerAdd;
                passangers += newPassangerRemove;
                
            }
            Console.WriteLine($"The final number of passengers is : {passangers}");
        
        }
    }
}
