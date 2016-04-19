namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveExtraFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meetings", "InstructorId", "dbo.AspNetUsers");
            DropIndex("dbo.Meetings", new[] { "InstructorId" });
            AlterColumn("dbo.Meetings", "InstructorId", c => c.String());
            DropColumn("dbo.Meetings", "End");
            DropColumn("dbo.Meetings", "IsAllDay");
            DropColumn("dbo.Meetings", "RecurrenceException");
            DropColumn("dbo.Meetings", "RecurrenceId");
            DropColumn("dbo.Meetings", "RecurrenceRule");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meetings", "RecurrenceRule", c => c.String(maxLength: 255));
            AddColumn("dbo.Meetings", "RecurrenceId", c => c.Int());
            AddColumn("dbo.Meetings", "RecurrenceException", c => c.String(maxLength: 255));
            AddColumn("dbo.Meetings", "IsAllDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.Meetings", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Meetings", "InstructorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Meetings", "InstructorId");
            AddForeignKey("dbo.Meetings", "InstructorId", "dbo.AspNetUsers", "Id");
        }
    }
}
