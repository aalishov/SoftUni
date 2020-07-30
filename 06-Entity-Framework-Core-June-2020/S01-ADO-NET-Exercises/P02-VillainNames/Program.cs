using Microsoft.Data.SqlClient;
using System;

namespace P02_VillainNames
{
    class Program
    {
        private const string connectonString = @"Server=(localdb)\MSSQLLocalDB; Database=MinionsAdoDb; Integrated Security=true";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectonString);

            string query = @"
SELECT v.Name,COUNT(mv.VillainId) as NumberOfMinions FROM Villains as v
JOIN MinionsVillains as mv ON mv.VillainId=v.Id
GROUP BY v.Name
HAVING COUNT(mv.VillainId)>3
ORDER BY NumberOfMinions DESC
";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = (string)reader[0];
                    int minionsCount = (int)reader[1];

                    Console.WriteLine($"{name} - {minionsCount}");
                }
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
