namespace Ticketmanagment.DataAccess.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommonLookup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommonLookups",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LookupName = c.String(),
                        LookupKey = c.String(),
                        LookupValue = c.String(),
                        OrderNumber = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedBy = c.String(),
                        UpdatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedId = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CommonLookups");
        }
    }
}
