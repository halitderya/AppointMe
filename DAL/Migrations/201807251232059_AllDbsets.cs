namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllDbsets : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Operators", "CreateDate");
            DropColumn("dbo.Operators", "UpdateDate");
            DropColumn("dbo.Operators", "DeleteDate");
            DropColumn("dbo.Operators", "IsActive");
            DropColumn("dbo.Resources", "CreateDate");
            DropColumn("dbo.Resources", "UpdateDate");
            DropColumn("dbo.Resources", "DeleteDate");
            DropColumn("dbo.Resources", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resources", "IsActive", c => c.Boolean());
            AddColumn("dbo.Resources", "DeleteDate", c => c.DateTime());
            AddColumn("dbo.Resources", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Resources", "CreateDate", c => c.DateTime());
            AddColumn("dbo.Operators", "IsActive", c => c.Boolean());
            AddColumn("dbo.Operators", "DeleteDate", c => c.DateTime());
            AddColumn("dbo.Operators", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Operators", "CreateDate", c => c.DateTime());
        }
    }
}
