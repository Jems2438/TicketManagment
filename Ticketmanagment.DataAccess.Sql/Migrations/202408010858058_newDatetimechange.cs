namespace Ticketmanagment.DataAccess.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDatetimechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CommonLookups", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CommonLookups", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Timesheets", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Timesheets", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserRoles", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserRoles", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRoles", "UpdatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.UserRoles", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Users", "UpdatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Users", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Timesheets", "UpdatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Timesheets", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Tickets", "UpdatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Tickets", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Roles", "UpdatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Roles", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.CommonLookups", "UpdatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.CommonLookups", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
