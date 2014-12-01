using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Chess.Data.Repositories;

namespace Chess.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewGame(string color)
        {
            var repo = new GamesRepository();
            var newGame = repo.GenerateNewGame(color);
            repo.Save(newGame);

            return RedirectToAction("Game", new RouteValueDictionary(new { ID = newGame.GameId }));
        }

        public ActionResult Game(Guid id)
        {
            var repo = new GamesRepository();
            var game = repo.Get(id);
            if (game == null)
            {
                return HttpNotFound("Can't find game with ID: " + id);
            }

            return View(game);
        }
    }
}
