namespace laIdealShipping.Web.DataContexts.laIdealShippingMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateGoDaddy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "laidealshipping.Contacts",
                c => new
                    {
                        contactId = c.Int(nullable: false, identity: true),
                        firstName = c.String(maxLength: 50, unicode: false),
                        lastName = c.String(maxLength: 50, unicode: false),
                        phone = c.String(),
                        email = c.String(),
                        comments = c.String(maxLength: 500, unicode: false),
                        emailMeUpdate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.contactId);
            
            CreateTable(
                "laidealshipping.Shippings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nextShippingDate = c.DateTime(nullable: false),
                        salida = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("laidealshipping.Shippings");
            DropTable("laidealshipping.Contacts");
        }
    }
}
