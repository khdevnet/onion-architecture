using AutoMapper;
using OA.Domain.Entities;
using OA.Domain.Extensibility.Repositories;
using OA.Service.Extensibility;
using OA.Web.Extensibility;
using OA.Web.ViewModels.Checkout;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private const string PromoCode = "FREE";
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly IOrderRepository orderRepository;
        private readonly IOrderService orderService;
        private readonly IShoppingCartService shoppingCartService;
        private readonly IMapper mapper;

        public CheckoutController(
            ICurrentUserProvider currentUserProvider,
            IOrderRepository orderRepository,
            IOrderService orderService,
            IShoppingCartService shoppingCartService,
            IMapper mapper)
        {
            this.currentUserProvider = currentUserProvider;
            this.orderRepository = orderRepository;
            this.orderService = orderService;
            this.shoppingCartService = shoppingCartService;
            this.mapper = mapper;
        }
        //
        // GET: /Checkout/AddressAndPayment

        public ActionResult AddressAndPayment()
        {
            if (string.IsNullOrEmpty(currentUserProvider.GetUserId()) || !shoppingCartService.GetCartItems().Any())
            {
                return View("Error");
            }

            return View(new OrderViewModel
            {
                FirstName = "Han",
                LastName = "Solo",
                Address = "Space",
                City = "Nabu",
                Country = "Star Wars",
                Email = "han@gmail.com",
                Phone = "333333",
                PostalCode = "NB",
                State = "ST"
            });
        }

        //
        // POST: /Checkout/AddressAndPayment

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);
            OrderViewModel orderViewModel = mapper.Map<OrderViewModel>(order);
            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(orderViewModel);
                }
                else
                {
                    order.Username = currentUserProvider.GetUserId();
                    order.OrderDate = DateTime.Now;

                    Order addedOrder = orderService.Create(order, shoppingCartService.GetCartItems());

                    return RedirectToAction("Complete",
                        new { id = addedOrder.Id });
                }

            }
            catch
            {
                //Invalid - redisplay with errors
                return View(orderViewModel);
            }
        }

        //
        // GET: /Checkout/Complete

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = orderRepository.Get().Any(
                o => o.Id == id &&
                o.Username == currentUserProvider.GetUserId());

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
