using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VaporStore.Data;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var result = context.Genres
                .ToList()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new GamesByGenresExportJsonDto
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games.ToList()
                        .Select(game => new GameExportJsonDto
                        {
                            Id = game.Id,
                            Title = game.Name,
                            Developer = game.Developer.Name,
                            Tags = string.Join(", ", game.GameTags.Select(t => t.Tag.Name)),
                            Players = game.Purchases.Count
                        })
                        .Where(s => s.Players > 0)
                        .ToArray()
                        .OrderByDescending(s => s.Players)
                        .ThenBy(s => s.Id)
                        .ToArray(),
                    TotalPlayers = g.Games.SelectMany(x => x.Purchases).Count()
                })
                .ToList()
                .OrderByDescending(gb => gb.TotalPlayers)
                .ThenBy(gb => gb.Id)
                .ToList();

            var infoJson = JsonConvert.SerializeObject(result, Formatting.Indented);
            return infoJson;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var sb = new StringBuilder();

            XmlExportDto[] query = context.Users
                .ToList()
                .Select(u=>new XmlExportDto
                {
                    Username=u.Username                 
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlExportDto[]), new XmlRootAttribute("Users"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), query, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
