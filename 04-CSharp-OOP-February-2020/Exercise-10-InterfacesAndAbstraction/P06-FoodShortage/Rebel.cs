using System;
using System.Collections.Generic;
using System.Text;

namespace P06_FoodShortage
{
    public class Rebel:IBuyer
    {
        public string Name { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
