namespace WebLayihe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventEndDateToDatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EndTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
