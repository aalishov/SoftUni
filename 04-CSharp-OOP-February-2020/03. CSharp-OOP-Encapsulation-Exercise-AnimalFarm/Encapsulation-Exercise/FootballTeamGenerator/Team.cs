using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public int NumbersOfPlayers { get => this.players.Count; }
        public int Rating { get => GetRating(); }

        public string Name
        {
            get => this.name;

          private  set
            {
                DataValidator.Name(value);
                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player removePlayer = this.players.FirstOrDefault(x => x.Name == playerName);
            if (removePlayer == null)
            {
                throw new Exception($"Player {playerName} is not in {this.Name} team.");
            }
            players.Remove(removePlayer);
        }
        private int GetRating()
        {
            return players.Any() ? (int)Math.Round(this.players.Average(x => x.AverageStats())) : 0;
        }
    }
}
