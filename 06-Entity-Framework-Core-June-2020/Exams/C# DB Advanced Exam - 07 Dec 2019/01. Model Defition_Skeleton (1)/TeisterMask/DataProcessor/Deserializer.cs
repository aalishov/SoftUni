namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.Linq;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            var attr = new XmlRootAttribute("Projects");
            var serializer = new XmlSerializer(typeof(ImportProjectXmlDto[]), attr);

            var deserializedOrders =
              (ImportProjectXmlDto[])serializer.Deserialize(new StringReader(xmlString));

            HashSet<Project> validProjects = new HashSet<Project>();

            foreach (var project in deserializedOrders)
            {
                if (!IsValid(project))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectOpenDate;
                DateTime projectDueDate;

                bool isValidProjectOpenDate = DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                if (!isValidProjectOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Project validProject = new Project()
                {
                    Name = project.Name,
                    OpenDate = projectOpenDate,
                    DueDate = null
                };

                if (project.DueDate != string.Empty)
                {
                    bool isValidProjectDueDate = DateTime.TryParseExact(project.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDate);
                    validProject.DueDate = projectDueDate;
                }


                foreach (var task in project.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    DateTime taskDueDate;

                    bool isValidTaskOpenDate = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);
                    bool isValidTaskDueDate = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);


                    if (!(isValidTaskOpenDate && isValidTaskDueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (validProject.DueDate != null)
                    {
                        if (taskDueDate > validProject.DueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    if (taskOpenDate < validProject.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task validTask = new Task()
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType
                    };
                    validProject.Tasks.Add(validTask);
                }
                validProjects.Add(validProject);

                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, validProject.Tasks.Count));
            }
            context.Projects.AddRange(validProjects);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportJsonEmployeeDto[] employeeDtos = JsonConvert.DeserializeObject<ImportJsonEmployeeDto[]>(jsonString);

            HashSet<Employee> validEmployees = new HashSet<Employee>();

            foreach (var employee in employeeDtos)
            {
                if (!IsValid(employee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                
                Employee validEmploee = new Employee()
                {
                    Username=employee.Username,
                    Email=employee.Email,
                    Phone=employee.Phone,
                };

                foreach (var task in employee.Tasks.Distinct())
                {
                   var isExist= context.Tasks.Any(x => x.Id == task);
                    if (isExist)
                    {
                        Task task1 = context.Tasks.FirstOrDefault(x => x.Id == task);
                        validEmploee.EmployeesTasks.Add(new EmployeeTask { Employee = validEmploee, Task = task1 });
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                }
                validEmployees.Add(validEmploee);
                sb.AppendLine($"{string.Format(SuccessfullyImportedEmployee,validEmploee.Username,validEmploee.EmployeesTasks.Count)}");
            }
            context.Employees.AddRange(validEmployees);
            context.SaveChanges();
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