namespace WebLayihe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCoursePrice : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "PriceId", "dbo.CoursePrices");
            DropIndex("dbo.Courses", new[] { "PriceId" });
            AddColumn("dbo.Courses", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "Duration", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "ClassDuration", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "SkillLevel", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Courses", "Language", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Courses", "StudentCount", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "Assesments", c => c.String(maxLength: 30));
            AddColumn("dbo.Courses", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.Courses", "PriceId");
            DropTable("dbo.CoursePrices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CoursePrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        ClassDuration = c.Int(nullable: false),
                        SkillLevel = c.String(nullable: false, maxLength: 30),
                        Language = c.String(nullable: false, maxLength: 20),
                        StudentCount = c.Int(nullable: false),
                        Assesments = c.String(maxLength: 30),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "PriceId", c => c.Int(nullable: false));
            DropColumn("dbo.Courses", "Price");
            DropColumn("dbo.Courses", "Assesments");
            DropColumn("dbo.Courses", "StudentCount");
            DropColumn("dbo.Courses", "Language");
            DropColumn("dbo.Courses", "SkillLevel");
            DropColumn("dbo.Courses", "ClassDuration");
            DropColumn("dbo.Courses", "Duration");
            DropColumn("dbo.Courses", "StartDate");
            CreateIndex("dbo.Courses", "PriceId");
            AddForeignKey("dbo.Courses", "PriceId", "dbo.CoursePrices", "Id", cascadeDelete: true);
        }
    }
}
