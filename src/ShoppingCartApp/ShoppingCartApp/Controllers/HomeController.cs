using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartApp.Models;

namespace ShoppingCartApp.Controllers
{
    public class HomeController : Controller
    {
        private GameStoreEntities db = new GameStoreEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult PlatformMenu()
        {
            var genres = db.Platforms.ToList();
            return PartialView(genres);
        }
    }
}
