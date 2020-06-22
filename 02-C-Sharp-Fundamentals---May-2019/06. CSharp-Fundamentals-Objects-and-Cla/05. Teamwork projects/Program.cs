using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_projects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int n = int.Parse(Console.ReadLine());
            while (teams.Count<n)
            {
                string[] teamInfo = Console.ReadLine().Split('-');
                Team newTeam = new Team(teamInfo[1], teamInfo[0]);
                bool isCreatorExist = false;
                if (!teams.Contains(teams.Where(x=>x.Name==newTeam.Name).FirstOrDefault()))
                {
                    if (!teams.Contains(teams.Where(x => x.Creator == newTeam.Creator).FirstOrDefault()))
                    {
                        teams.Add(newTeam);                        
                    }
                    else
                    {
                        isCreatorExist = true;
                        Console.WriteLine($"{teamInfo[0]} cannot create another team!");
                    }                    
                }
                else if(!isCreatorExist)
                {
                    Console.WriteLine($"Team {teamInfo[1]} was already created!");
                }
            }
        }
    }
    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Member { get; set; }

        public Team(string name, string creator)
        {
            this.Name = name;
            this.Creator = creator;
            this.Member = new List<string>();
        }
    }
}
