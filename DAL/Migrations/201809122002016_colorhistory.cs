namespace ICPartners.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colorhistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Color1Brand", c => c.String());
            AddColumn("dbo.Appointments", "Color1Code", c => c.String());
            AddColumn("dbo.Appointments", "Color1Quantity", c => c.String());
            AddColumn("dbo.Appointments", "Color1Activator", c => c.String());
            AddColumn("dbo.Appointments", "Color2Brand", c => c.String());
            AddColumn("dbo.Appointments", "Color2Code", c => c.String());
            AddColumn("dbo.Appointments", "Color2Quantity", c => c.String());
            AddColumn("dbo.Appointments", "Color2Activator", c => c.String());
            AddColumn("dbo.Appointments", "Color3Brand", c => c.String());
            AddColumn("dbo.Appointments", "Color3Code", c => c.String());
            AddColumn("dbo.Appointments", "Color3Quantity", c => c.String());
            AddColumn("dbo.Appointments", "Color3Activator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Color3Activator");
            DropColumn("dbo.Appointments", "Color3Quantity");
            DropColumn("dbo.Appointments", "Color3Code");
            DropColumn("dbo.Appointments", "Color3Brand");
            DropColumn("dbo.Appointments", "Color2Activator");
            DropColumn("dbo.Appointments", "Color2Quantity");
            DropColumn("dbo.Appointments", "Color2Code");
            DropColumn("dbo.Appointments", "Color2Brand");
            DropColumn("dbo.Appointments", "Color1Activator");
            DropColumn("dbo.Appointments", "Color1Quantity");
            DropColumn("dbo.Appointments", "Color1Code");
            DropColumn("dbo.Appointments", "Color1Brand");
        }
    }
}
