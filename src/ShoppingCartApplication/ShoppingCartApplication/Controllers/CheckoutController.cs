using System;
using System.Linq;
using System.Web.Mvc;
using ShoppingCartApplication.Models;

namespace ShoppingCartApplication.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        Entities storeDB = new Entities();

        //
        // GET: /Checkout/AddressAndPayment

        public ActionResult Payment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment

        [HttpPost]
        public ActionResult Payment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                    order.UserName = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();

                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderID });

            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
                o => o.OrderID == id &&
                o.UserName == User.Identity.Name);

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
