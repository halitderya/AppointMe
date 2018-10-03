namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jobapphopefinal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Appointments_AppointmentID", "dbo.Appointments");
            DropIndex("dbo.Jobs", new[] { "Appointments_AppointmentID" });
            CreateTable(
                "dbo.JobAppointments",
                c => new
                    {
                        Job_JobId = c.Int(nullable: false),
                        Appointment_AppointmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_JobId, t.Appointment_AppointmentID })
                .ForeignKey("dbo.Jobs", t => t.Job_JobId, cascadeDelete: true)
                .ForeignKey("dbo.Appointments", t => t.Appointment_AppointmentID, cascadeDelete: true)
                .Index(t => t.Job_JobId)
                .Index(t => t.Appointment_AppointmentID);
            
            DropColumn("dbo.Jobs", "Appointments_AppointmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Appointments_AppointmentID", c => c.Int());
            DropForeignKey("dbo.JobAppointments", "Appointment_AppointmentID", "dbo.Appointments");
            DropForeignKey("dbo.JobAppointments", "Job_JobId", "dbo.Jobs");
            DropIndex("dbo.JobAppointments", new[] { "Appointment_AppointmentID" });
            DropIndex("dbo.JobAppointments", new[] { "Job_JobId" });
            DropTable("dbo.JobAppointments");
            CreateIndex("dbo.Jobs", "Appointments_AppointmentID");
            AddForeignKey("dbo.Jobs", "Appointments_AppointmentID", "dbo.Appointments", "AppointmentID");
        }
    }
}
