namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navproptestfinal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "ResourceId", "dbo.Resources");
            DropIndex("dbo.Appointments", new[] { "ResourceId" });
            RenameColumn(table: "dbo.Appointments", name: "ResourceId", newName: "Resource_ResourceID");
            AddColumn("dbo.Appointments", "Jobs_JobId", c => c.Int());
            AlterColumn("dbo.Appointments", "Resource_ResourceID", c => c.Int());
            CreateIndex("dbo.Appointments", "Jobs_JobId");
            CreateIndex("dbo.Appointments", "Resource_ResourceID");
            AddForeignKey("dbo.Appointments", "Jobs_JobId", "dbo.Jobs", "JobId");
            AddForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources", "ResourceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources");
            DropForeignKey("dbo.Appointments", "Jobs_JobId", "dbo.Jobs");
            DropIndex("dbo.Appointments", new[] { "Resource_ResourceID" });
            DropIndex("dbo.Appointments", new[] { "Jobs_JobId" });
            AlterColumn("dbo.Appointments", "Resource_ResourceID", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "Jobs_JobId");
            RenameColumn(table: "dbo.Appointments", name: "Resource_ResourceID", newName: "ResourceId");
            CreateIndex("dbo.Appointments", "ResourceId");
            AddForeignKey("dbo.Appointments", "ResourceId", "dbo.Resources", "ResourceID", cascadeDelete: true);
        }
    }
}
