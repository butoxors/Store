using Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Store.Concrete
{
    public class EFDbContextInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
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

            foreach(var c in Categories)
                context.Categories.Add(c);

            context.SaveChanges();
        }
    }
}