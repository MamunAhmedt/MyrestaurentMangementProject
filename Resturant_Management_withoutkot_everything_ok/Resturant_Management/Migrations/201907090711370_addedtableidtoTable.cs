namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtableidtoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tables", "TableId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tables", "TableId");
        }
    }
}
