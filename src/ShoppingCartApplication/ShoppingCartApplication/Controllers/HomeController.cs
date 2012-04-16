using System.Linq;
using System.Web.Mvc;
using ShoppingCartApplication.Models;

namespace ShoppingCartApplication.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult PlatformMenu()
        {
            var genres = db.Platforms.ToList();
            return PartialView(genres);
        }

        public ActionResult Browse(string platform)
        {
            // Get games for this platform
            var platformModel = db.Platforms.Include("Games")
                .Single(g => g.Name == platform);

            return View(platformModel);
        }

        public ActionResult Details(int id)
        {
            var game = db.Games.Find(id);

            return View(game);
        }
    }
}
