namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class defaultassigneeremoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "DefaultAssignee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "DefaultAssignee", c => c.Int(nullable: false));
        }
    }
}
