namespace laIdealShipping.Web.DataContexts.laIdealShippingMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingContactInfoAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "firstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "lastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "comments", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "comments", c => c.String());
            AlterColumn("dbo.Contacts", "lastName", c => c.String());
            AlterColumn("dbo.Contacts", "firstName", c => c.String());
        }
    }
}
