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

        public ActionResult NewGame()
        {
            var repo = new GamesRepository();
            var newGame = repo.GenerateNewGame();
            repo.Save(newGame);

            return RedirectToAction("Game", new RouteValueDictionary(new { ID = newGame.GameId }));
        }

        public ActionResult Game(Guid id)
        {
            return View();
        }
    }
}
