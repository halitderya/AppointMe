namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class color4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Color", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Color", c => c.Int(nullable: false));
        }
    }
}
