namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRecieptTable : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.OrderedItems",
                c => new
                    {
                        OrderItemsId = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Reciept_RecieptNo = c.Int(),
                    })
                .PrimaryKey(t => t.OrderItemsId)
                .ForeignKey("dbo.Reciepts", t => t.Reciept_RecieptNo)
                .Index(t => t.Reciept_RecieptNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedItems", "Reciept_RecieptNo", "dbo.Reciepts");
            DropIndex("dbo.OrderedItems", new[] { "Reciept_RecieptNo" });
            DropTable("dbo.OrderedItems");
            DropTable("dbo.Reciepts");
        }
    }
}
