namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobowner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobOwner", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "JobOwner");
        }
    }
}
