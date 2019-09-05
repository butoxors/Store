using Domain.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository Repository;

        public int pageSize = 5;

        public ProductsController(IProductRepository rep)
        {
            Repository = rep;
        }

        public ViewResult List(int page = 1)
        {
            return View(Repository.Products.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize));
        }
    }
}