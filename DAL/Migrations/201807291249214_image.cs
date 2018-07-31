namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "ResourceImage", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "ResourceImage");
        }
    }
}
