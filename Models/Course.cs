using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnTodayWebAPI.Models
{
    public class Course
    {
        [Key]
        //use this to add custom values to PK
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; }
        public String Description { get; set; }
        public string Trainer { get; set; }
        public DateTime StartDate { get; set; }

        //navigation property
        public List<Student> StudentsList { get; set; }
    }
}