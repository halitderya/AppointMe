namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class multiplejob : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AppointmentJobs", newName: "JobAppointments");
            DropPrimaryKey("dbo.JobAppointments");
            AddPrimaryKey("dbo.JobAppointments", new[] { "Job_JobId", "Appointment_AppointmentID" });
            DropColumn("dbo.Appointments", "JobRefId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "JobRefId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.JobAppointments");
            AddPrimaryKey("dbo.JobAppointments", new[] { "Appointment_AppointmentID", "Job_JobId" });
            RenameTable(name: "dbo.JobAppointments", newName: "AppointmentJobs");
        }
    }
}
