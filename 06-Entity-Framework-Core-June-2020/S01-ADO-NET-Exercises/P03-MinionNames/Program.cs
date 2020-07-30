using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Serialization;
using System;
using System.Numerics;

namespace P03_MinionNames
{
    class Program
    {
        static void Main()
        {
            const string connectonString = @"Server=(localdb)\MSSQLLocalDB; Database=MinionsAdoDb; Integrated Security=true";

            using SqlConnection sqlConnection = new SqlConnection(connectonString);

            string query = @"
SELECT Name FROM Villains WHERE Id = @Id";
            string query1 = @"
SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name
";
             SqlCommand command0 = new SqlCommand(query, sqlConnection);
             SqlCommand command = new SqlCommand(query1, sqlConnection);

            int id = int.Parse(Console.ReadLine());
            command0.Parameters.AddWithValue("Id", id);
            command.Parameters.AddWithValue("Id", id);

            try
            {
                sqlConnection.Open();
                string villainName = (string)command0.ExecuteScalar()?.ToString();
                if (villainName!=null)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine($"Villain: {villainName}");
                    if (reader!=null)
                    {
                        while (reader.Read())
                        {
                            Int64 rowNum = (Int64)reader[0];
                            string minionsName = (string)reader[1];
                            int minionsAge = (int)reader[2];

                            Console.WriteLine($"{rowNum}. {minionsName} {minionsAge}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("(no minions)");
                    }
 
                }
                else
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
