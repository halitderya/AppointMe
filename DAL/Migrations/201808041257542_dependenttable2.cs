namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dependenttable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DependentJobs", "DefaultResource_ResourceID", "dbo.Resources");
            DropForeignKey("dbo.DependentJobs", "DependentJob_JobId", "dbo.Jobs");
            DropForeignKey("dbo.DependentJobs", "MainJob_JobId", "dbo.Jobs");
            DropIndex("dbo.DependentJobs", new[] { "DefaultResource_ResourceID" });
            DropIndex("dbo.DependentJobs", new[] { "DependentJob_JobId" });
            DropIndex("dbo.DependentJobs", new[] { "MainJob_JobId" });
            AddColumn("dbo.DependentJobs", "MainJob", c => c.Int(nullable: false));
            AddColumn("dbo.DependentJobs", "DependentJob", c => c.Int(nullable: false));
            AddColumn("dbo.DependentJobs", "DefaultResource", c => c.Int(nullable: false));
            DropColumn("dbo.DependentJobs", "DefaultResource_ResourceID");
            DropColumn("dbo.DependentJobs", "DependentJob_JobId");
            DropColumn("dbo.DependentJobs", "MainJob_JobId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DependentJobs", "MainJob_JobId", c => c.Int());
            AddColumn("dbo.DependentJobs", "DependentJob_JobId", c => c.Int());
            AddColumn("dbo.DependentJobs", "DefaultResource_ResourceID", c => c.Int());
            DropColumn("dbo.DependentJobs", "DefaultResource");
            DropColumn("dbo.DependentJobs", "DependentJob");
            DropColumn("dbo.DependentJobs", "MainJob");
            CreateIndex("dbo.DependentJobs", "MainJob_JobId");
            CreateIndex("dbo.DependentJobs", "DependentJob_JobId");
            CreateIndex("dbo.DependentJobs", "DefaultResource_ResourceID");
            AddForeignKey("dbo.DependentJobs", "MainJob_JobId", "dbo.Jobs", "JobId");
            AddForeignKey("dbo.DependentJobs", "DependentJob_JobId", "dbo.Jobs", "JobId");
            AddForeignKey("dbo.DependentJobs", "DefaultResource_ResourceID", "dbo.Resources", "ResourceID");
        }
    }
}
