namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddiscountratetoitemtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "DiscountRateOnUnitPrice_DiscountOnUnitPrice", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "DiscountRateOnUnitPrice_DiscountOnGrandTotal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "DiscountRateOnUnitPrice_DiscountOnGrandTotal");
            DropColumn("dbo.Items", "DiscountRateOnUnitPrice_DiscountOnUnitPrice");
        }
    }
}
