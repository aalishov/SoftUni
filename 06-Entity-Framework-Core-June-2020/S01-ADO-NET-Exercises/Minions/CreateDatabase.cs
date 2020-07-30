namespace Minions
{
    using System;
    using Microsoft.Data.SqlClient;
    public static class CreateDatabase
    {
        private const string connectonString = @"Server=(localdb)\MSSQLLocalDB; Database=MinionsAdoDb; Integrated Security=true";

        public static string InsertData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectonString);
            string query = @"
INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')

INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)

INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)

INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')

INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)

INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)
";
            SqlCommand command = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();
                command.ExecuteNonQuery();
                return $"Data insert successfully!";
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
                                       CountryCode INT REFERENCES Countries(Id) 
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
                                       Age INT NOT NULL ,    
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


