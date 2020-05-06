namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpaymodetoreciepttale : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reciepts", "OrderedItemLink_OrderItemsId", "dbo.OrderedItems");
            DropIndex("dbo.Reciepts", new[] { "OrderedItemLink_OrderItemsId" });
            AddColumn("dbo.Reciepts", "PaymentMode", c => c.String());
            DropColumn("dbo.Reciepts", "OrderedItemLink_OrderItemsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reciepts", "OrderedItemLink_OrderItemsId", c => c.Int());
            DropColumn("dbo.Reciepts", "PaymentMode");
            CreateIndex("dbo.Reciepts", "OrderedItemLink_OrderItemsId");
            AddForeignKey("dbo.Reciepts", "OrderedItemLink_OrderItemsId", "dbo.OrderedItems", "OrderItemsId");
        }
    }
}
