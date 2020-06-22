namespace Minions
{
    using System;
    using Microsoft.Data.SqlClient;
    public static class CreateDatabase
    {
        private const string connectonString = @"Server=(localdb)\MSSQLLocalDB; Database=MinionsAdoDb; Integrated Security=true";
        public static string CreateDb()
        {
            string connectionStringInitial = @"Server=(localdb)\MSSQLLocalDB; Database=master; Integrated Security=true";
            using SqlConnection sqlConnection = new SqlConnection(connectionStringInitial);

            string query = "CREATE DATABASE MinionsAdoDb";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();
                command.ExecuteNonQuery();
                return "Database created successfully!";
            }
            catch (Exception ex)
            {
                return ex.Message + "\n->Continue with next query!";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static string CreateTableCountries()
        {

            string tableName = "Countries";

            string query = $@"CREATE Table {tableName}
                                    (
                                       Id INT PRIMARY KEY IDENTITY,
                                       Name NVARCHAR(50) NOT NULL
                                    )";

            return CreateTable(tableName, query);
        }

        public static string CreateTableTowns()
        {

            string tableName = "Towns";

            string query = $@"CREATE Table {tableName}
                                    (
                                       Id INT PRIMARY KEY IDENTITY,
                                       Name NVARCHAR(50) NOT NULL,
                                       CountryCode INT NOT NULL REFERENCES Countries(Id) 
                                    )";

            return CreateTable(tableName, query);
        }

        public static string CreateTableMinions()
        {

            string tableName = "Minions";

            string query = $@"CREATE Table {tableName}
                                    (
                                       Id INT PRIMARY KEY IDENTITY,
                                       Name NVARCHAR(50) NOT NULL,
                                       Age INT NOT NULL CHECK(Age>0 AND Age<115),    
                                       TownId INT NOT NULL REFERENCES Towns(Id) 
                                    )";

            return CreateTable(tableName, query);
        }


        public static string CreateTableEvilnessFactors()
        {

            string tableName = "EvilnessFactors";

            string query = $@"CREATE Table {tableName}
                                    (
                                       Id INT PRIMARY KEY IDENTITY,
                                       Name NVARCHAR(50) NOT NULL
                                    )";

            return CreateTable(tableName, query);
        }

        public static string CreateTableVillains()
        {

            string tableName = "Villains";

            string query = $@"CREATE Table {tableName}
                                    (
                                       Id INT PRIMARY KEY IDENTITY,
                                       Name NVARCHAR(50) NOT NULL,
                                       EvilnessFactorId INT NOT NULL REFERENCES EvilnessFactors(Id) 
                                    )";

            return CreateTable(tableName, query);
        }

        public static string CreateTableMinionsVillains()
        {

            string tableName = "MinionsVillains";

            string query = $@"CREATE Table {tableName}
                                    (
                                       MinionId INT NOT NULL REFERENCES Minions(Id) ,
                                       VillainId INT NOT NULL REFERENCES Villains(Id),
                                       PRIMARY KEY(MinionId,VillainId) 
                                    )";

            return CreateTable(tableName, query);
        }

        private static string CreateTable(string tableName, string query)
        {
            SqlConnection  sqlConnection = new SqlConnection(connectonString);
            SqlCommand command = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();
                command.ExecuteNonQuery();
                return $"Table {tableName} created successfully!";
            }
            catch (Exception ex)
            {
                return ex.Message + "\n->Continue with next query!";
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}


