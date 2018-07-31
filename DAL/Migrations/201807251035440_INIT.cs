namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        OperatorID = c.Int(nullable: false, identity: true),
                        OperatorUserName = c.String(),
                        OperatorPassword = c.String(),
                        OperatorRole = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        Resource_ResourceID = c.Int(),
                    })
                .PrimaryKey(t => t.OperatorID)
                .ForeignKey("dbo.Resources", t => t.Resource_ResourceID)
                .Index(t => t.Resource_ResourceID);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceID = c.Int(nullable: false, identity: true),
                        ResourceName = c.String(),
                        ResourceSurname = c.String(),
                        ResourceStartDate = c.DateTime(nullable: false),
                        ResourcePhone = c.String(),
                        ResourceEmerphone = c.String(),
                        ResourceAddress = c.String(),
                        ResourcePostcode = c.String(),
                        ResourceCity = c.String(),
                        ResourceType = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ResourceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operators", "Resource_ResourceID", "dbo.Resources");
            DropIndex("dbo.Operators", new[] { "Resource_ResourceID" });
            DropTable("dbo.Resources");
            DropTable("dbo.Operators");
        }
    }
}
