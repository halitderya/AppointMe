namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dependenttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DependentJobs",
                c => new
                    {
                        DependentID = c.Int(nullable: false, identity: true),
                        DefaultResource_ResourceID = c.Int(),
                        DependentJob_JobId = c.Int(),
                        MainJob_JobId = c.Int(),
                    })
                .PrimaryKey(t => t.DependentID)
                .ForeignKey("dbo.Resources", t => t.DefaultResource_ResourceID)
                .ForeignKey("dbo.Jobs", t => t.DependentJob_JobId)
                .ForeignKey("dbo.Jobs", t => t.MainJob_JobId)
                .Index(t => t.DefaultResource_ResourceID)
                .Index(t => t.DependentJob_JobId)
                .Index(t => t.MainJob_JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DependentJobs", "MainJob_JobId", "dbo.Jobs");
            DropForeignKey("dbo.DependentJobs", "DependentJob_JobId", "dbo.Jobs");
            DropForeignKey("dbo.DependentJobs", "DefaultResource_ResourceID", "dbo.Resources");
            DropIndex("dbo.DependentJobs", new[] { "MainJob_JobId" });
            DropIndex("dbo.DependentJobs", new[] { "DependentJob_JobId" });
            DropIndex("dbo.DependentJobs", new[] { "DefaultResource_ResourceID" });
            DropTable("dbo.DependentJobs");
        }
    }
}
