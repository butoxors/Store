using Domain.Concrete;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Infrastructure.Manager;
using Store.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Store.Concrete
{
    public class AppIdentityDbInit : CreateDatabaseIfNotExists<AppIdentityDbContext>
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

            List<Category> Categories = new List<Category>()
            {
                new Category{Description = "Instruments", Products = new List<Product>
                    {
                        new Product{Name = "Hammer", Description = "Just hammer", Price = 100},
                        new Product{Name = "Knife", Description = "Sharp knife", Price = 100},
                        new Product{Name = "Staircase", Description = "Long stairscase", Price = 100}
                    }
                },
                new Category{Description = "Food", Products = new List<Product>
                    {
                        new Product{Name = "Cucumber", Description = "Green cucumber", Price = 100},
                        new Product{Name = "Potato", Description = "Brown potato", Price = 100},
                        new Product{Name = "Tomato", Description = "Red tomato", Price = 100},
                        new Product{Name = "Cabbage", Description = "Violet cabbage", Price = 100},
                        new Product{Name = "Carrot", Description = "Orange carrot", Price = 100},
                    }
                },
                new Category{Description = "Clothes", Products = new List<Product>
                    {
                        new Product{Name = "Tie", Description = "Tie", Price = 100},
                        new Product{Name = "Jacket", Description = "Jacket", Price = 100},
                        new Product{Name = "T-shirt", Description = "T-shirt", Price = 100},
                        new Product{Name = "Jeans", Description = "Jeans", Price = 100},
                        new Product{Name = "Shoes", Description = "Shoes", Price = 100},
                    }
                }
            };

            foreach (var c in Categories)
                context.Categories.Add(c);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}