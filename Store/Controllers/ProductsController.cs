using Domain.Abstract;
using Domain.Entities;
using Store.Models;
using System.Linq;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository ProductRepository;

        public int pageSize = 5;

        public ProductsController(IProductRepository rep)
        {
            ProductRepository = rep;
        }

        public ViewResult List(int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = ProductRepository.Products
                    .OrderBy(x => x.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = ProductRepository.Products.Count()
                }
            };

            return View(model);
        }
    }
}