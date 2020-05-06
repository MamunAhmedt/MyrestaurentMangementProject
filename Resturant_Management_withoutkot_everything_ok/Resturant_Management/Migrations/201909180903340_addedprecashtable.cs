namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedprecashtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PreCashes",
                c => new
                    {
                        PreCashId = c.Int(nullable: false, identity: true),
                        PreCashAmount = c.Single(nullable: false),
                        TimeDate = c.String(),
                    })
                .PrimaryKey(t => t.PreCashId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PreCashes");
        }
    }
}
