namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedexpensetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProductName = c.String(),
                        Quantity = c.Single(nullable: false),
                        Units = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        NetAmount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Expenses");
        }
    }
}
