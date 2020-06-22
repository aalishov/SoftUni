using System;
using System.Collections.Generic;
using System.Text;

namespace P02_VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private double modifier;
        public Bus(double quantity, double consumption, double capacity) : base(quantity, consumption, capacity)
        {
        }

        protected override double FuelConsumtionModifier
        {
            get { return this.modifier; }
            set { this.modifier = value; }
        }


        public void EmtyBus(bool isEmpty)
        {
            if (isEmpty)
            {
                this.FuelConsumtionModifier = 0;
            }
            else
            {
                this.FuelConsumtionModifier = 1.4;
            }
        }
    }



}
