

namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        // TODO: 1. Scaffold-DbContext -Connection "Server=(localdb)\MSSQLLocalDB;Database=SoftUni;Integrated Security=True;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models
        //TODO: 2. Uninstall-Package Microsoft.EntityFrameworkCore.Tools -r
        //TODO: 3. Uninstall-Package Microsoft.EntityFrameworkCore.SqlServer.Design -RemoveDependencies

        public static void Main()
        {
            SoftUniContext context = new SoftUniContext();
            //Console.WriteLine(GetEmployeesFullInformation(context));
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
            //Console.WriteLine(AddNewAddressToEmployee(context));
            //Console.WriteLine(GetEmployeesInPeriod(context));
            Console.WriteLine(GetAddressesByTown(context));
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            context.Addresses
                    .GroupBy(a => new
                    {
                        a.AddressId,
                        a.AddressText,
                        a.Town.Name
                    },
                        (key, group) => new
                        {
                            AddresTexts = key.AddressText,
                            Town = key.Name,
                            Count = group.Sum(a => a.Employees.Count)
                        })
                    .OrderByDescending(o => o.Count)
                    .ThenBy(o => o.Town)
                    .ThenBy(o => o.AddresTexts)
                    .Take(10)
                    .ToList()
                    .ForEach(x=>sb.AppendLine($"{x.AddresTexts} - {x.Count} employees"));

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            context.Employees
                   .Where(e => e.EmployeesProjects
                       .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                   .Take(10)
                   .Select(e => new {
                       e.FirstName,
                       e.LastName,
                       ManagerFirstName = e.Manager.FirstName,
                       ManagerLastName = e.Manager.LastName,
                       Projects = e.EmployeesProjects
                           .Select(ep => ep.Project)
                   })
                   .ToList()
                   .ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}{Environment.NewLine}" +
                   $"{String.Join(Environment.NewLine, e.Projects.Select(p => $"--{p.Name} - {p.StartDate.ToString()} - {(p.EndDate == null ? "not finished" : p.EndDate.ToString())}"))}"));
            return sb.ToString().TrimEnd();

        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {


            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Employees
                .Single(e => e.LastName == "Nakov")
                .Address = address;

            context.SaveChanges();
            var addresses = context.Employees.OrderByDescending(e => e.AddressId).Take(10).Select(e => e.Address.AddressText).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendLine(a);
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new { e.FirstName, e.LastName, e.Salary, e.Department })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var e in employees)
            {
                string fName = e.FirstName;
                string lName = e.LastName;
                string department = e.Department.Name;
                string salary = string.Format("{0:f2}", e.Salary);
                sb.AppendLine($"{fName} {lName} from {department} - {salary}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            const decimal greaterThen = 50000m;
            var employees = context.Employees.Where(e => e.Salary > greaterThen).OrderBy(e => e.FirstName).ToList();

            foreach (var e in employees)
            {
                string fName = e.FirstName;
                string salary = string.Format("{0:f2}", e.Salary);
                sb.AppendLine($"{fName} - {salary}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.ToList();

            foreach (var e in employees)
            {
                string fName = e.FirstName;
                string mName = e.MiddleName;
                string lName = e.LastName;
                string job = e.JobTitle;
                string salary = string.Format("{0:f2}", e.Salary);
                sb.AppendLine($"{fName} {lName} {mName} {job} {salary}");
            }
            return sb.ToString().TrimEnd();

        }
    }
}
