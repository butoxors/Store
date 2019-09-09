using Domain.Abstract;
using Domain.Entities;
using Store.Concrete;
using Store.Models;
using System.Collections;
using System.Collections.Generic;
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

        public ActionResult Search(string query)
        {
            var products = unitOfWork.ProductRepository
                .Get(x => x.Name.ToLower() == query || x.Description.ToLower() == query || x.Category.Description.ToLower() == query);

            var result = new ProductListViewModel
            {
                Products = products,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = pageSize,
                    TotalItems = products.Count()
                }
            };

            ViewBag.Query = query;

            var errors = new List<string>();

            if (result.Products.Count() == 0)
            {
                errors.Add(string.Format($"Not finded product for {0} query", query));
                return View("Error", errors);
            }

            return View("List", result);
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