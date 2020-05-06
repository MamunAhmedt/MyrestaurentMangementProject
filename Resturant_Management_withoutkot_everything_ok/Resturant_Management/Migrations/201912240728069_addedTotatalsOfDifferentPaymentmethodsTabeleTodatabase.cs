namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTotatalsOfDifferentPaymentmethodsTabeleTodatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TotatalsOfDifferentPaymentmethods",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PayModeName = c.String(),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TotatalsOfDifferentPaymentmethods");
        }
    }
}
