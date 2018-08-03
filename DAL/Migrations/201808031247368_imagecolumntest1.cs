namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagecolumntest1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resources", "ResourceImage", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resources", "ResourceImage", c => c.Byte(nullable: false));
        }
    }
}
