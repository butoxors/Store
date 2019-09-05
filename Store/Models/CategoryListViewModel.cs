using Domain.Entities;
using System.Collections.Generic;

namespace Store.Models
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}