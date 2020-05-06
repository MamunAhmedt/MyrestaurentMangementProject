namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedholdingtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HoldingTables",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        holdingReciept = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HoldingTables");
        }
    }
}
