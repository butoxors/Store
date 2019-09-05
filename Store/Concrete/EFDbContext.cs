using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Store.Concrete
{
    public class EFDbContext : DbContext
    {
        static EFDbContext()
        {
            Database.SetInitializer<EFDbContext>(new EFDbContextInitializer());
        }

        public EFDbContext() : base("EFDbContext")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}