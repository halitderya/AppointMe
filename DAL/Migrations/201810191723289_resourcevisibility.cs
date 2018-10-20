namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resourcevisibility : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "ResourceVisibility", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "ResourceVisibility");
        }
    }
}
