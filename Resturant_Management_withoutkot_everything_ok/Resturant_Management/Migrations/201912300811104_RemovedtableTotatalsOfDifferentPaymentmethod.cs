
    using System;
    using System.Data.Entity.Migrations;

    namespace Resturant_Management.Migrations
    {
    public partial class RemovedtableTotatalsOfDifferentPaymentmethod : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TotatalsOfDifferentPaymentmethods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TotatalsOfDifferentPaymentmethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayModeName = c.String(),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
