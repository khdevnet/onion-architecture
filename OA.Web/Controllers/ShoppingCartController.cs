using OA.Domain.Entities;
using OA.Domain.Extensibility.Repositories;
using OA.Service.Extensibility;
using OA.Web.ViewModels;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartController(IAlbumRepository albumRepository, IShoppingCartService shoppingCartService)
        {
            this.albumRepository = albumRepository;
            this.shoppingCartService = shoppingCartService;
        }

        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = shoppingCartService.GetCartItems(),
                CartTotal = shoppingCartService.GetTotal()
            };

            // Return the view
            return View(viewModel);
        }

        //
        // GET: /Store/AddToCart/5

        public ActionResult AddToCart(int id)
        {
            shoppingCartService.AddToCart(id);

            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            Cart cartRecord = shoppingCartService.GetCartRecord(id);

            int itemCount = shoppingCartService.RemoveCartRecord(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(cartRecord.Album.Title) +
                    " has been removed from your shopping cart.",
                CartTotal = shoppingCartService.GetTotal(),
                CartCount = shoppingCartService.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            ViewData["CartCount"] = shoppingCartService.GetCount();

            return PartialView("CartSummary");
        }
    }
}
