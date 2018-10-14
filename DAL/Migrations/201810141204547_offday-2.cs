namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class offday2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OffDays", "OffWeekDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OffDays", "OffWeekDay");
        }
    }
}
