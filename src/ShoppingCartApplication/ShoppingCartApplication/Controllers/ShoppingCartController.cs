using System.Linq;
using System.Web.Mvc;
using ShoppingCartApplication.Models;
using ShoppingCartApplication.ViewShoppingCart;

namespace ShoppingCartApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
        Entities storeDB = new Entities();


        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            // Return the view
            return View(viewModel);
        }


        public ActionResult AddToCart(int id)
        {

            // Get game for db
            var addedGame = storeDB.Games
                .Single(game => game.GameID == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedGame);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the game to display confirmation
            string gameTitle = storeDB.Carts
                .Single(item => item.RecordId == id).Game.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(gameTitle) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteID = id
            };

            return Json(results);
        }


        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }
    }
}