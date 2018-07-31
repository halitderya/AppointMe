namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baseentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentID = c.Int(nullable: false, identity: true),
                        AppointmentStatus = c.Short(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ChargedAmount = c.Double(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                        Customers_CustomerID = c.Int(),
                        Resource_ResourceID = c.Int(),
                        Job_JobId = c.Int(),
                        Operator_ResourceID = c.Int(),
                        Resources_ResourceID = c.Int(),
                    })
                .PrimaryKey(t => t.AppointmentID)
                .ForeignKey("dbo.Customers", t => t.Customers_CustomerID)
                .ForeignKey("dbo.Resources", t => t.Resource_ResourceID)
                .ForeignKey("dbo.Jobs", t => t.Job_JobId)
                .ForeignKey("dbo.Resources", t => t.Operator_ResourceID)
                .ForeignKey("dbo.Resources", t => t.Resources_ResourceID)
                .Index(t => t.Customers_CustomerID)
                .Index(t => t.Resource_ResourceID)
                .Index(t => t.Job_JobId)
                .Index(t => t.Operator_ResourceID)
                .Index(t => t.Resources_ResourceID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerTitle = c.String(),
                        CustomerName = c.String(),
                        CustomerSurname = c.String(),
                        CustomerEmail = c.String(),
                        CustomerPhone = c.String(),
                        CustomerAddress = c.String(),
                        CustomerPostCode = c.String(),
                        CustomerCity = c.String(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                        Operator_ResourceID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Resources", t => t.Operator_ResourceID)
                .Index(t => t.Operator_ResourceID);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceID = c.Int(nullable: false, identity: true),
                        ResourceName = c.String(),
                        ResourceSurname = c.String(),
                        ResourceStartDate = c.DateTime(nullable: false),
                        ResourcePhone = c.String(),
                        ResourceEmerphone = c.String(),
                        EMail = c.String(),
                        ResourceAddress = c.String(),
                        ResourcePostcode = c.String(),
                        ResourceCity = c.String(),
                        Password = c.String(),
                        Role = c.Short(nullable: false),
                        NIN = c.String(),
                        BankAccount = c.String(),
                    })
                .PrimaryKey(t => t.ResourceID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                        JobDescription = c.String(),
                        JobPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        TaskDescription = c.String(),
                        TaskTimeSpan = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.TaskID);
            
            CreateTable(
                "dbo.TaskJobs",
                c => new
                    {
                        Task_TaskID = c.Int(nullable: false),
                        Job_JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_TaskID, t.Job_JobId })
                .ForeignKey("dbo.Tasks", t => t.Task_TaskID, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.Job_JobId, cascadeDelete: true)
                .Index(t => t.Task_TaskID)
                .Index(t => t.Job_JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Resources_ResourceID", "dbo.Resources");
            DropForeignKey("dbo.Appointments", "Operator_ResourceID", "dbo.Resources");
            DropForeignKey("dbo.Appointments", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.TaskJobs", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.TaskJobs", "Task_TaskID", "dbo.Tasks");
            DropForeignKey("dbo.Customers", "Operator_ResourceID", "dbo.Resources");
            DropForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources");
            DropForeignKey("dbo.Appointments", "Customers_CustomerID", "dbo.Customers");
            DropIndex("dbo.TaskJobs", new[] { "Job_JobId" });
            DropIndex("dbo.TaskJobs", new[] { "Task_TaskID" });
            DropIndex("dbo.Customers", new[] { "Operator_ResourceID" });
            DropIndex("dbo.Appointments", new[] { "Resources_ResourceID" });
            DropIndex("dbo.Appointments", new[] { "Operator_ResourceID" });
            DropIndex("dbo.Appointments", new[] { "Job_JobId" });
            DropIndex("dbo.Appointments", new[] { "Resource_ResourceID" });
            DropIndex("dbo.Appointments", new[] { "Customers_CustomerID" });
            DropTable("dbo.TaskJobs");
            DropTable("dbo.Tasks");
            DropTable("dbo.Jobs");
            DropTable("dbo.Resources");
            DropTable("dbo.Customers");
            DropTable("dbo.Appointments");
        }
    }
}
