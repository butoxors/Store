using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; set; }
    }
}
