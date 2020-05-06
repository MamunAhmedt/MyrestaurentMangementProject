namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedservicemantableafterfirstupdate3 : DbMigration
    {
        public override void Up()
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
                        Designation = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceManId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceMen");
        }
    }
}
