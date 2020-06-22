using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance
        {


            get => this.endurance;
            private set
            {
                DataValidator.Stats(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                DataValidator.Stats(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                DataValidator.Stats(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                DataValidator.Stats(value, nameof(this.Passing));
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                DataValidator.Stats(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public double AverageStats()
        {
            return (this.Endurance
                + this.Sprint
                + this.Dribble
                + this.Passing
                + this.Shooting) / 5.0;
        }

    }
}
