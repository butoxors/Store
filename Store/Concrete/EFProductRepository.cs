using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;

namespace Store.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        EFDbContext Context = new EFDbContext();

        public IEnumerable<Product> Products => Context.Products;

    }
}