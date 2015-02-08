namespace laIdealShipping.Web.DataContexts.laIdealShippingMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class laIdealShippingDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippings", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shippings", "Status");
        }
    }
}
