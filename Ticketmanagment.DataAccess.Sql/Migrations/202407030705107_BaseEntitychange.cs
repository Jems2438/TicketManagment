namespace Ticketmanagment.DataAccess.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseEntitychange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "UpdatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Roles", "UpdatedId", c => c.String());
            AddColumn("dbo.Tickets", "UpdatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Tickets", "UpdatedId", c => c.String());
            AddColumn("dbo.Timesheets", "UpdatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Timesheets", "UpdatedId", c => c.String());
            AddColumn("dbo.Users", "UpdatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Users", "UpdatedId", c => c.String());
            AddColumn("dbo.UserRoles", "UpdatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.UserRoles", "UpdatedId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRoles", "UpdatedId");
            DropColumn("dbo.UserRoles", "UpdatedAt");
            DropColumn("dbo.Users", "UpdatedId");
            DropColumn("dbo.Users", "UpdatedAt");
            DropColumn("dbo.Timesheets", "UpdatedId");
            DropColumn("dbo.Timesheets", "UpdatedAt");
            DropColumn("dbo.Tickets", "UpdatedId");
            DropColumn("dbo.Tickets", "UpdatedAt");
            DropColumn("dbo.Roles", "UpdatedId");
            DropColumn("dbo.Roles", "UpdatedAt");
        }
    }
}
