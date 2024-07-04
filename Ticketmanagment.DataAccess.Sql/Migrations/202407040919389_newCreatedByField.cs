namespace Ticketmanagment.DataAccess.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newCreatedByField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "CreatedBy", c => c.String());
            AddColumn("dbo.Timesheets", "CreatedBy", c => c.String());
            AddColumn("dbo.Users", "CreatedBy", c => c.String());
            AddColumn("dbo.UserRoles", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRoles", "CreatedBy");
            DropColumn("dbo.Users", "CreatedBy");
            DropColumn("dbo.Timesheets", "CreatedBy");
            DropColumn("dbo.Roles", "CreatedBy");
        }
    }
}
