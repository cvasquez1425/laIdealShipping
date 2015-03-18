namespace laIdealShipping.Web.DataContexts.laIdealShippingMigrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using laIdealShipping.Web.DataContexts;
    using laIdealShipping.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<laIdealShipping.Web.DataContexts.laIdealShippingsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\laIdealShippingMigrations";
        }

        protected override void Seed(laIdealShipping.Web.DataContexts.laIdealShippingsDb context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Shippings.AddOrUpdate(s => s.nextShippingDate,
                                     new Shipping { Id = 1, nextShippingDate = System.DateTime.Now, salida = true, Status = ShippingStatus.Active });
        }
    }
}
