namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobseqremove2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "JobSeq");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "JobSeq", c => c.Int(nullable: false));
        }
    }
}
