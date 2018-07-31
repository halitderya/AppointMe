namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "AppointmentStatus", c => c.Short());
            AlterColumn("dbo.Appointments", "ChargedAmount", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "ChargedAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.Appointments", "AppointmentStatus", c => c.Short(nullable: false));
        }
    }
}
