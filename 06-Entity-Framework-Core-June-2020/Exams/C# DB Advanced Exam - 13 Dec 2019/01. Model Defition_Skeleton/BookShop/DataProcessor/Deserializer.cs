namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<AuthorDto> authors = JsonConvert.DeserializeObject<IEnumerable<AuthorDto>>(jsonString);

            foreach (var author in authors)
            {
                if (!IsValid(author))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newAuthor = new Author
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Email = author.Email,
                    Phone = author.Phone
                };

                foreach (var book in author.Books)
                {
                    if (!context.Books.Any(x=>x.Id==book.Id))
                    {
                        continue;
                    }
                    newAuthor.AuthorsBooks.Add(new AuthorBook() { AuthorId = newAuthor.Id, BookId = (int)book.Id });
                }

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, newAuthor.FirstName + newAuthor.LastName, newAuthor.AuthorsBooks.Count()));

                context.Authors.Add(newAuthor);
                context.SaveChanges();

               
            }

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}