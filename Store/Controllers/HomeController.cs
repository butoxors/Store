using Domain.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

    }
}