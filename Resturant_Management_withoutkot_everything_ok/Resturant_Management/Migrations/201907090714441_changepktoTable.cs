namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepktoTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tables");
            AlterColumn("dbo.Tables", "TableNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Tables", "TableId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tables", "TableId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Tables");
            AlterColumn("dbo.Tables", "TableId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tables", "TableNo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tables", "TableNo");
        }
    }
}
