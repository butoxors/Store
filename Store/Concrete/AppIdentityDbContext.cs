using Microsoft.AspNet.Identity.EntityFramework;
using Store.Models;
using System.Data.Entity;

namespace Store.Concrete
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("AppIdentityDbContext") { }

        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new AppIdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

}