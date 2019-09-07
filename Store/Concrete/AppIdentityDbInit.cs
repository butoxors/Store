using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Infrastructure.Manager;
using Store.Models;
using System.Data.Entity;

namespace Store.Concrete
{
    public class AppIdentityDbInit : DropCreateDatabaseAlways<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            var userManager = new AppUserManager(new UserStore<AppUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new AppUser { Email = "admin@mail.com", UserName = "admin@mail.com" };

            string password = "admin123";

            var res = userManager.Create(admin, password);

            if (res.Succeeded)
                userManager.AddToRole(admin.Id, role1.Name);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}