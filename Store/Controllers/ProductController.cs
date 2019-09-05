using Domain.Abstract;
using Domain.Entities;
using Store.Models;
using System.Linq;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository ProductRepository;

        public int pageSize = 5;

        public ProductController(IProductRepository rep)
        {
            ProductRepository = rep;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = ProductRepository.Products
                    .Where(x => category == null || x.Category.Description.ToLower() == category.ToLower())
                    .OrderBy(x => x.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = ProductRepository.Products.Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}