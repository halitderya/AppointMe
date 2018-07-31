namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Operators", "Resource_ResourceID", "dbo.Resources");
            DropIndex("dbo.Operators", new[] { "Resource_ResourceID" });
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
                        IsActive = c.Boolean(),
                        Customers_CustomerID = c.Int(),
                        Resource_ResourceID = c.Int(),
                        Job_JobId = c.Int(),
                    })
                .PrimaryKey(t => t.AppointmentID)
                .ForeignKey("dbo.Customers", t => t.Customers_CustomerID)
                .ForeignKey("dbo.Resources", t => t.Resource_ResourceID)
                .ForeignKey("dbo.Jobs", t => t.Job_JobId)
                .Index(t => t.Customers_CustomerID)
                .Index(t => t.Resource_ResourceID)
                .Index(t => t.Job_JobId);
            
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
                        IsActive = c.Boolean(),
                        Resource_ResourceID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Resources", t => t.Resource_ResourceID)
                .Index(t => t.Resource_ResourceID);
            
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
            
            AddColumn("dbo.Resources", "EMail", c => c.String());
            AddColumn("dbo.Resources", "Password", c => c.String());
            AddColumn("dbo.Resources", "Role", c => c.Short(nullable: false));
            AddColumn("dbo.Resources", "NIN", c => c.String());
            AddColumn("dbo.Resources", "BankAccount", c => c.String());
            DropColumn("dbo.Resources", "ResourceType");
            DropTable("dbo.Operators");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        OperatorID = c.Int(nullable: false, identity: true),
                        OperatorUserName = c.String(),
                        OperatorPassword = c.String(),
                        OperatorRole = c.Int(nullable: false),
                        Resource_ResourceID = c.Int(),
                    })
                .PrimaryKey(t => t.OperatorID);
            
            AddColumn("dbo.Resources", "ResourceType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Appointments", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.TaskJobs", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.TaskJobs", "Task_TaskID", "dbo.Tasks");
            DropForeignKey("dbo.Customers", "Resource_ResourceID", "dbo.Resources");
            DropForeignKey("dbo.Appointments", "Resource_ResourceID", "dbo.Resources");
            DropForeignKey("dbo.Appointments", "Customers_CustomerID", "dbo.Customers");
            DropIndex("dbo.TaskJobs", new[] { "Job_JobId" });
            DropIndex("dbo.TaskJobs", new[] { "Task_TaskID" });
            DropIndex("dbo.Customers", new[] { "Resource_ResourceID" });
            DropIndex("dbo.Appointments", new[] { "Job_JobId" });
            DropIndex("dbo.Appointments", new[] { "Resource_ResourceID" });
            DropIndex("dbo.Appointments", new[] { "Customers_CustomerID" });
            DropColumn("dbo.Resources", "BankAccount");
            DropColumn("dbo.Resources", "NIN");
            DropColumn("dbo.Resources", "Role");
            DropColumn("dbo.Resources", "Password");
            DropColumn("dbo.Resources", "EMail");
            DropTable("dbo.TaskJobs");
            DropTable("dbo.Tasks");
            DropTable("dbo.Jobs");
            DropTable("dbo.Customers");
            DropTable("dbo.Appointments");
            CreateIndex("dbo.Operators", "Resource_ResourceID");
            AddForeignKey("dbo.Operators", "Resource_ResourceID", "dbo.Resources", "ResourceID");
        }
    }
}
