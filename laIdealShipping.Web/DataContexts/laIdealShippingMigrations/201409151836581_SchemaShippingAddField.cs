namespace laIdealShipping.Web.DataContexts.laIdealShippingMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchemaShippingAddField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippings", "salida", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shippings", "salida");
        }
    }
}
