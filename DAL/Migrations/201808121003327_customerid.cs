namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.Appointments", new[] { "Customer_CustomerID" });
            RenameColumn(table: "dbo.Appointments", name: "Customer_CustomerID", newName: "CustomerRefId");
            AddColumn("dbo.Appointments", "ParentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointments", "CustomerRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "CustomerRefId");
            AddForeignKey("dbo.Appointments", "CustomerRefId", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "CustomerRefId", "dbo.Customers");
            DropIndex("dbo.Appointments", new[] { "CustomerRefId" });
            AlterColumn("dbo.Appointments", "CustomerRefId", c => c.Int());
            DropColumn("dbo.Appointments", "ParentID");
            RenameColumn(table: "dbo.Appointments", name: "CustomerRefId", newName: "Customer_CustomerID");
            CreateIndex("dbo.Appointments", "Customer_CustomerID");
            AddForeignKey("dbo.Appointments", "Customer_CustomerID", "dbo.Customers", "CustomerID");
        }
    }
}
