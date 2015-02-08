namespace laIdealShipping.Web.DataContexts.laIdealShippingMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Books", newSchema: "laideal");
            MoveTable(name: "dbo.Contacts", newSchema: "laideal");
            MoveTable(name: "dbo.Shippings", newSchema: "laideal");
        }
        
        public override void Down()
        {
            MoveTable(name: "laideal.Shippings", newSchema: "dbo");
            MoveTable(name: "laideal.Contacts", newSchema: "dbo");
            MoveTable(name: "laideal.Books", newSchema: "dbo");
        }
    }
}
