namespace laIdealShipping.Web.DataContexts.laIdealShippingMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShippingsViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "laideal.ShippingViewModels",
                c => new
                    {
                        VM_Id = c.Int(nullable: false, identity: true),
                        VM_nextShippingDate = c.String(),
                        VM_salida = c.Boolean(nullable: false),
                        VM_Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VM_Id);
            
        }
        
        public override void Down()
        {
            DropTable("laideal.ShippingViewModels");
        }
    }
}
