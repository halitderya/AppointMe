namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemarksAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Remarks");
        }
    }
}
