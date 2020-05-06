namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_serviceman_bill_tableNotodatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillID = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BillID);
            
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
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        TableNo = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TableNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tables");
            DropTable("dbo.ServiceMen");
            DropTable("dbo.Bills");
        }
    }
}
