namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointmentforein : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources");
            DropIndex("dbo.Appointments", new[] { "Resource_ResourceID" });
            RenameColumn(table: "dbo.Appointments", name: "Resource_ResourceID", newName: "ResourceRefID");
            AlterColumn("dbo.Appointments", "ResourceRefID", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "ResourceRefID");
            AddForeignKey("dbo.Appointments", "ResourceRefID", "dbo.Resources", "ResourceID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "ResourceRefID", "dbo.Resources");
            DropIndex("dbo.Appointments", new[] { "ResourceRefID" });
            AlterColumn("dbo.Appointments", "ResourceRefID", c => c.Int());
            RenameColumn(table: "dbo.Appointments", name: "ResourceRefID", newName: "Resource_ResourceID");
            CreateIndex("dbo.Appointments", "Resource_ResourceID");
            AddForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources", "ResourceID");
        }
    }
}
