namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtablestable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        TableId = c.Int(nullable: false, identity: true),
                        TableNo = c.String(),
                    })
                .PrimaryKey(t => t.TableId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tables");
        }
    }
}
