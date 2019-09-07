using Domain.Abstract;
using Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Store.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class JsonController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public JsonController()
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetJsonData()
        {
            string model = JsonConvert.SerializeObject(unitOfWork.CategoryRepository.Get(), Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling  = ReferenceLoopHandling.Ignore
            });

            return Content(model);
        }
    }
}