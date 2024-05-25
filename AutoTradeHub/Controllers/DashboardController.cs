using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using AutoTradeHub.Repository;
using AutoTradeHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoTradeHub.Controllers
{
	[Authorize]
	public class DashboardController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly IPhotoRepository _photoRepository;
		private readonly IPhotoService _photoService;
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public DashboardController(IUserRepository userRepository, IPhotoRepository photoRepository,
			IPhotoService photoService, UserManager<AppUser> userManager,
			SignInManager<AppUser> signInManager)
        {
			_userRepository = userRepository;
			_photoRepository = photoRepository;
			_photoService = photoService;
			_userManager = userManager;
			_signInManager = signInManager;
		}
        public async Task<IActionResult> Index()
		{
			AppUser? curUser = await _userRepository.GetCurrentUser();
			List<Car> cars = await _userRepository.GetAllUserCars();
			List<CarVM> carsVM = new List<CarVM>();
			foreach (Car car in cars)
			{
				carsVM.Add(new CarVM(car));
			}
			DashboardVM dashboardVM = new DashboardVM(curUser, carsVM, new UserVM(curUser));
			return View(dashboardVM);
		}
		public async Task<IActionResult> MyAds()
		{
			AppUser? curUser = await _userRepository.GetCurrentUser();
			List<Car> cars = await _userRepository.GetAllUserAds();
			List<CarVM> carsVM = new List<CarVM>();
			foreach (Car car in cars)
			{
				CarVM carVM = new CarVM(car);
				IEnumerable<Photo> photos = await _photoRepository.GetByCarAsync(car.Id);
				foreach (var photo in photos)
				{
					carVM.PhotosPath.Add(carVM.NormalizePath(photo.Path));
				}
				carsVM.Add(carVM);
			}
			return View(carsVM);
		}
		public async Task<IActionResult> Edit()
		{
			var curUser = await _userRepository.GetCurrentUser();
			return View(new UserVM(curUser));
		}
		[HttpPost]
		public async Task<IActionResult> Edit(UserVM user)
		{
			if (!ModelState.IsValid)
			{
				return View(user);
			}
			var updatedUser = await _userRepository.GetCurrentUser();
			if (user.Photo != null)
			{
				_photoService.DeletePhoto(updatedUser.PhotoPath);
				updatedUser.PhotoPath = await _photoService.SavePhoto(user.Photo);
			}
			updatedUser.Email = user.Email;
			updatedUser.FirstName = user.FirstName;
			updatedUser.LastName = user.LastName;
			updatedUser.PhoneNumber = user.PhoneNumber;
			_userRepository.Update(updatedUser);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Delete()
		{
			var curUser = await _userRepository.GetCurrentUser();
			await _signInManager.SignOutAsync();
			await _userManager.DeleteAsync(curUser);
			return RedirectToAction(actionName: "Index", controllerName: "Home");
		}
	}
}
