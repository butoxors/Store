using Domain.Entities;
using System.Collections.Generic;

namespace Store.Models
{
    public class ProductListViewModel
    {
        IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}