using System;
using System.Collections.Generic;
using System.Text;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportTaskDto
    {
        public string TaskName { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime DueDate { get; set; }

        public string LabelType { get; set; }

        public string ExecutionType { get; set; }
    }
}
