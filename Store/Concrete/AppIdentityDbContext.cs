using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Concrete;
using Store.Models;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<AppIdentityDbContext>(new AppIdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}