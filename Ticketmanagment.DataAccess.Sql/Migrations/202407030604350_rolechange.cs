namespace Ticketmanagment.DataAccess.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolechange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Name", c => c.String());
            AddColumn("dbo.Roles", "Code", c => c.String());
            DropColumn("dbo.Roles", "RoleName");
            DropColumn("dbo.Roles", "RoleCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "RoleCode", c => c.String());
            AddColumn("dbo.Roles", "RoleName", c => c.String());
            DropColumn("dbo.Roles", "Code");
            DropColumn("dbo.Roles", "Name");
        }
    }
}
