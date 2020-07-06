namespace WebLayihe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        Image = c.String(maxLength: 200),
                        VideoTitle = c.String(nullable: false, maxLength: 200),
                        VideoLink = c.String(nullable: false, maxLength: 200),
                        VideoBgImage = c.String(maxLength: 200),
                        NoticeTitle = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AboutSlides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 40),
                        Content = c.String(nullable: false, maxLength: 300),
                        Image = c.String(maxLength: 200),
                        OccupationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Occupations", t => t.OccupationId, cascadeDelete: true)
                .Index(t => t.OccupationId);
            
            CreateTable(
                "dbo.Occupations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 200),
                        OccupationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Occupations", t => t.OccupationId, cascadeDelete: true)
                .Index(t => t.OccupationId);
            
            CreateTable(
                "dbo.SpeakerEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        SpeakerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Speakers", t => t.SpeakerId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.SpeakerId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 200),
                        Title = c.String(nullable: false, maxLength: 150),
                        CreatedDate = c.DateTime(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Venue = c.String(nullable: false, maxLength: 150),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        CatagoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventCatagories", t => t.CatagoryId, cascadeDelete: true)
                .Index(t => t.CatagoryId);
            
            CreateTable(
                "dbo.EventCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        Image = c.String(maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Skype = c.String(nullable: false, maxLength: 30),
                        Language = c.Int(nullable: false),
                        TeamLeader = c.Int(nullable: false),
                        Development = c.Int(nullable: false),
                        Design = c.Int(nullable: false),
                        Innovation = c.Int(nullable: false),
                        Communication = c.Int(nullable: false),
                        OccupationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Occupations", t => t.OccupationId, cascadeDelete: true)
                .Index(t => t.OccupationId);
            
            CreateTable(
                "dbo.Socials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Icon = c.String(nullable: false, maxLength: 100),
                        Link = c.String(nullable: false, maxLength: 150),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 250),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        CreateDate = c.DateTime(nullable: false),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        Author = c.String(nullable: false, maxLength: 50),
                        ViewCount = c.Int(nullable: false),
                        Image = c.String(maxLength: 200),
                        CatagoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCatagories", t => t.CatagoryId, cascadeDelete: true)
                .Index(t => t.CatagoryId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 200),
                        Title = c.String(nullable: false, maxLength: 50),
                        FirstAddress = c.String(nullable: false, maxLength: 100),
                        SecondAddress = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 70),
                        Explanation = c.String(nullable: false, maxLength: 600),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        CatagoryId = c.Int(nullable: false),
                        PriceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseCatagories", t => t.CatagoryId, cascadeDelete: true)
                .ForeignKey("dbo.CoursePrices", t => t.PriceId, cascadeDelete: true)
                .Index(t => t.CatagoryId)
                .Index(t => t.PriceId);
            
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
            
            CreateTable(
                "dbo.Headers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Image = c.String(maxLength: 200),
                        Page = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeSlides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Content = c.String(nullable: false, maxLength: 300),
                        Image = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 30),
                        Subject = c.String(nullable: false, maxLength: 70),
                        Content = c.String(nullable: false, maxLength: 500),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddedDate = c.DateTime(nullable: false),
                        Content = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(maxLength: 200),
                        NavbarPhone = c.String(nullable: false, maxLength: 20),
                        BgImage = c.String(maxLength: 200),
                        Content = c.String(nullable: false, maxLength: 400),
                        Copyright = c.String(nullable: false, maxLength: 50),
                        FistAddress = c.String(nullable: false, maxLength: 70),
                        SecondAddress = c.String(maxLength: 70),
                        FirstPhone = c.String(nullable: false, maxLength: 20),
                        SecondPhone = c.String(maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        SidebarImage = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SettingSocials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Icon = c.String(nullable: false, maxLength: 100),
                        Link = c.String(nullable: false, maxLength: 100),
                        SettingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Settings", t => t.SettingId, cascadeDelete: true)
                .Index(t => t.SettingId);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 30),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Surname = c.String(nullable: false, maxLength: 30),
                        Username = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 20),
                        AddedDate = c.DateTime(nullable: false),
                        Image = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SettingSocials", "SettingId", "dbo.Settings");
            DropForeignKey("dbo.Courses", "PriceId", "dbo.CoursePrices");
            DropForeignKey("dbo.Courses", "CatagoryId", "dbo.CourseCatagories");
            DropForeignKey("dbo.Blogs", "CatagoryId", "dbo.BlogCatagories");
            DropForeignKey("dbo.Socials", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.SpeakerEvents", "SpeakerId", "dbo.Speakers");
            DropForeignKey("dbo.SpeakerEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "CatagoryId", "dbo.EventCatagories");
            DropForeignKey("dbo.Speakers", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.AboutSlides", "OccupationId", "dbo.Occupations");
            DropIndex("dbo.SettingSocials", new[] { "SettingId" });
            DropIndex("dbo.Courses", new[] { "PriceId" });
            DropIndex("dbo.Courses", new[] { "CatagoryId" });
            DropIndex("dbo.Blogs", new[] { "CatagoryId" });
            DropIndex("dbo.Socials", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "OccupationId" });
            DropIndex("dbo.Events", new[] { "CatagoryId" });
            DropIndex("dbo.SpeakerEvents", new[] { "SpeakerId" });
            DropIndex("dbo.SpeakerEvents", new[] { "EventId" });
            DropIndex("dbo.Speakers", new[] { "OccupationId" });
            DropIndex("dbo.AboutSlides", new[] { "OccupationId" });
            DropTable("dbo.Users");
            DropTable("dbo.Subscribes");
            DropTable("dbo.SettingSocials");
            DropTable("dbo.Settings");
            DropTable("dbo.Notices");
            DropTable("dbo.Messages");
            DropTable("dbo.HomeSlides");
            DropTable("dbo.Headers");
            DropTable("dbo.CoursePrices");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseCatagories");
            DropTable("dbo.Contacts");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCatagories");
            DropTable("dbo.Admins");
            DropTable("dbo.Socials");
            DropTable("dbo.Teachers");
            DropTable("dbo.EventCatagories");
            DropTable("dbo.Events");
            DropTable("dbo.SpeakerEvents");
            DropTable("dbo.Speakers");
            DropTable("dbo.Occupations");
            DropTable("dbo.AboutSlides");
            DropTable("dbo.Abouts");
        }
    }
}
