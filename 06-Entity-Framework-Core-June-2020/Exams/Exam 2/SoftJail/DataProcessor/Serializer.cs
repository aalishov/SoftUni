namespace SoftJail.DataProcessor
{

    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var query = context
                .Prisoners
                .ToArray()
                .Where(s => ids.Contains(s.Id))
                .Select(p => new PrisonerCellsExportJsonDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(op => new OfficerExport
                    {
                        OfficerName = op.Officer.FullName,
                        Department = op.Officer.Department.Name
                    }).ToList().OrderBy(o => o.OfficerName).ToList(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(op => op.Officer.Salary)
                })
                .ToList()
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id);


            string json = JsonConvert.SerializeObject(query, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {

            string[] names = prisonersNames.Split(',');
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(InboxExportXmlDto[]), new XmlRootAttribute("Prisoners"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            using (StringWriter stringWriter = new StringWriter(sb))
            {
                InboxExportXmlDto[] query = context
                    .Prisoners
                    .ToArray()
                    .Where(p => names.Contains(p.FullName))
                    .Select(p => new InboxExportXmlDto
                    {
                        Id = p.Id,
                        Name = p.FullName,
                        IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        EncryptedMessages = p.Mails
                            .Select(m => new EcreptedMessage { Description = new string(m.Description.ToCharArray().Reverse().ToArray()) })
                            .ToArray()
                    })
                    .ToArray()
                    .OrderBy(p=>p.Name)
                    .ThenBy(p=>p.Id)
                    .ToArray();

                xmlSerializer.Serialize(stringWriter, query, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

    }
}
