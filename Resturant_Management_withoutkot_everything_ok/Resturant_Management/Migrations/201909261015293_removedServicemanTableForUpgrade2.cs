namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedServicemanTableForUpgrade2 : DbMigration
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
                        Salary = c.Int(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        Designation = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ServiceManId);
            
        }
    }
}
