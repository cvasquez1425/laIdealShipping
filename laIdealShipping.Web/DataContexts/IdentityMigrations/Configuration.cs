namespace laIdealShipping.Web.DataContexts.IdentityMigrations
{
    using laIdealShipping.Web.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<laIdealShipping.Web.DataContexts.IdentityDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\IdentityMigrations";
        }

        protected override void Seed(laIdealShipping.Web.DataContexts.IdentityDb context)
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

            // Traditional Entity Framework Approach to seed the database
            //var hasher = new PasswordHasher();
            //context.Users.AddOrUpdate(u => u.Email,
            //            new ApplicationUser { Email = "nnewton@hotmail.com", PasswordHash = hasher.HashPassword("Password1") }
            //            );

            // Another approach to seed the database with users
            if (!context.Users.Any(u => u.UserName == "nnewton@hotmail.com"))
            {
                //for roles
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "nnewton@hotmail.com", Email = "nnewton@hotmail.com" };

                manager.Create(user, "Password1");

                //roles
                roleManager.Create(new IdentityRole { Name = "admin" });
                manager.AddToRole(user.Id, "admin");
            }

        }
    }
}
