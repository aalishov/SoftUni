namespace P01_StudentSystem.Data.Models
{
    using P01_StudentSystem.Enums;
    using System.ComponentModel.DataAnnotations;
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
