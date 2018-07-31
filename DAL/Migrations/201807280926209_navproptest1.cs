namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navproptest1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources");
            DropForeignKey("dbo.Appointments", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.Appointments", "Resources_ResourceID", "dbo.Resources");
            DropForeignKey("dbo.Appointments", "Operator_ResourceID", "dbo.Resources");
            DropIndex("dbo.Appointments", new[] { "Resource_ResourceID" });
            DropIndex("dbo.Appointments", new[] { "Job_JobId" });
            DropIndex("dbo.Appointments", new[] { "Operator_ResourceID" });
            DropIndex("dbo.Appointments", new[] { "Resources_ResourceID" });
            RenameColumn(table: "dbo.Appointments", name: "Operator_ResourceID", newName: "ResourceId");
            RenameColumn(table: "dbo.Appointments", name: "Customers_CustomerID", newName: "Customer_CustomerID");
            RenameIndex(table: "dbo.Appointments", name: "IX_Customers_CustomerID", newName: "IX_Customer_CustomerID");
            AlterColumn("dbo.Appointments", "ResourceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "ResourceId");
            AddForeignKey("dbo.Appointments", "ResourceId", "dbo.Resources", "ResourceID", cascadeDelete: true);
            DropColumn("dbo.Appointments", "Resource_ResourceID");
            DropColumn("dbo.Appointments", "Job_JobId");
            DropColumn("dbo.Appointments", "Resources_ResourceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Resources_ResourceID", c => c.Int());
            AddColumn("dbo.Appointments", "Job_JobId", c => c.Int());
            AddColumn("dbo.Appointments", "Resource_ResourceID", c => c.Int());
            DropForeignKey("dbo.Appointments", "ResourceId", "dbo.Resources");
            DropIndex("dbo.Appointments", new[] { "ResourceId" });
            AlterColumn("dbo.Appointments", "ResourceId", c => c.Int());
            RenameIndex(table: "dbo.Appointments", name: "IX_Customer_CustomerID", newName: "IX_Customers_CustomerID");
            RenameColumn(table: "dbo.Appointments", name: "Customer_CustomerID", newName: "Customers_CustomerID");
            RenameColumn(table: "dbo.Appointments", name: "ResourceId", newName: "Operator_ResourceID");
            CreateIndex("dbo.Appointments", "Resources_ResourceID");
            CreateIndex("dbo.Appointments", "Operator_ResourceID");
            CreateIndex("dbo.Appointments", "Job_JobId");
            CreateIndex("dbo.Appointments", "Resource_ResourceID");
            AddForeignKey("dbo.Appointments", "Operator_ResourceID", "dbo.Resources", "ResourceID");
            AddForeignKey("dbo.Appointments", "Resources_ResourceID", "dbo.Resources", "ResourceID");
            AddForeignKey("dbo.Appointments", "Job_JobId", "dbo.Jobs", "JobId");
            AddForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources", "ResourceID");
        }
    }
}
