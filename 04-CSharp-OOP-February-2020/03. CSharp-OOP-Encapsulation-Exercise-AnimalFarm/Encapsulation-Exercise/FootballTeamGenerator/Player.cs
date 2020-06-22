using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {

        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                DataValidator.Name(value);
                name = value;
            }
        }

        public Stats Stats
        {
            get => this.stats;
            private set { stats = value; }
        }

        public double AverageStats()
        {
            return this.Stats.AverageStats();
        }


    }
}
