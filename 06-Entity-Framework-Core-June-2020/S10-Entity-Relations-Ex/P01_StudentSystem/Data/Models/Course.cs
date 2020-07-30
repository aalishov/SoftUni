namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Course
    {
        public Course()
        {
            this.Resources = new List<Resource>();
            this.HomeworkSubmissions = new List<Homework>();
            this.StudentsEnrolled = new List<StudentCourse>();
        }
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }

        public ICollection <StudentCourse> StudentsEnrolled  { get; set; }
    }
}
