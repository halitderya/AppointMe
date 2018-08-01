namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class task_removed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskJobs", "Task_TaskID", "dbo.Tasks");
            DropForeignKey("dbo.TaskJobs", "Job_JobId", "dbo.Jobs");
            DropIndex("dbo.TaskJobs", new[] { "Task_TaskID" });
            DropIndex("dbo.TaskJobs", new[] { "Job_JobId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.TaskJobs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TaskJobs",
                c => new
                    {
                        Task_TaskID = c.Int(nullable: false),
                        Job_JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_TaskID, t.Job_JobId });
            
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
            
            CreateIndex("dbo.TaskJobs", "Job_JobId");
            CreateIndex("dbo.TaskJobs", "Task_TaskID");
            AddForeignKey("dbo.TaskJobs", "Job_JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
            AddForeignKey("dbo.TaskJobs", "Task_TaskID", "dbo.Tasks", "TaskID", cascadeDelete: true);
        }
    }
}
