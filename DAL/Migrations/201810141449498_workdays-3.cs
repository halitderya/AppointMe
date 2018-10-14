namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workdays3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OffDays", name: "ResourceID", newName: "ResourceRefID");
            RenameIndex(table: "dbo.OffDays", name: "IX_ResourceID", newName: "IX_ResourceRefID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OffDays", name: "IX_ResourceRefID", newName: "IX_ResourceID");
            RenameColumn(table: "dbo.OffDays", name: "ResourceRefID", newName: "ResourceID");
        }
    }
}
