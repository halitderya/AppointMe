namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Offdaysadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OffDays",
                c => new
                    {
                        OffDaysID = c.Int(nullable: false, identity: true),
                        OffDaysType = c.Int(nullable: false),
                        OffDaysStart = c.DateTime(),
                        OffDaysEnd = c.DateTime(),
                        ResourceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OffDaysID)
                .ForeignKey("dbo.Resources", t => t.ResourceID, cascadeDelete: true)
                .Index(t => t.ResourceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OffDays", "ResourceID", "dbo.Resources");
            DropIndex("dbo.OffDays", new[] { "ResourceID" });
            DropTable("dbo.OffDays");
        }
    }
}
