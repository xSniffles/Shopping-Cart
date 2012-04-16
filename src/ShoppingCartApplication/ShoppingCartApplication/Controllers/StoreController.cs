using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ShoppingCartApplication.Models;

namespace ShoppingCartApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StoreController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Store/

        public ViewResult Index()
        {
            var games = db.Games.Include(g => g.Platform).Include(g => g.Genre);
            return View(games.ToList());
        }

        //
        // GET: /Store/Details/5

        public ViewResult Details(int id)
        {
            Game game = db.Games.Find(id);
            return View(game);
        }

        //
        // GET: /Store/Create

        public ActionResult Create()
        {
            ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "Name");
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name");
            return View();
        } 

        //
        // POST: /Store/Create

        [HttpPost]
        public ActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "Name", game.PlatformID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", game.GenreID);
            return View(game);
        }
        
        //
        // GET: /Store/Edit/5
 
        public ActionResult Edit(int id)
        {
            Game game = db.Games.Find(id);
            ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "Name", game.PlatformID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", game.GenreID);
            return View(game);
        }

        //
        // POST: /Store/Edit/5

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "Name", game.PlatformID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", game.GenreID);
            return View(game);
        }

        //
        // GET: /Store/Delete/5
 
        public ActionResult Delete(int id)
        {
            Game game = db.Games.Find(id);
            return View(game);
        }

        //
        // POST: /Store/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}