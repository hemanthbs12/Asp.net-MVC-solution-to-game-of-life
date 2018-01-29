using System;
using System.Configuration;
using System.Web.Mvc;
using GameOfLifePresentation;
using GameOfLifeRepository;

namespace GameOfLife.Controllers
{
    public class GameController : Controller
    {
        private readonly IGenerationRepository _generationRepository;

        public GameController(IGenerationRepository generationRepository)
        {
            _generationRepository = generationRepository;
        }
        public ActionResult Index()
        {
            var randomPopulationDistribution = _generationRepository.GetRandomPopulationDistribution(Convert.ToInt32(ConfigurationManager.AppSettings["PopulationSize"]));

            TempData["PreviousGeneration"] = randomPopulationDistribution;
            return View(randomPopulationDistribution);
        }

        public ActionResult NewGeneration()
        {
            var previousGeneration = (PopulationDistribution)TempData["PreviousGeneration"];
            if (previousGeneration == null) throw new ArgumentNullException(nameof(previousGeneration));
            var newGeneration = _generationRepository.GetNextGeneration(previousGeneration);
            
            TempData["PreviousGeneration"] = newGeneration;
            return View("index", newGeneration);

        }

        
    }
}