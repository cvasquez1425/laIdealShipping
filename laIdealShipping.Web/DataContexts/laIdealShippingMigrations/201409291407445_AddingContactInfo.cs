namespace laIdealShipping.Web.DataContexts.laIdealShippingMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingContactInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        contactId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        phone = c.Int(nullable: false),
                        email = c.String(),
                        comments = c.String(),
                        emailMeUpdate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.contactId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
