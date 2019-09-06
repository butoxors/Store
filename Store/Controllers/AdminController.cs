using Microsoft.AspNet.Identity.Owin;
using Store.Infrastructure;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}