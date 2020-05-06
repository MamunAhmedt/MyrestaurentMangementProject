namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedrecieptModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reciepts", "OrderedItemLink_OrderItemsId", c => c.Int());
            CreateIndex("dbo.Reciepts", "OrderedItemLink_OrderItemsId");
            AddForeignKey("dbo.Reciepts", "OrderedItemLink_OrderItemsId", "dbo.OrderedItems", "OrderItemsId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reciepts", "OrderedItemLink_OrderItemsId", "dbo.OrderedItems");
            DropIndex("dbo.Reciepts", new[] { "OrderedItemLink_OrderItemsId" });
            DropColumn("dbo.Reciepts", "OrderedItemLink_OrderItemsId");
        }
    }
}
