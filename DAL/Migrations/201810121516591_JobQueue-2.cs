namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobQueue2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobSeq", c => c.Int(nullable: true));
            AlterColumn("dbo.Jobs", "JobName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "JobName", c => c.String());
            DropColumn("dbo.Jobs", "JobSeq");
        }
    }
}
