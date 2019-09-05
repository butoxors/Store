using Domain.Abstract;
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
        private ICategoryRepository Repository;

        public CatalogController(ICategoryRepository rep)
        {
            Repository = rep;
        }

        public ViewResult List()
        {
            CategoryListViewModel model = new CategoryListViewModel
            {
                Categories = Repository.Categories
                    .OrderBy(x => x.Id)
                    .Distinct()
            };


            return View(model);
        }
    }
}