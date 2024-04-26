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
            CarVM carVM = new CarVM(car);
            return View(carVM);
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
        public async Task<IActionResult> Create(CarVM carVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.marks = await _markaRepository.GetAll();
                ViewBag.models = await _modelRepository.GetAll();
                ViewBag.generations = await _generationRepository.GetAll();
                ViewBag.colors = await _colorRepository.GetAll();
                return View();
            }
            Car newCar = new Car(carVM);
            _carRepository.Add(newCar);
			return RedirectToAction(actionName: "Index", controllerName: "Home");
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
            var carVM = new CarVM(car);
            return View(carVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarVM carVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ошибка");
                return View(carVM);
            }
            var car = new Car(carVM, id);
            _carRepository.Update(car);
            return RedirectToAction(actionName: "Detail", routeValues: new { id = id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            Car car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return View("Error");
            }
            CarVM carVM = new CarVM(car);
            return View(carVM);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CarVM carVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ошибка");
                return View(carVM);
            }
            var car = new Car(carVM, carVM.Id);
            _carRepository.Delete(car);
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}
