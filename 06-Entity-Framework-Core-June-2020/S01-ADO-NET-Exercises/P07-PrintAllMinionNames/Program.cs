using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectonString = @"Server=(localdb)\MSSQLLocalDB; Database=MinionsAdoDb; Integrated Security=true";

            string query = @"
SELECT Name FROM Minions
";
            List<string> minions = new List<string>(); // { "Bob","Kevin", "Steward", "Jimmy", "Vicky" , "Becky", "Jully" };

            SqlConnection connection = new SqlConnection(connectonString);

            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    minions.Add((string)reader[0]);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            if (minions.Any())
            {
                int count = minions.Count();
                int firstPart = count / 2;
                if (count%2==0)
                {
                    for (int i = 0; i < firstPart; i++)
                    {
                        Console.WriteLine(minions[i]);
                        Console.WriteLine(minions[minions.Count-1-i]);
                    }
                }
                else
                {
                    for (int i = 0; i < firstPart; i++)
                    {
                        Console.WriteLine(minions[i]);
                        Console.WriteLine(minions[minions.Count - 1 - i]);
                        if (i == firstPart - 1)
                        {
                            Console.WriteLine(minions[firstPart]);
                        }
                    }
                }
            }
        }
    }
}
