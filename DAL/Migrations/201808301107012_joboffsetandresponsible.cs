namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class joboffsetandresponsible : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobResponsible", c => c.Short(nullable: false));
            AddColumn("dbo.Jobs", "JobOffsetTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Resources", "ResourceDuty", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "ResourceDuty");
            DropColumn("dbo.Jobs", "JobOffsetTime");
            DropColumn("dbo.Jobs", "JobResponsible");
        }
    }
}
