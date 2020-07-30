namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class StudentCourse
    {
        [Key]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [Key]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
