namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job_restored2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "DefaultAssignee", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "DefaultAssignee");
        }
    }
}
