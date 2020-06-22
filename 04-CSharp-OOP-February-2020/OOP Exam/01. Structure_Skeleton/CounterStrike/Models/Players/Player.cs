namespace CounterStrike.Models.Players
{
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Utilities.Messages;
    using System;
    using System.Text;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
            this.IsAlive = true;
        }

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                username = value;
            }
        }
        public int Health
        {
            get { return health; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                health = value;
            }
        }
        public int Armor
        {
            get { return armor; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                armor = value;
            }
        }
        public IGun Gun
        {
            get { return gun; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                gun = value;
            }
        }

        //TODO: Check IsAlive
        public bool IsAlive
        {
            get;
            private set;
        }

        //TODO: Check TakaDamage
        public void TakeDamage(int points)
        {
            if (points <= this.Armor)
            {
                this.Armor -= points;
            }
            else if (points < this.Health)
            {
                int removeFromHealth = points - armor;
                this.Armor = 0;
                this.Health -= removeFromHealth;
            }
            else if (this.Health-points <= 0)
            {
                this.IsAlive = false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.username}");
            if (this.IsAlive)
            {
                sb.AppendLine($"--Health: {this.Health}");
            }
            else
            {
                sb.AppendLine($"--Health: 0");
            }
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");
            return sb.ToString().TrimEnd();
        }
    }
}
