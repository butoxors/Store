using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}