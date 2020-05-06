namespace Resturant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedidoftoalpaymodetoINT : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TotatalsOfDifferentPaymentmethods");
            AlterColumn("dbo.TotatalsOfDifferentPaymentmethods", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TotatalsOfDifferentPaymentmethods", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TotatalsOfDifferentPaymentmethods");
            AlterColumn("dbo.TotatalsOfDifferentPaymentmethods", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.TotatalsOfDifferentPaymentmethods", "Id");
        }
    }
}
