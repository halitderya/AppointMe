namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navproptest3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources");
            DropIndex("dbo.Appointments", new[] { "Resource_ResourceID" });
            DropColumn("dbo.Appointments", "ResourceId");
            RenameColumn(table: "dbo.Appointments", name: "Resource_ResourceID", newName: "ResourceId");
            AddColumn("dbo.Appointments", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Appointments", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointments", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointments", "DeleteDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointments", "ResourceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "ResourceId");
            AddForeignKey("dbo.Appointments", "ResourceId", "dbo.Resources", "ResourceID", cascadeDelete: true);
            DropColumn("dbo.Customers", "CreateDate");
            DropColumn("dbo.Customers", "UpdateDate");
            DropColumn("dbo.Customers", "DeleteDate");
            DropColumn("dbo.Customers", "ResourceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ResourceID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "DeleteDate", c => c.DateTime());
            AddColumn("dbo.Customers", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Customers", "CreateDate", c => c.DateTime());
            DropForeignKey("dbo.Appointments", "ResourceId", "dbo.Resources");
            DropIndex("dbo.Appointments", new[] { "ResourceId" });
            AlterColumn("dbo.Appointments", "ResourceId", c => c.Int());
            AlterColumn("dbo.Appointments", "DeleteDate", c => c.DateTime());
            AlterColumn("dbo.Appointments", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Appointments", "CreateDate", c => c.DateTime());
            DropColumn("dbo.Appointments", "UpdatedBy");
            RenameColumn(table: "dbo.Appointments", name: "ResourceId", newName: "Resource_ResourceID");
            AddColumn("dbo.Appointments", "ResourceID", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "ResourceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "Resource_ResourceID");
            AddForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources", "ResourceID");
        }
    }
}
