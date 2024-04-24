using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoTradeHub.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IMarkaRepository _markaRepository;
        private readonly IGenerationRepository _generationRepository;
        private readonly IColorRepository _colorRepository;

        public CarController(IMarkaRepository markaRepository, ICarRepository carRepository, 
            IModelRepository modelRepository, IGenerationRepository generationRepository, 
            IColorRepository colorRepository)
        {
            _carRepository = carRepository;
            _modelRepository = modelRepository;
            _markaRepository = markaRepository;
            _generationRepository = generationRepository;
            _colorRepository = colorRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            Car car = await _carRepository.GetByIdAsync(id);
            return View(car);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.marks = await _markaRepository.GetAll();
            ViewBag.models = await _modelRepository.GetAll();
            ViewBag.generations = await _generationRepository.GetAll();
            ViewBag.colors = await _colorRepository.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.marks = await _markaRepository.GetAll();
                ViewBag.models = await _modelRepository.GetAll();
                ViewBag.generations = await _generationRepository.GetAll();
                ViewBag.colors = await _colorRepository.GetAll();
                return View();
            }
            _carRepository.Add(car);
            return RedirectToAction("Index");
        }

		public IActionResult Error()
        {
            return View();
        }
    }
}
