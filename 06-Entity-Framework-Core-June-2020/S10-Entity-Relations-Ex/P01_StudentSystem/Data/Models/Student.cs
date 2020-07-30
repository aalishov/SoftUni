namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Student
    {

        public Student()
        {
            this.HomeworkSubmissions = new List<Homework>();
            this.CourseEnrollments = new List<StudentCourse>();
        }
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; } 
    }
}
