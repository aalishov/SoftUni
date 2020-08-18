﻿using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Officer
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string FullName { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public  Position Position { get; set; }

        [Required]
        public Weapon Weapon { get; set; }

        [Required]
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        [Required]
        public virtual Department Department { get; set; }

        public virtual ICollection<OfficerPrisoner> OfficerPrisoners { get; set; } = new List<OfficerPrisoner>();
    }
}
