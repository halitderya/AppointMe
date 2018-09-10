namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "AppointmentStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "AppointmentStatus", c => c.Short());
        }
    }
}
