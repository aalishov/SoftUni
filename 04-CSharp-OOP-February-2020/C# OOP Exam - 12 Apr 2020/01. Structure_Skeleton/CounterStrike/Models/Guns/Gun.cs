namespace CounterStrike.Models.Guns
{
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Utilities.Messages;
    using System;

    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        protected Gun(string name, int bulletsCount)
        {
            Name = name;
            BulletsCount = bulletsCount;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }
                name = value;
            }
        }
        public int BulletsCount
        {
            get { return bulletsCount; }
            protected set
            {
                if (value<0)
                {
                    //TODO: Възможен проблем в задачата
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }
                bulletsCount = value;
            }
        }

        public abstract int Fire();
    }
}
