using Domain.Abstract;
using Store.Concrete;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class CatalogController : Controller
    {
        private UnitOfWork unitOfWork;

        public CatalogController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ViewResult List()
        {
            CategoryListViewModel model = new CategoryListViewModel
            {
                Categories = unitOfWork.CategoryRepository.Get(null, x => x.OrderBy(o => o.Id)).Distinct()
            };

            return View(model);
        }
    }
}