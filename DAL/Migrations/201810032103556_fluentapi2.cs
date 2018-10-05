namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluentapi2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AppointmentJobs", newName: "JobAppointments");
            DropPrimaryKey("dbo.JobAppointments");
            AddPrimaryKey("dbo.JobAppointments", new[] { "Job_JobId", "Appointment_AppointmentID" });
            DropTable("dbo.JobAppointments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobAppointments",
                c => new
                    {
                        Job_JobId = c.Int(nullable: false),
                        Appointment_AppointmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_JobId, t.Appointment_AppointmentID });
            
            DropPrimaryKey("dbo.JobAppointments");
            AddPrimaryKey("dbo.JobAppointments", new[] { "Appointment_AppointmentID", "Job_JobId" });
            RenameTable(name: "dbo.JobAppointments", newName: "AppointmentJobs");
        }
    }
}
