namespace TeisterMask.DataProcessor
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            return "1";
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();


            var query = context.Employees
                           .Select(e => new
                           {
                               Username = e.Username,
                               Tasks = e.EmployeesTasks
                                   .Select(t => new
                                   {
                                       Name = t.Task.Name,
                                       OpenDate = t.Task.OpenDate,
                                       DueDate = t.Task.DueDate,
                                       LabelType = t.Task.LabelType.ToString(),
                                       ExecutionType = t.Task.ExecutionType.ToString()
                                   }
                                   )
                                   .Where(t => t.OpenDate >= date)
                                   .OrderByDescending(t => t.DueDate)
                                   .ThenBy(t => t.Name)
                           })
                            .Where(e => e.Tasks.Count() > 0)
                              .OrderByDescending(t => t.Tasks.Count())
                              .ThenBy(e => e.Username)
                              .Take(10)
                              .ToList();

            string json = JsonConvert.SerializeObject(query, new JsonSerializerSettings()
            {
                DateFormatString="d",
                Formatting = Formatting.Indented
            });

            return json;
        }
    }
}