namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrocket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentAccountsBallances", "Rocket", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaymentAccountsBallances", "Rocket");
        }
    }
}
