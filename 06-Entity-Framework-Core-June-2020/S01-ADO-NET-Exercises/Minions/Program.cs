using Microsoft.Data.SqlClient;
using System;

namespace Minions
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintCreateDatabaseResult();
        }

        private static void PrintCreateDatabaseResult()
        {
            Console.WriteLine(CreateDatabase.CreateDb());
            Console.WriteLine(CreateDatabase.CreateTableCountries());
            Console.WriteLine(CreateDatabase.CreateTableTowns());
            Console.WriteLine(CreateDatabase.CreateTableMinions());
            Console.WriteLine(CreateDatabase.CreateTableEvilnessFactors());
            Console.WriteLine(CreateDatabase.CreateTableVillains());
            Console.WriteLine(CreateDatabase.CreateTableMinionsVillains());
            Console.WriteLine(CreateDatabase.InsertData());
        }

    }
}
