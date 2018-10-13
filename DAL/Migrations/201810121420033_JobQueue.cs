namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobQueue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "JobName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "JobName", c => c.String());
        }
    }
}
