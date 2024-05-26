using AutoTradeHub.Interfaces;
using AutoTradeHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoTradeHub.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminDashboardController : Controller
	{
		private readonly IUserRepository _userRepository;

		public AdminDashboardController(IUserRepository userRepository)
        {
			_userRepository = userRepository;
		}
        public async Task<IActionResult> Index()
		{
			var curUser = await _userRepository.GetCurrentUser();
			var user = new UserVM(curUser);
			return View(user);
		}
		public async Task<IActionResult> Users()
		{
			var curUser = await _userRepository.GetCurrentUser();
			var user = new UserVM(curUser);
			return View(user);
		}
		public async Task<IActionResult> MMG()
		{
			var curUser = await _userRepository.GetCurrentUser();
			var user = new UserVM(curUser);
			return View(user);
		}
		public async Task<IActionResult> Colors()
		{
			var curUser = await _userRepository.GetCurrentUser();
			var user = new UserVM(curUser);
			return View(user);
		}
	}
}
