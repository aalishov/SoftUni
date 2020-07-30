namespace P05_ChangeTownNamesCasing
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB; Database=MinionsAdoDb; Integrated Security=true";

            string countryName = Console.ReadLine();

            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            string query = @"
UPDATE Towns
   SET Name = UPPER(Name)
 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)
";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@countryName", countryName);
                int affectedRows=(int)sqlCommand.ExecuteNonQuery();

                if (affectedRows==0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    Console.WriteLine($"{affectedRows} town names were affected.");
                    string townsQuery = @"
 SELECT t.Name 
   FROM Towns as t
   JOIN Countries AS c ON c.Id = t.CountryCode
  WHERE c.Name = @countryName
";
                    SqlCommand sqlCommand1 = new SqlCommand(townsQuery, sqlConnection);
                    sqlCommand1.Parameters.AddWithValue("@countryName", countryName);
                    SqlDataReader reader =sqlCommand1.ExecuteReader();
                    List<string> towns = new List<string>();
                    while (reader.Read())
                    {
                        towns.Add((string)reader[0]);
                    }
                    sqlConnection.Close();
                    Console.WriteLine($"[{string.Join(", ",towns)}]");
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
