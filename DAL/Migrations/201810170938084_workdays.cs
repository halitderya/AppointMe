namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workdays : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OffDays", "OffWeekDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OffDays", "OffWeekDay", c => c.String());
        }
    }
}
