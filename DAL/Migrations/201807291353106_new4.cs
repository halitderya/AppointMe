namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resources", "ResourceStartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resources", "ResourceStartDate", c => c.DateTime(nullable: false));
        }
    }
}
