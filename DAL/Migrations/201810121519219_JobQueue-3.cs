namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobQueue3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "JobSeq", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "JobSeq", c => c.Int(nullable: false));
        }
    }
}
