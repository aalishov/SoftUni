using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dto;
using ProductShop.Models;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            

            ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            string inputJson = File.ReadAllText(@"C:\Users\АлишАлишов\Desktop\GIT Projects\SoftUni\06-Entity-Framework-Core-June-2020\S18-JSON-Processing-Exercises\08. JSON-Processing-Product-Shop-Skeleton\ProductShop\Datasets\users.json");
            Console.WriteLine(ImportUsers(context, inputJson));

            inputJson = File.ReadAllText(@"C:\Users\АлишАлишов\Desktop\GIT Projects\SoftUni\06-Entity-Framework-Core-June-2020\S18-JSON-Processing-Exercises\08. JSON-Processing-Product-Shop-Skeleton\ProductShop\Datasets\products.json");
            Console.WriteLine(ImportProducts(context, inputJson));


            foreach (var user in context.Users.Where(x => x.Age != null))
            {
                Console.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));
            }
        }


        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);           
            
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Users aded: {context.Users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Products aded: {context.Users.Count()}";
        }

        private static bool IsValid(object dto)
        {
           

            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}