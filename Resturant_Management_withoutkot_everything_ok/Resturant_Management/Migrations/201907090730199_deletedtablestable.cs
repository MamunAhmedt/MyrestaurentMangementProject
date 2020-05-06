namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedtablestable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Tables");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        TableId = c.Int(nullable: false, identity: true),
                        TableNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TableId);
            
        }
    }
}
