namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class App_Job_Nav_propTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobAppointments", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.JobAppointments", "Appointment_AppointmentID", "dbo.Appointments");
            DropIndex("dbo.JobAppointments", new[] { "Job_JobId" });
            DropIndex("dbo.JobAppointments", new[] { "Appointment_AppointmentID" });
            AddColumn("dbo.Jobs", "Appointments_AppointmentID", c => c.Int());
            CreateIndex("dbo.Jobs", "Appointments_AppointmentID");
            AddForeignKey("dbo.Jobs", "Appointments_AppointmentID", "dbo.Appointments", "AppointmentID");
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
            
            DropForeignKey("dbo.Jobs", "Appointments_AppointmentID", "dbo.Appointments");
            DropIndex("dbo.Jobs", new[] { "Appointments_AppointmentID" });
            DropColumn("dbo.Jobs", "Appointments_AppointmentID");
            CreateIndex("dbo.JobAppointments", "Appointment_AppointmentID");
            CreateIndex("dbo.JobAppointments", "Job_JobId");
            AddForeignKey("dbo.JobAppointments", "Appointment_AppointmentID", "dbo.Appointments", "AppointmentID", cascadeDelete: true);
            AddForeignKey("dbo.JobAppointments", "Job_JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
        }
    }
}
