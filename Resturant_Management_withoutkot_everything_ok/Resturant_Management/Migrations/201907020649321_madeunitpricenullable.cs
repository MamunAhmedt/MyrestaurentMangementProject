namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeunitpricenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "ItemUnitPrice", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "ItemUnitPrice", c => c.Int(nullable: false));
        }
    }
}
