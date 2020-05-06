namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedrecieptasdatetimnamematchedwithtype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderedItems", "Reciept_RecieptId", "dbo.Reciepts");
            DropIndex("dbo.OrderedItems", new[] { "Reciept_RecieptId" });
            DropTable("dbo.Reciepts");
            DropTable("dbo.OrderedItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderedItems",
                c => new
                    {
                        OrderItemsId = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        DiscountRate = c.Int(nullable: false),
                        Reciept_RecieptId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderItemsId);
            
            CreateTable(
                "dbo.Reciepts",
                c => new
                    {
                        RecieptId = c.Int(nullable: false, identity: true),
                        RecieptNo = c.Int(nullable: false),
                        ServiceBoyid = c.Int(nullable: false),
                        TableNo = c.Int(nullable: false),
                        NetAmount = c.Single(nullable: false),
                        DateTime = c.String(),
                    })
                .PrimaryKey(t => t.RecieptId);
            
            CreateIndex("dbo.OrderedItems", "Reciept_RecieptId");
            AddForeignKey("dbo.OrderedItems", "Reciept_RecieptId", "dbo.Reciepts", "RecieptId");
        }
    }
}
