namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluentapi : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.JobAppointments", newName: "AppointmentJobs");
            DropPrimaryKey("dbo.AppointmentJobs");
            CreateTable(
                "dbo.JobAppointments",
                c => new
                    {
                        Job_JobId = c.Int(nullable: false),
                        Appointment_AppointmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_JobId, t.Appointment_AppointmentID })
                .Index(t => t.Job_JobId)
                .Index(t => t.Appointment_AppointmentID);
            
            AddPrimaryKey("dbo.AppointmentJobs", new[] { "Appointment_AppointmentID", "Job_JobId" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.JobAppointments", new[] { "Appointment_AppointmentID" });
            DropIndex("dbo.JobAppointments", new[] { "Job_JobId" });
            DropPrimaryKey("dbo.AppointmentJobs");
            DropTable("dbo.JobAppointments");
            AddPrimaryKey("dbo.AppointmentJobs", new[] { "Job_JobId", "Appointment_AppointmentID" });
            RenameTable(name: "dbo.AppointmentJobs", newName: "JobAppointments");
        }
    }
}
