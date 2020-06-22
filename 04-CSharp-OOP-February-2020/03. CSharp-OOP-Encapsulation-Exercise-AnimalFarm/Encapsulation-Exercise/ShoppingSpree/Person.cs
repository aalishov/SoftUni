using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> products;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        public IReadOnlyList<Product> Products
        {
            get
            {
                return products.AsReadOnly();
            }
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                DataValidator.ValidateMoney(value);
                money = value;
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

        public string BuyProduct(Product product)
        {
            if (product.Cost <= this.Money)
            {
                this.products.Add(product);
                this.Money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }
            else
            {
                return $"{this.Name} can't afford {product.Name}";
            }
        }

        public override string ToString()
        {
            return this.Products.Any() ? $"{this.Name} - {string.Join(", ", this.products)}" : $"{this.Name} - Nothing bought";
        }
    }
}
