using AutoMapper;
using Microsoft.AspNet.Identity;
using Planet.Common.Helper;
using Planet.Data.Core;
using Planet.Data.Core.Domain;
using Planet.Services.Core;
using Planet.Web.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Planet.Web.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IUnitOfWork _unitOfWork;

        public CheckoutController(IOrderService orderService, ICartService cartService, IPaymentMethodService paymentMethodService, IUnitOfWork unitOfWork)
        {
            _orderService = orderService;
            _cartService = cartService;
            _paymentMethodService = paymentMethodService;
            _unitOfWork = unitOfWork;
        }

        public ActionResult AddressAndPayment()
        {
            ViewBag.PaymentMethods = Mapper.Map<IEnumerable<PaymentMethodViewModel>>(_paymentMethodService.GetAll());
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddressAndPayment(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.PaymentMethods = Mapper.Map<IEnumerable<PaymentMethodViewModel>>(_paymentMethodService.GetAll());
                return View(model);
            }

            var order = Mapper.Map<Order>(model);
            order.CustomerId = User.Identity.GetUserId();
            order.OrderDate = DateTime.Now;
            order.StatusId = 1;

            _orderService.Add(order);
            _unitOfWork.Commit();

            _cartService.CreateOrder(order);
            _unitOfWork.Commit();

            return RedirectToAction("Complete", new { id = order.Id });
        }

        [Authorize]
        public ActionResult Complete(int id)
        {
            var order = _orderService.GetById(id);

            if (order != null)
            {
                //                string mailContent = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/template/order_success.html"));
                MailHelper.SendMail("huuthangit.dn@gmail.com", "Order Success", "Test thoi ma");
                return View(id);
            }

            return View("Error");
        }
    }
}