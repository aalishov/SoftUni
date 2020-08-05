using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportEmployeeDto
    {
        public string Username { get; set; }
        public List<ExportTaskDto>  Tasks { get; set; }
    }
}
