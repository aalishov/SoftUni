using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static Dictionary<string, Team> teams = new Dictionary<string, Team>();
        public static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine().Split(';');

                    string cmd = input[0].ToLower();

                    if (cmd == "add")
                    {
                        AddPlayer(input);
                    }
                    else if (cmd == "remove")
                    {
                        RemovePlayer(input);
                    }
                    else if (cmd == "rating")
                    {
                        string teamName = input[1];
                        if (teams.ContainsKey(teamName))
                        {
                            int rating = teams[teamName].Rating;
                            Console.WriteLine($"{teamName} - {rating}");
                        }
                        else
                        {
                            throw new Exception($"Team {teamName} does not exist.");
                        }
                    }
                    else if (cmd == "team")
                    {
                        AddTeam(input);
                    }
                    else if (cmd == "end")
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

        }

        private static void RemovePlayer(string[] input)
        {
            string teamName = input[1];
            if (teams.ContainsKey(teamName))
            {
                string playerName = input[2];
                teams[teamName].RemovePlayer(playerName);
            }
            else
            {
                throw new Exception($"Team {teamName} does not exist.");
            }
        }

        private static void AddTeam(string[] input)
        {
            string teamName = input[1];
            if (!teams.ContainsKey(teamName))
            {
                Team newTeam = new Team(teamName);
                teams.Add(teamName, newTeam);
            }
        }

        private static void AddPlayer(string[] input)
        {
            string teamName = input[1];
            if (teams.ContainsKey(teamName))
            {
                string playerName = input[2];
                int endurance = int.Parse(input[3]);
                int sprint = int.Parse(input[4]);
                int dribble = int.Parse(input[5]);
                int passing = int.Parse(input[6]);
                int shoting = int.Parse(input[7]);

                Stats stats = new Stats(endurance, sprint, dribble, passing, shoting);
                Player player = new Player(playerName, stats);

                teams[teamName].AddPlayer(player);
            }
            else
            {
                throw new Exception($"Team {teamName} does not exist.");
            }
        }
    }
}
