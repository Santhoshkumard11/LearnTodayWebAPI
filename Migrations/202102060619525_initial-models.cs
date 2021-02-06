namespace LearnTodayWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Fees = c.Single(nullable: false),
                        Description = c.String(),
                        Trainer = c.String(),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        EndrolemnentId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EndrolemnentId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        TrainerId = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.TrainerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "CourseId", "dbo.Course");
            DropIndex("dbo.Student", new[] { "CourseId" });
            DropTable("dbo.Trainer");
            DropTable("dbo.Student");
            DropTable("dbo.Course");
        }
    }
}
