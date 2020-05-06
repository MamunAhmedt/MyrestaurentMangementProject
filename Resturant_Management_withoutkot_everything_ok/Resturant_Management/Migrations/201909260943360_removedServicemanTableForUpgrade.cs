namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedServicemanTableForUpgrade : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ServiceMen");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServiceMen",
                c => new
                    {
                        ServiceManId = c.Int(nullable: false, identity: true),
                        ServiceManName = c.String(nullable: false),
                        ServiceAddress = c.String(nullable: false),
                        ServiceManCellPhoneNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceManId);
            
        }
    }
}
