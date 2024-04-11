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

        public CarController(IMarkaRepository markaRepository, ICarRepository carRepository, IModelRepository modelRepository)
        {
            _carRepository = carRepository;
            _modelRepository = modelRepository;
            _markaRepository = markaRepository;

        }
        public IActionResult Index()
        {
            return View(); //Не создан!
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
            return View();
        }
    }
}
