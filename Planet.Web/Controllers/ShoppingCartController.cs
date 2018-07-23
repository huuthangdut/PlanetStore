using AutoMapper;
using Planet.Data.Core;
using Planet.Services.Core;
using Planet.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Planet.Web.Models.Shopping;

namespace Planet.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartController(ICartService cartService, IUnitOfWork unitOfWork)
        {
            _cartService = cartService;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = Mapper.Map<IEnumerable<CartItemViewModel>>(_cartService.GetCartItems()),
                CartTotal = _cartService.GetTotalAmount(),
                CartQuantity = _cartService.GetQuantity()
            };

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult AddToCart(int id)
        {
            _cartService.AddToCart(id);
            _unitOfWork.Commit();

            return Json(new
            {
                cartQuantity = _cartService.GetQuantity()
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EmptyCart()
        {
            _cartService.EmptyCart();
            _unitOfWork.Commit();

            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCartItem(int id, int quantity)
        {
            var item = _cartService.UpdateItem(id, quantity);
            _unitOfWork.Commit();

            return Json(new
            {
                cartItem = item,
                cartTotal = _cartService.GetTotalAmount(),
                cartQuantity = _cartService.GetQuantity()

            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult RemoveFromCart(int id)
        {
            _cartService.RemoveAllFromCart(id);
            _unitOfWork.Commit();

            return Json(new
            {
                cartTotal = _cartService.GetTotalAmount(),
                cartQuantity = _cartService.GetQuantity()
            }, JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public PartialViewResult _NavbarMiniCart()
        {
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = Mapper.Map<IEnumerable<CartItemViewModel>>(_cartService.GetCartItems()),
                CartTotal = _cartService.GetTotalAmount(),
                CartQuantity = _cartService.GetQuantity()
            };

            return PartialView(viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult _ReviewCart()
        {
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = Mapper.Map<IEnumerable<CartItemViewModel>>(_cartService.GetCartItems()),
                CartTotal = _cartService.GetTotalAmount(),
                CartQuantity = _cartService.GetQuantity()
            };

            return PartialView(viewModel);
        }

    }
}