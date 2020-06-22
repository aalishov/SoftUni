using System;
using System.Linq;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string pass = new string(user.ToCharArray().Reverse().ToArray());
            bool isCorrect = false;

            for (int i = 0; i < 4; i++)
            {
                string enterUserName = Console.ReadLine();
                if (enterUserName == pass)
                {
                    isCorrect = true;
                    break;
                }
                else
                {
                    if (i!=3)
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                    
                }
            }
            if (isCorrect)
            {
                Console.WriteLine($"User {user} logged in.");
            }
            else
            {
                Console.WriteLine($"User {user} blocked!");
            }
        }
    }
}
