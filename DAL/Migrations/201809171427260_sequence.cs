namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sequence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DependentJobs", "Sequence", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DependentJobs", "Sequence");
        }
    }
}
