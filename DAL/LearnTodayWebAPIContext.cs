using LearnTodayWebAPI.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LearnTodayWebAPI.DAL
{
    public class LearnTodayWebAPIContext : DbContext
    {
        // Your context has been configured to use a 'LearnTodayWebAPI' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LearnTodayWebAPI.DAL.LearnTodayWebAPI' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LearnTodayWebAPI' 
        // connection string in the application configuration file.
        public LearnTodayWebAPIContext()
            : base("name=LearnTodayWebAPIContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Trainer> Tainers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}