namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPurchasetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.String(),
                        Name = c.String(),
                        Category = c.String(),
                        Quantity = c.Int(nullable: false),
                        Units = c.String(),
                        UnitPrice = c.Single(nullable: false),
                        NetAmount = c.Single(nullable: false),
                        GrandTotal = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Purchases");
        }
    }
}
