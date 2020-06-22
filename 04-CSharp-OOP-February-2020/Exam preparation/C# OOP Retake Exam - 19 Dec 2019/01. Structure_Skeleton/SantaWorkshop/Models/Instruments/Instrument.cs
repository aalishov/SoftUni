using SantaWorkshop.Models.Instruments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private const int DecreasePower = 10;
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }
        public int Power
        {
            get { return this.power; }
            private set
            {
                if (value < 0)
                {
                    this.power = 0;
                }
                else
                {
                    this.power = value;
                }
            }
        }

        public bool IsBroken()
        {
            if (this.Power == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Use()
        {
            this.Power -= DecreasePower;
        }
    }
}
