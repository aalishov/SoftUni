using Microsoft.Data.SqlClient;
using System;

namespace P06_RemoveVillain
{
    public class Program
    {
        static void Main()
        {
            const string connectonString = @"Server=(localdb)\MSSQLLocalDB; Database=MinionsAdoDb; Integrated Security=true";

            string queryVillainName = @"
SELECT Name FROM Villains WHERE Id = @villainId
";
            string queryDeleteVillainMinions = @"
DELETE FROM MinionsVillains 
      WHERE VillainId = @villainId
";
            string queryDeleteVillain = @"
DELETE FROM Villains
      WHERE Id = @villainId
";
            int id = int.Parse(Console.ReadLine());

            using SqlConnection sqlConnection = new SqlConnection(connectonString);
            try
            {
                sqlConnection.Open();
                SqlCommand getVillainName = new SqlCommand(queryVillainName, sqlConnection);

                getVillainName.Parameters.AddWithValue("@villainId",id);
                string villainName = (string)getVillainName.ExecuteScalar();
                if (villainName!=null)
                {
                    SqlCommand deleteVillainMinions = new SqlCommand(queryDeleteVillainMinions, sqlConnection);
                    deleteVillainMinions.Parameters.AddWithValue("@villainId", id);
                    int relesedMinions = deleteVillainMinions.ExecuteNonQuery();

                    SqlCommand deleteVillain = new SqlCommand(queryDeleteVillain, sqlConnection);
                    deleteVillain.Parameters.AddWithValue("@villainId", id);
                    int deletedVilliandCount = deleteVillain.ExecuteNonQuery();

                    if (deletedVilliandCount > 0)
                    {
                        Console.WriteLine($"{villainName} was deleted.");
                        Console.WriteLine($"{relesedMinions} minions were released.");
                    }
                }
                else
                {
                    Console.WriteLine("No such villain was found.");
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
