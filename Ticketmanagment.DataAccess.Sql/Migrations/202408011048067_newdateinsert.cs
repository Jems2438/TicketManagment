namespace Ticketmanagment.DataAccess.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdateinsert : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CommonLookups", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.CommonLookups", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Roles", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Roles", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Tickets", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Tickets", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Timesheets", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Timesheets", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Users", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Users", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.UserRoles", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.UserRoles", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRoles", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserRoles", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Timesheets", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Timesheets", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CommonLookups", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CommonLookups", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
