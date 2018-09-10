namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resourcerole : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resources", "Role", c => c.Int(nullable: false));
            AlterColumn("dbo.Resources", "ResourceDuty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resources", "ResourceDuty", c => c.Short(nullable: false));
            AlterColumn("dbo.Resources", "Role", c => c.Short(nullable: false));
        }
    }
}
