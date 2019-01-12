namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondThirdPhoneAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SecondPhone", c => c.String());
            AddColumn("dbo.Customers", "ThirdPhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ThirdPhone");
            DropColumn("dbo.Customers", "SecondPhone");
        }
    }
}
