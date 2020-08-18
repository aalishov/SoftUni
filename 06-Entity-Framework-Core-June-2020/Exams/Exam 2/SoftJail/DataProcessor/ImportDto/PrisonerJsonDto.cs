using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerJsonDto
    {
        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("The ([A-Z]{1}[a-z]+)")]
        public string Nickname { get; set; }

        [Required]
        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public MailJsonDto[] Mails { get; set; }
    }
}
