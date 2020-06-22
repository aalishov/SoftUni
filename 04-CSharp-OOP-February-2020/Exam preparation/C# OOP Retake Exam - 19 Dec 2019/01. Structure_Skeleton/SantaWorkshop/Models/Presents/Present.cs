using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
        private const int DecreaseEnergy = 100;

        private string name;
        private int energy;

        public Present(string name, int energy)
        {
            this.Name = name;
            this.EnergyRequired = energy;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int EnergyRequired
        {
            get { return this.energy; }
            private set
            {
                if (value < 0)
                {
                    this.energy = 0;
                }
                else
                {
                    this.energy = value;
                }
            }
        }

        public void GetCrafted()
        {
            this.EnergyRequired -= DecreaseEnergy;
        }

        public bool IsDone()
        {
            if (this.EnergyRequired == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
