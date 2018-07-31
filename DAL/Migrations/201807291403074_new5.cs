namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Jobs_JobId", "dbo.Jobs");
            DropIndex("dbo.Appointments", new[] { "Jobs_JobId" });
            RenameColumn(table: "dbo.Appointments", name: "Jobs_JobId", newName: "JobRefId");
            AlterColumn("dbo.Appointments", "JobRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "JobRefId");
            AddForeignKey("dbo.Appointments", "JobRefId", "dbo.Jobs", "JobId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "JobRefId", "dbo.Jobs");
            DropIndex("dbo.Appointments", new[] { "JobRefId" });
            AlterColumn("dbo.Appointments", "JobRefId", c => c.Int());
            RenameColumn(table: "dbo.Appointments", name: "JobRefId", newName: "Jobs_JobId");
            CreateIndex("dbo.Appointments", "Jobs_JobId");
            AddForeignKey("dbo.Appointments", "Jobs_JobId", "dbo.Jobs", "JobId");
        }
    }
}
