namespace laIdealShipping.Web.DataContexts.laIdealShippingMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingContactInfoAttributes3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "phone", c => c.Int(nullable: false));
        }
    }
}
