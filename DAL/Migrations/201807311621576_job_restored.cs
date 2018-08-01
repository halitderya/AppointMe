namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job_restored : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobMode", c => c.Short(nullable: false));
            AddColumn("dbo.Jobs", "JobTimeSpan", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "JobTimeSpan");
            DropColumn("dbo.Jobs", "JobMode");
        }
    }
}
