using Domain.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class JsonController : Controller
    {
        private IProductRepository ProductRepository;

        public JsonController(IProductRepository rep)
        {
            ProductRepository = rep;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetJsonData()
        {
            string model = JsonConvert.SerializeObject(ProductRepository.Products);

            return View(model);
        }
    }
}