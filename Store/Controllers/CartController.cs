using Domain.Entities;
using Store.Concrete;
using Store.Models;
using System.Linq;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class CartController : Controller
    {
        private UnitOfWork unitOfWork;

        public CartController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int Id, string returnUrl)
        {
            Product product = unitOfWork.ProductRepository.Get(Id);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveItem(Cart cart, int Id, string returnUrl)
        {
            Product product = unitOfWork.ProductRepository.Get(Id);

            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int Id, string returnUrl)
        {
            Product product = unitOfWork.ProductRepository.Get(Id);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [Authorize]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            return View(new ShippingDetails());
        }
    }
}