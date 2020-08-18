using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
   public class ImportCardJsonDto
    {
        [RegularExpression(@"(\d{4}) (\d{4}) (\d{4}) (\d{4})")]
        [Required]
        public string Number { get; set; }

        [RegularExpression(@"(\d{3})")]
        [Required]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
