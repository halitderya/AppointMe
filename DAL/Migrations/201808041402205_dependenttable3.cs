namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dependenttable3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppointmentJobs", "Appointment_AppointmentID", "dbo.Appointments");
            DropForeignKey("dbo.AppointmentJobs", "Job_JobId", "dbo.Jobs");
            DropIndex("dbo.AppointmentJobs", new[] { "Appointment_AppointmentID" });
            DropIndex("dbo.AppointmentJobs", new[] { "Job_JobId" });
            AddColumn("dbo.DependentJobs", "Job_JobId", c => c.Int());
            CreateIndex("dbo.Appointments", "JobRefId");
            CreateIndex("dbo.DependentJobs", "Job_JobId");
            AddForeignKey("dbo.DependentJobs", "Job_JobId", "dbo.Jobs", "JobId");
            AddForeignKey("dbo.Appointments", "JobRefId", "dbo.Jobs", "JobId", cascadeDelete: true);
            DropTable("dbo.AppointmentJobs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AppointmentJobs",
                c => new
                    {
                        Appointment_AppointmentID = c.Int(nullable: false),
                        Job_JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Appointment_AppointmentID, t.Job_JobId });
            
            DropForeignKey("dbo.Appointments", "JobRefId", "dbo.Jobs");
            DropForeignKey("dbo.DependentJobs", "Job_JobId", "dbo.Jobs");
            DropIndex("dbo.DependentJobs", new[] { "Job_JobId" });
            DropIndex("dbo.Appointments", new[] { "JobRefId" });
            DropColumn("dbo.DependentJobs", "Job_JobId");
            CreateIndex("dbo.AppointmentJobs", "Job_JobId");
            CreateIndex("dbo.AppointmentJobs", "Appointment_AppointmentID");
            AddForeignKey("dbo.AppointmentJobs", "Job_JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
            AddForeignKey("dbo.AppointmentJobs", "Appointment_AppointmentID", "dbo.Appointments", "AppointmentID", cascadeDelete: true);
        }
    }
}
