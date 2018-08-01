namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class task_removed2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "JobRefId", "dbo.Jobs");
            DropIndex("dbo.Appointments", new[] { "JobRefId" });
            CreateTable(
                "dbo.AppointmentJobs",
                c => new
                    {
                        Appointment_AppointmentID = c.Int(nullable: false),
                        Job_JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Appointment_AppointmentID, t.Job_JobId })
                .ForeignKey("dbo.Appointments", t => t.Appointment_AppointmentID, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.Job_JobId, cascadeDelete: true)
                .Index(t => t.Appointment_AppointmentID)
                .Index(t => t.Job_JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentJobs", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.AppointmentJobs", "Appointment_AppointmentID", "dbo.Appointments");
            DropIndex("dbo.AppointmentJobs", new[] { "Job_JobId" });
            DropIndex("dbo.AppointmentJobs", new[] { "Appointment_AppointmentID" });
            DropTable("dbo.AppointmentJobs");
            CreateIndex("dbo.Appointments", "JobRefId");
            AddForeignKey("dbo.Appointments", "JobRefId", "dbo.Jobs", "JobId", cascadeDelete: true);
        }
    }
}
