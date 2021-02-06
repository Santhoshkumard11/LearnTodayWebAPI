using System.ComponentModel.DataAnnotations;

namespace LearnTodayWebAPI.Models
{
    public class Student
    {
        [Key]
        public int EndrolemnentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        //navigation property
        public Course Course { get; set; }
    }
}