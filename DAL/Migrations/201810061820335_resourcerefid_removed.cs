namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resourcerefid_removed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "ResourceRefID", "dbo.Resources");
            DropIndex("dbo.Appointments", new[] { "ResourceRefID" });
            RenameColumn(table: "dbo.Appointments", name: "ResourceRefID", newName: "Resource_ResourceID");
            AlterColumn("dbo.Appointments", "Resource_ResourceID", c => c.Int());
            CreateIndex("dbo.Appointments", "Resource_ResourceID");
            AddForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources", "ResourceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources");
            DropIndex("dbo.Appointments", new[] { "Resource_ResourceID" });
            AlterColumn("dbo.Appointments", "Resource_ResourceID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Appointments", name: "Resource_ResourceID", newName: "ResourceRefID");
            CreateIndex("dbo.Appointments", "ResourceRefID");
            AddForeignKey("dbo.Appointments", "ResourceRefID", "dbo.Resources", "ResourceID", cascadeDelete: true);
        }
    }
}
