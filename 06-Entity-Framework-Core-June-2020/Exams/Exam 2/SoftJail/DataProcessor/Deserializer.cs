namespace SoftJail.DataProcessor
{

    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";
        public const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            DepartmentJsonDto[] departmentsDtos = JsonConvert.DeserializeObject<DepartmentJsonDto[]>(jsonString);

            List<Department> departments = new List<Department>();

            foreach (var obj in departmentsDtos)
            {
                if (!IsValid(obj))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department() { Name = obj.Name };

                bool isHaveInvalidCell = false;

                foreach (var c in obj.Cells)
                {
                    if (!IsValid(c))
                    {
                        isHaveInvalidCell = true;
                        break;
                    }

                    Cell cell = new Cell() { CellNumber = c.CellNumber, HasWindow = c.HasWindow };
                    department.Cells.Add(cell);
                }

                if (isHaveInvalidCell)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!obj.Cells.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                departments.Add(department);
                sb.AppendLine(string.Format(SuccessfullyImportedDepartment, department.Name, department.Cells.Count));
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            PrisonerJsonDto[] prisonersDtos = JsonConvert.DeserializeObject<PrisonerJsonDto[]>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (var obj in prisonersDtos)
            {
                if (!IsValid(obj))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarceration;
                DateTime release;
                bool isIncarcerationValid = DateTime.TryParseExact(obj.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out incarceration);

                if (!isIncarcerationValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = obj.FullName,
                    Nickname = obj.Nickname,
                    Age = obj.Age,
                    Bail = obj.Bail,
                    IncarcerationDate = incarceration,
                    CellId = obj.CellId
                };


                bool isReleaseValid = false;

                if (obj.ReleaseDate != null)
                {
                    isReleaseValid = DateTime.TryParseExact(obj.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out release);
                    if (isReleaseValid)
                    {
                        prisoner.ReleaseDate = release;
                    }
                }

                bool isHaveInvalidMail = false;

                foreach (var c in obj.Mails)
                {
                    if (!IsValid(c))
                    {
                        isHaveInvalidMail = true;
                        break;
                    }

                    Mail mail = new Mail() { Description = c.Description, Sender = c.Sender, Address = c.Address };
                    prisoner.Mails.Add(mail);
                }

                if (isHaveInvalidMail)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OfficerXmlDto[]), new XmlRootAttribute("Officers"));

            using (StringReader stringReader = new StringReader(xmlString))
            {

                OfficerXmlDto[] prisonersDto = (OfficerXmlDto[])xmlSerializer.Deserialize(stringReader);

                List<Officer> officers = new List<Officer>();


                foreach (var obj in prisonersDto)
                {
                    if (!IsValid(obj))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object position;
                    bool isPositionTypeValid =
                        Enum.TryParse(typeof(Position), obj.Position, out position);

                    object weapon;
                    bool isWeaponTypeValid =
                        Enum.TryParse(typeof(Weapon), obj.Weapon, out weapon);

                    if (!isPositionTypeValid || !isWeaponTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Officer officer = new Officer()
                    {
                        FullName = obj.Name,
                        Salary = obj.Money,
                        Position = (Position)position,
                        Weapon = (Weapon)weapon,
                        DepartmentId = obj.DepartmentId
                    };

                    foreach (var d in obj.Prisoners)
                    {
                        Prisoner p = context.Prisoners.FirstOrDefault(x => x.Id == d.Id);
                        officer.OfficerPrisoners.Add(new OfficerPrisoner() { Officer = officer, Prisoner = p });
                    }

                    officers.Add(officer);

                    sb.AppendLine($"Imported {officer.FullName} ({obj.Prisoners.Length} prisoners)");
                }

                context.Officers.AddRange(officers);
                context.SaveChanges();
                return sb.ToString().TrimEnd();
            }

        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}