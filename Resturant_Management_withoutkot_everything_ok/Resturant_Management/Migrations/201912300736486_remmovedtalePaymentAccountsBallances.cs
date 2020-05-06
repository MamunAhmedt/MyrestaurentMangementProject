namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remmovedtalePaymentAccountsBallances : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.PaymentAccountsBallances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PaymentAccountsBallances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cash = c.String(),
                        Card = c.String(),
                        Bkash = c.String(),
                        Rocket = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
