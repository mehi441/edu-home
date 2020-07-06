namespace WebLayihe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Image", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Image");
        }
    }
}
