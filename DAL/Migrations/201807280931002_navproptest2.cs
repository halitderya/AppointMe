namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navproptest2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Operator_ResourceID", "dbo.Resources");
            DropForeignKey("dbo.Appointments", "ResourceId", "dbo.Resources");
            DropIndex("dbo.Appointments", new[] { "ResourceId" });
            DropIndex("dbo.Customers", new[] { "Operator_ResourceID" });
            AddColumn("dbo.Appointments", "Resource_ResourceID", c => c.Int());
            AddColumn("dbo.Customers", "ResourceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "Resource_ResourceID");
            AddForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources", "ResourceID");
            DropColumn("dbo.Customers", "Operator_ResourceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Operator_ResourceID", c => c.Int());
            DropForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources");
            DropIndex("dbo.Appointments", new[] { "Resource_ResourceID" });
            DropColumn("dbo.Customers", "ResourceID");
            DropColumn("dbo.Appointments", "Resource_ResourceID");
            CreateIndex("dbo.Customers", "Operator_ResourceID");
            CreateIndex("dbo.Appointments", "ResourceId");
            AddForeignKey("dbo.Appointments", "ResourceId", "dbo.Resources", "ResourceID", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "Operator_ResourceID", "dbo.Resources", "ResourceID");
        }
    }
}
