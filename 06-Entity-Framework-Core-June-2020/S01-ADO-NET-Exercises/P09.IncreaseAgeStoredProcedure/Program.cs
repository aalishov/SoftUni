using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace P09.IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectonString = @"Server=(localdb)\MSSQLLocalDB; Database=MinionsAdoDb; Integrated Security=true";

            string query = @"
SELECT Name,Age FROM Minions Where Id=@IdParam
";
            string updateQuery = @"
 EXEC usp_GetOlder @Id=@IdParam
";
            List<string> minions = new List<string>(); // { "Bob","Kevin", "Steward", "Jimmy", "Vicky" , "Becky", "Jully" };
            List<int> age = new List<int>();

            string minionsId = Console.ReadLine();
            SqlConnection connection = new SqlConnection(connectonString);

            try
            {
                connection.Open();
               
                    SqlCommand sqlCommand2 = new SqlCommand(updateQuery, connection);
                    sqlCommand2.Parameters.AddWithValue("@IdParam", minionsId);
                    sqlCommand2.ExecuteNonQuery();
                
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@IdParam", minionsId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Console.WriteLine($"{sqlDataReader[0]} – {sqlDataReader[1]} years old");
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
