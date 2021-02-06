using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnTodayWebAPI.Models
{
    public class Student
    {

        public int EndrolemnentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        //navigation property
        public List<Course> CourseList { get; set; }
    }
}