using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int InitialEnergy = 50;
        private const int DecreaseEnergy = 15;
        public SleepyDwarf(string name) : base(name, InitialEnergy)
        {
        }

        
        public override void Work()
        {
            this.Energy -= DecreaseEnergy; ;
        }
    }
}
