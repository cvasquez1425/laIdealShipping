using laIdealShipping.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace laIdealShipping.Web.DataContexts
{
    /// <summary>
    /// represents my Gateway to the database to query anything shipping related.
    /// </summary>
    public class laIdealShippingsDb : DbContext         
    {
        public laIdealShippingsDb()
            : base("DefaultConnection")
        {
            //Database.Log = sql => Debug.Write(sql);                 // I am doing this in the constructor so every instance of DbContext will be logging something.
        }

        /// <summary>
        /// DB SQL Server Schema changes from dbo to laideal
        /// in this version EF I am telling the ModelBuilder that everything in this DbContext has a default schema. That default schema, it is going to be the laideal schema.
        /// </summary>
        /// <param name="modelBuilder"></param>
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("laidealshipping");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Shipping>  Shippings                   { get; set; }      // DbSet will map to a table that is why ORM object-relational mapper.
        public DbSet<Contact>   Contacts                    { get; set; }
    }
}