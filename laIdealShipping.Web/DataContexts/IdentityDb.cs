using laIdealShipping.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace laIdealShipping.Web.DataContexts
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>      // user password loging roles all that stuff goes into IdentityDbContext
    {
        public IdentityDb()                     // database context to actually talk to SQL Server. I am using the same connection string for both, so I'll two data contexts, but they'll talk to the database through the same db connection.
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("identity");
            base.OnModelCreating(modelBuilder);
        }

    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}