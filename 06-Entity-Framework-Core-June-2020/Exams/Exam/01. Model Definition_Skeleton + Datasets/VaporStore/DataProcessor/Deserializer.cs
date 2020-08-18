namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportJsonDto[] jsonDto = JsonConvert.DeserializeObject<ImportJsonDto[]>(jsonString);

            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();
                
            foreach (var obj in jsonDto)
            {
                if (!IsValid(obj))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime releaseDate;

                bool isValid = DateTime.TryParseExact(obj.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!isValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!obj.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!developers.Any(x => x.Name == obj.Developer))
                {
                   developers.Add(new Developer() { Name = obj.Developer });
                }

                if (!genres.Any(x => x.Name == obj.Genre))
                {
                    genres.Add(new Genre() { Name = obj.Genre });
                }

                foreach (var tag in obj.Tags)
                {
                    if (!tags.Any(x => x.Name == tag))
                    {
                        tags.Add(new Tag() { Name = tag });
                    }
                }


                Developer developer = developers.FirstOrDefault(x => x.Name == obj.Developer);
                Genre genre = genres.FirstOrDefault(x => x.Name == obj.Genre);

                Game game = new Game()
                {
                    Name = obj.Name,
                    Price = obj.Price,
                    ReleaseDate = releaseDate,
                    Developer = developer,
                    Genre = genre
                };

                foreach (var tag in obj.Tags)
                {
                    Tag addTag = tags.FirstOrDefault(x => x.Name == tag);
                    game.GameTags.Add(new GameTag { Game = game, Tag = addTag });
                }

                games.Add(game);
                sb.AppendLine($"Added {obj.Name} ({obj.Genre}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportUserJsonDto[] jsonDto = JsonConvert.DeserializeObject<ImportUserJsonDto[]>(jsonString);

            List<User> users = new List<User>();

            foreach (var obj in jsonDto)
            {
                if (!IsValid(obj))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User()
                {
                    Username=obj.Username,
                    FullName=obj.FullName,
                    Email=obj.FullName,
                    Age=obj.Age
                };

                foreach (var card in obj.Cards)
                {
                    if (!IsValid(card))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    int cardType = -1;
                    if (card.Type=="Debit")
                    {
                        cardType = 0;
                    }
                    else if (card.Type == "Credit")
                    {
                        cardType = 1;
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Card addCard = new Card
                    {
                        Number = card.Number,
                        Cvc = card.CVC,
                        Type = (CardType)cardType
                    };
                    user.Cards.Add(addCard);
                }
                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }
            context.Users.AddRange(users);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchaseXmlDto[]), new XmlRootAttribute("Purchases"));

            StringReader reader = new StringReader(xmlString);

            using (reader)
            {
                ImportPurchaseXmlDto[] purchDto = (ImportPurchaseXmlDto[])serializer.Deserialize(reader);

                List<Purchase> purchases = new List<Purchase>();

                foreach (var p in purchDto)
                {
                    if (!IsValid(p))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime date;

                    bool isDateValid = DateTime.TryParseExact(p.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                    if (!isDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    int type = -1;

                    if (p.Type== "Retail")
                    {
                        type = 0;
                    }
                    else if (p.Type == "Digital")
                    {
                        type = 1;
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Card card = context.Cards.FirstOrDefault(x=>x.Number==p.Card);
                    Game game = context.Games.FirstOrDefault(x => x.Name == p.Game);

                    if (card==null||game==null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Purchase purchase = new Purchase()
                    {
                        Type=(PurchaseType)type,
                        ProductKey=p.Key,
                        Date=date,
                        Card=card,
                        Game=game
                    };

                    purchases.Add(purchase);
                    sb.AppendLine($"Imported {p.Game} for {card.User.Username}");
                }

                context.Purchases.AddRange(purchases);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}