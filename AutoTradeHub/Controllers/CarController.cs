using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using AutoTradeHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
		private readonly IUserRepository _userRepository;
		private readonly IFavoriteRepository _favoriteRepository;

		public CarController(IMarkaRepository markaRepository, ICarRepository carRepository,
            IModelRepository modelRepository, IGenerationRepository generationRepository,
            IColorRepository colorRepository, IUserRepository userRepository,
            IFavoriteRepository favoriteRepository)
        {
            _carRepository = carRepository;
            _modelRepository = modelRepository;
            _markaRepository = markaRepository;
            _generationRepository = generationRepository;
            _colorRepository = colorRepository;
			_userRepository = userRepository;
			_favoriteRepository = favoriteRepository;
		}
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            Car car = await _carRepository.GetByIdAsync(id);
            CarVM carVM = new CarVM(car);

			var curUser = await _userRepository.GetCurrentUser();
            if (curUser == null)
                ViewBag.IsInFavorite = false;
            else
            {
                bool isInFavorite = await _favoriteRepository.IsInFavorite(id, curUser.Id);
                ViewBag.IsInFavorite = isInFavorite;
            }
            return View(carVM);
        }

		[Authorize]
		public async Task<IActionResult> Create()
        {
            ViewBag.marks = await _markaRepository.GetAll();
            ViewBag.colors = await _colorRepository.GetAll();
            ViewBag.IsFirst = true;
            return View();
        }

		[Authorize]
		[HttpPost]
        public async Task<IActionResult> Create(CarVM carVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.marks = await _markaRepository.GetAll();
                ViewBag.colors = await _colorRepository.GetAll();
				ViewBag.IsFirst = false;
				return View();
            }
            carVM.AppUser = await _userRepository.GetCurrentUser();
            carVM.AppUserId = carVM.AppUser.Id;
            Car newCar = new Car(carVM);
            _carRepository.Add(newCar);
			return RedirectToAction(actionName: "Index", controllerName: "Home");
		}

		[Authorize(Roles = "Admin")]
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

		[Authorize(Roles = "Admin")]
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

		[Authorize(Roles = "Admin")]
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

		[Authorize(Roles = "Admin")]
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

        [Authorize]
		[HttpGet]
        public async Task<IActionResult> AddToFavorite(int carId)
        {
            var curUser = await _userRepository.GetCurrentUser();
            if (curUser == null)
				return new JsonResult(BadRequest());
			_favoriteRepository.AddToFavorite(carId, curUser.Id);
			return new JsonResult(Ok());
		}
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> DeleteFromFavorite(int carId)
		{
			var curUser = await _userRepository.GetCurrentUser();
            await _favoriteRepository.DeleteFromFavorite(carId, curUser.Id);
			return new JsonResult(Ok());
		}

		[HttpGet]
        public async Task<JsonResult> GetModelsByMarka(int markaId)
        {
            var models = await _modelRepository.GetByMarkaAsync(markaId);
            return new JsonResult(Ok(models));
        }

		[HttpGet]
		public async Task<JsonResult> GetGenerationsByModel(int modelId)
		{
			var generations = await _generationRepository.GetByModelAsync(modelId);
			return new JsonResult(Ok(generations));
		}
	}
}
