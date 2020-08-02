namespace ProductShop.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.ProductsSold = new List<Product>();
            this.ProductsBought = new List<Product>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        [JsonIgnore]
        public ICollection<Product> ProductsSold { get; set; }

        [JsonIgnore]
        public ICollection<Product> ProductsBought { get; set; }
    }
}