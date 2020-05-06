namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpaymentmethodaccountstable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentAccountsBallances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cash = c.String(),
                        Card = c.String(),
                        Bkash = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentAccountsBallances");
        }
    }
}
