using Domain.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository Repository;

        public ProductsController(IProductRepository rep)
        {
            Repository = rep;
        }

        public ViewResult List()
        {
            return View(Repository.Products);
        }
    }
}