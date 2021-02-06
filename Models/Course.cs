using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnTodayWebAPI.Models
{
    public class Course
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; }
        public String Description { get; set; }
        public string Trainer { get; set; }
        public DateTime StartDate { get; set; }
        //navigation property
        public List<Student> StudentsList { get; set; }
    }
}