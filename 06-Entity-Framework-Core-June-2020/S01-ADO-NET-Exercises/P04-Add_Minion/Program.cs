namespace P04_Add_Minion
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Runtime.InteropServices;

    public class Program
    {
        public static void Main()
        {
            const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB; Database=MinionsAdoDb; Integrated Security=true";

            string[] firstInputLine = Console.ReadLine().Split(' ');
            string[] secondInputLine = Console.ReadLine().Split(' ');

            string minionName = firstInputLine[1];
            int age = int.Parse(firstInputLine[2]);
            string town = firstInputLine[3];
            string villainName = secondInputLine[1];

            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            string queryVillainId = "SELECT Id FROM Villains WHERE Name = @Name";

            string queryMinionId = "SELECT Id FROM Minions WHERE Name = @Name";

            string queryTownId = "SELECT Id FROM Towns WHERE Name = @townName";

            SqlCommand getVillainId = new SqlCommand(queryVillainId, sqlConnection);

            SqlCommand getMinionId = new SqlCommand(queryMinionId, sqlConnection);

            SqlCommand getTownId = new SqlCommand(queryTownId, sqlConnection);

            try
            {
                sqlConnection.Open();
                
                getVillainId.Parameters.AddWithValue("@Name", villainName);
                getMinionId.Parameters.AddWithValue("@Name", minionName);
                getTownId.Parameters.AddWithValue("@townName", queryTownId);

                int? villainId = (int?)getVillainId.ExecuteScalar();
                int? minionId = (int?)getMinionId.ExecuteScalar();
                int? townId = (int?)getTownId.ExecuteScalar();

                if (townId == null)
                {
                    string query = "INSERT INTO Towns (Name) VALUES (@townName)";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@townName", town);
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Town {town} was added to the database.");
                }
                if (villainId == null)
                {
                    string query = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@villainName", villainName);
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }
                if (minionId == null)
                {
                    string query = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@name", minionName);
                    sqlCommand.Parameters.AddWithValue("@age", age);
                    sqlCommand.Parameters.AddWithValue("@townId", townId);
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Successfully added {minionName} to minions");
                }

                villainId = (int?)getVillainId.ExecuteScalar();
                minionId = (int?)getMinionId.ExecuteScalar();

                if (villainId != null && minionId != null)
                {
                    string query = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                    sqlCommand.Parameters.AddWithValue("@minionId", minionId);
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
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
