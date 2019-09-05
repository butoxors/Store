using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Concrete
{
    public class EFCategoryRepository : ICategoryRepository
    {
        EFDbContext Context = new EFDbContext();

        public IEnumerable<Category> Categories => Context.Categories;
    }
}