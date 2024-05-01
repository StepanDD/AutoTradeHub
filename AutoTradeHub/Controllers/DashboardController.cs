using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using AutoTradeHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutoTradeHub.Controllers
{
	public class DashboardController : Controller
	{
		private readonly IUserRepository _userRepository;

		public DashboardController(IUserRepository userRepository)
        {
			_userRepository = userRepository;
		}
        public async Task<IActionResult> Index()
		{
			AppUser? curUser = await _userRepository.GetCurrentUser();
			List<Car> cars = await _userRepository.GetAllUserCars();
			DashboardVM dashboardVM = new DashboardVM(curUser, cars);
			return View(dashboardVM);
		}
	}
}
