namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedreciept : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reciepts",
                c => new
                    {
                        RecieptId = c.Int(nullable: false, identity: true),
                        RecieptNo = c.Int(nullable: false),
                        ServiceBoyid = c.Int(nullable: false),
                        TableNo = c.Int(nullable: false),
                        NetAmount = c.Single(nullable: false),
                        TimeDate = c.String(),
                    })
                .PrimaryKey(t => t.RecieptId);
            
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
                .PrimaryKey(t => t.OrderItemsId)
                .ForeignKey("dbo.Reciepts", t => t.Reciept_RecieptId)
                .Index(t => t.Reciept_RecieptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedItems", "Reciept_RecieptId", "dbo.Reciepts");
            DropIndex("dbo.OrderedItems", new[] { "Reciept_RecieptId" });
            DropTable("dbo.OrderedItems");
            DropTable("dbo.Reciepts");
        }
    }
}
