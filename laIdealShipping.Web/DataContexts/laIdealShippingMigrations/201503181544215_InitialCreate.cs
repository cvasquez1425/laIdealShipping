namespace laIdealShipping.Web.DataContexts.laIdealShippingMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "laideal.Contacts",
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
                "laideal.Shippings",
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
            DropTable("laideal.Shippings");
            DropTable("laideal.Contacts");
        }
    }
}
