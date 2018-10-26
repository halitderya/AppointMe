namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resindex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "Index", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "Index");
        }
    }
}
