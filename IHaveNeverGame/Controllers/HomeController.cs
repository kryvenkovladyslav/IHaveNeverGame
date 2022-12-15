using IHaveNeverGame.Models;
using IHaveNeverGame.Models.Domain;
using IHaveNeverGame.Models.Repository;
using IHaveNeverGame.Models.ViewComonents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IHaveNeverGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Question> questionRepository;
        private readonly IRepository<Player> playerRepository;
        private readonly ILogger<HomeController> logger;

        public HomeController(IRepository<Player> playerRepository, IRepository<Question> questionRepository,
            ILogger<HomeController> logger)
        {
            this.questionRepository = questionRepository;
            this.playerRepository = playerRepository;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateConfigure(int playersCount, int countOfShots)
        {
            GameContext.CountOfShots = countOfShots;

            List<Player> players = new List<Player>();
            for (int i = 0; i < playersCount; i++)
                players.Add(new Player());

            return View(players);
        }
        [HttpPost]
        public IActionResult StartGame(List<Player> players)
        {
            playerRepository.AddRange(players);

            var viewComponent = new GameViewComponent
            {
                Players = playerRepository.Entities.ToList(),
                Questions = questionRepository.Entities.ToList()
            };

            return View("Game", viewComponent);
        }

        public IActionResult AddShot(long id, int shotCount)
        {
            var toChange = playerRepository.Entities.ToList().Where(entity => entity.ID == id).First();
            toChange.ShotCount++;
            playerRepository.Update(toChange);

            var viewComponent = new GameViewComponent
            {
                Players = playerRepository.Entities.ToList(),
                Questions = questionRepository.Entities.ToList()
            };
            return View("Game",viewComponent);
        }
        public IActionResult Privacy()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
