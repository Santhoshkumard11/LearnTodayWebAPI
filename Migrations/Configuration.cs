namespace LearnTodayWebAPI.Migrations
{
    using LearnTodayWebAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LearnTodayWebAPI.DAL.LearnTodayWebAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LearnTodayWebAPI.DAL.LearnTodayWebAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Courses.AddRange(new List<Course>()
            {
                new Course {CourseId=1002, Title=".Net Core", Fees=(float)9000.0,Description=".Net Core is a framework used for creating cross platform application",Trainer="Joe",StartDate=DateTime.Now,StudentsList=new List<Student>()},
                new Course {CourseId=1003, Title="Angular", Fees=(float)3000.0,Description="Angular is a platform and framework for building single page client application",Trainer="Saw",StartDate=DateTime.Now,StudentsList=new List<Student>()}
            }
            ) ;
        }
    }
}