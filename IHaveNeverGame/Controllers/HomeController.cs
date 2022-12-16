using IHaveNeverGame.Models;
using IHaveNeverGame.Models.Domain;
using IHaveNeverGame.Models.Repository;
using IHaveNeverGame.Models.ViewComonents;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IHaveNeverGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Question> questionRepository;
        private readonly IRepository<Player> playerRepository;
        public HomeController(IRepository<Player> playerRepository, IRepository<Question> questionRepository) =>
            (this.questionRepository, this.playerRepository) = (questionRepository, playerRepository);


        public IActionResult Index() => View();

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
                Questions = questionRepository.Entities.ToList(),
                IsQuestionChangeed = false,
                QuestionID = 1
            };

            return View("Game", viewComponent);
        }

        public IActionResult AddShot(long id, int shotCount, long questionID)
        {
            var toChange = playerRepository.Entities.ToList().Where(entity => entity.ID == id).First();
            toChange.ShotCount++;
            playerRepository.Update(toChange);


            return RedirectToAction(nameof(Game), new { priviousQuestionID = questionID });
        }

        public IActionResult Game(bool isQuestionChanged = false, int priviousQuestionID = default)
        {
            var viewComponent = new GameViewComponent
            {
                Players = playerRepository.Entities.ToList(),
                Questions = questionRepository.Entities.ToList(),
                IsQuestionChangeed = isQuestionChanged,
                QuestionID = priviousQuestionID
            };
            return View("Game", viewComponent);
        }

        public IActionResult ChangeScore(long id, long questionID)
        {
            var player = playerRepository.GetByID(id);
            player.Score++;
            player.ShotCount = 0;
            
            return RedirectToAction(nameof(Game), new { priviousQuestionID = questionID });
        }
        public IActionResult ShowResultPage() => View(playerRepository.Entities);
        public IActionResult ChangeStatus(long id, int questionID)
        {
            playerRepository.GetByID(id).IsInGame = false;

            if (playerRepository.Entities.Where(player => player.IsInGame).Count() == 1)
                return RedirectToAction(nameof(ShowResultPage));
            else
                return RedirectToAction(nameof(Game), new { priviousQuestionID = questionID });

            
        }

        public IActionResult ChangeQuestion(long id)
        {
            questionRepository.Delete(id);
            return RedirectToAction(nameof(Game), new { isQuestionChanged = true });
        }
        public IActionResult Privacy() => View();
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });   
    }
}
