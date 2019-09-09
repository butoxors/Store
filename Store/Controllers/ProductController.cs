using Domain.Abstract;
using Domain.Entities;
using Store.Concrete;
using Store.Models;
using System.Linq;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private UnitOfWork unitOfWork;
        public int pageSize = 4;

        public ProductController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = unitOfWork.ProductRepository.Get(x => category == null || x.Category.Description.ToLower() == category.ToLower())
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                    unitOfWork.ProductRepository.Get().Count() :
                    unitOfWork.ProductRepository.Get(x => x.Category.Description == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}