namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedsaveOrder : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.SaveOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SaveOrders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderNo = c.Int(nullable: false),
                        Datetime = c.String(),
                        ServiceManName = c.String(),
                        TableNo = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
    }
}
