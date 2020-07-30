using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectonString = @"Server=(localdb)\MSSQLLocalDB; Database=MinionsAdoDb; Integrated Security=true";

            string query = @"
SELECT Name,Age FROM Minions
";
            string updateQuery = @"
 UPDATE Minions
   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
 WHERE Id = @Id
";
            List<string> minions = new List<string>(); // { "Bob","Kevin", "Steward", "Jimmy", "Vicky" , "Becky", "Jully" };
            List<int> age = new List<int>();

            string[] minionsId = Console.ReadLine().Split(' ').ToArray();
            SqlConnection connection = new SqlConnection(connectonString);

            try
            {
                connection.Open();
                for (int i = 0; i < minionsId.Length; i++)
                {
                    SqlCommand sqlCommand2 = new SqlCommand(updateQuery, connection);
                    sqlCommand2.Parameters.AddWithValue("Id", minionsId[i]);
                    sqlCommand2.ExecuteNonQuery();
                }
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    minions.Add((string)reader[0]);
                    age.Add((int)reader[1]);
                }
                connection.Close();
                for (int i = 0; i < minions.Count; i++)
                {
                    Console.WriteLine($"{minions[i]} {age[i]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
