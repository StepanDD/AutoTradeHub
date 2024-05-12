using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using AutoTradeHub.Repository;
using AutoTradeHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoTradeHub.Controllers
{
	[Authorize]
	public class DashboardController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly IPhotoRepository _photoRepository;

		public DashboardController(IUserRepository userRepository, IPhotoRepository photoRepository)
        {
			_userRepository = userRepository;
			_photoRepository = photoRepository;
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
			DashboardVM dashboardVM = new DashboardVM(curUser, carsVM);
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
	}
}
