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
		private readonly IPhotoRepository _photoRepository;
		private readonly IPhotoService _photoService;

		public CarController(IMarkaRepository markaRepository, ICarRepository carRepository,
            IModelRepository modelRepository, IGenerationRepository generationRepository,
            IColorRepository colorRepository, IUserRepository userRepository,
            IFavoriteRepository favoriteRepository, IPhotoRepository photoRepository,
            IPhotoService photoService)
        {
            _carRepository = carRepository;
            _modelRepository = modelRepository;
            _markaRepository = markaRepository;
            _generationRepository = generationRepository;
            _colorRepository = colorRepository;
			_userRepository = userRepository;
			_favoriteRepository = favoriteRepository;
			_photoRepository = photoRepository;
			_photoService = photoService;
		}
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            Car car = await _carRepository.GetByIdAsync(id);
            CarVM carVM = new CarVM(car);
            IEnumerable<Photo> photos = await _photoRepository.GetByCarAsync(id);
			foreach (var photo in photos)
            {
                carVM.PhotosPath.Add(carVM.NormalizePath(photo.Path));
            }
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
				return View(carVM);
            }
            carVM.AppUser = await _userRepository.GetCurrentUser();
            carVM.AppUserId = carVM.AppUser.Id;
            carVM.Path = await _photoService.SavePhoto(carVM.MainPhoto);
            Car newCar = new Car(carVM);
            _carRepository.Add(newCar);
            await _photoService.SavePhotos(carVM.Photos, newCar.Id, _photoRepository);
			return RedirectToAction(actionName: "Index", controllerName: "Home");
		}

		[Authorize]
		public async Task<IActionResult> Edit(int id)
        {
			var curUser = await _userRepository.GetCurrentUser();
			Car car = await _carRepository.GetByIdAsync(id);
			if (car == null || curUser == null)
			{
				return View("Error");
			}
			if (car.AppUserId != curUser.Id)
			{
				return View("Error");
			}
			ViewBag.marks = await _markaRepository.GetAll();
            ViewBag.model = car.ModelId;
            ViewBag.generation = car.GenerationId;
            ViewBag.colors = await _colorRepository.GetAll();
			var carVM = new CarVM(car);
            return View(carVM);
        }

		[Authorize]
		[HttpPost]
        public async Task<IActionResult> Edit(CarVM carVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ошибка");
				ViewBag.marks = await _markaRepository.GetAll();
				ViewBag.colors = await _colorRepository.GetAll();
				return View(carVM);
            }
			if (carVM.MainPhoto != null)
			{
                _photoService.DeletePhoto(carVM.Path);
				carVM.Path = await _photoService.SavePhoto(carVM.MainPhoto);
			}

			var curUser = await _userRepository.GetCurrentUser();
			var car = new Car(carVM, carVM.Id);
			if (car.AppUserId != curUser.Id)
			{
				return View("Error");
			}
			_carRepository.Update(car);
			if (carVM.Photos != null)
			{
                _photoService.DeletePhotos(await _photoRepository.GetByCarAsync(car));
                await _photoRepository.DeleteByCarAsync(car.Id);
				await _photoService.SavePhotos(carVM.Photos, car.Id, _photoRepository);
			}
			return RedirectToAction(actionName: "MyAds", controllerName: "Dashboard");
		}

		[Authorize]
		public async Task<IActionResult> Delete(int id)
        {
			var curUser = await _userRepository.GetCurrentUser();
			Car car = await _carRepository.GetByIdAsync(id);
            if (car == null || curUser == null)
            {
                return View("Error");
            }
            if (car.AppUserId != curUser.Id)
            {
                return View("Error");
			}
			CarVM carVM = new CarVM(car);
			return View(carVM);
		}

		[Authorize]
		[HttpPost]
        public async Task<IActionResult> Delete(CarVM carVM)
        {
			if (!ModelState.IsValid)
            {
                return View("Error");
			}
            var curUser = await _userRepository.GetCurrentUser();
			var car = new Car(carVM, carVM.Id);
			if (car.AppUserId != curUser.Id)
			{
				return View("Error");
			}
			_photoService.DeletePhotos(await _photoRepository.GetByCarAsync(car));
			_carRepository.Delete(car);
			_photoService.DeletePhoto(carVM.Path);
			return RedirectToAction(actionName: "MyAds", controllerName: "Dashboard");
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
