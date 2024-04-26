using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using AutoTradeHub.ViewModels;
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

        public async Task<IActionResult> Edit(int id)
        {
            Car car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return View("Error");
            }
            ViewBag.marks = await _markaRepository.GetAll();
            ViewBag.models = await _modelRepository.GetAll();
            ViewBag.generations = await _generationRepository.GetAll();
            ViewBag.colors = await _colorRepository.GetAll();
            var carVM = new EditCarVM()
            {
                Id = car.Id,
                MarkaId = car.MarkaId,
                Marka = car.Marka,
                ModelId = car.ModelId,
                Model = car.Model,
                GenerationId = car.GenerationId,
                Generation = car.Generation,
                ColorId = car.ColorId,
                Color = car.Color,
                Price = car.Price,
                EngineVolume = car.EngineVolume,
                EnginePower = car.EnginePower,
                SteeringWheel = car.SteeringWheel,
                Gearbox = car.Gearbox,
                Description = car.Description,
                Year = car.Year,
                EngineType = car.EngineType,
                Privod = car.Privod,
                BodyType = car.BodyType,
                Probeg = car.Probeg,
            };
            return View(carVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCarVM editCarVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ошибка");
                return View(editCarVM);
            }
            var car = new Car(editCarVM, id);
            _carRepository.Update(car);
            return RedirectToAction("Index", "Home");
        }
    }
}
