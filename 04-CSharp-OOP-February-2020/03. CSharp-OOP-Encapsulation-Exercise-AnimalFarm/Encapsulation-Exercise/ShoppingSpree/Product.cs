using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public decimal Cost
        {
            get { return cost; }
            private set
            {
                DataValidator.ValidateMoney(value);
                cost = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                DataValidator.ValidateName(value);
                name = value;
            }
        }
        public override string ToString()
        {
            return $"{this.name}";
        }
    }
}
