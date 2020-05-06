namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveaddedRecieptTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderedItems", "Reciept_RecieptNo", "dbo.Reciepts");
            DropIndex("dbo.OrderedItems", new[] { "Reciept_RecieptNo" });
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
                        Reciept_RecieptNo = c.Int(),
                    })
                .PrimaryKey(t => t.OrderItemsId);
            
            CreateTable(
                "dbo.Reciepts",
                c => new
                    {
                        RecieptNo = c.Int(nullable: false, identity: true),
                        RecieptId = c.Int(nullable: false),
                        ServiceBoyid = c.Int(nullable: false),
                        TableNo = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DiscountRate = c.Int(nullable: false),
                        NetAmount = c.Single(nullable: false),
                        DateTime = c.String(),
                    })
                .PrimaryKey(t => t.RecieptNo);
            
            CreateIndex("dbo.OrderedItems", "Reciept_RecieptNo");
            AddForeignKey("dbo.OrderedItems", "Reciept_RecieptNo", "dbo.Reciepts", "RecieptNo");
        }
    }
}
