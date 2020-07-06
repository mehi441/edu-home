namespace WebLayihe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventStartDateToDAtetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "StartTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "StartTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
