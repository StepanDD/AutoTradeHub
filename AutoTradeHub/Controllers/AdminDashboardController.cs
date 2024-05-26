using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using AutoTradeHub.Service;
using AutoTradeHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoTradeHub.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminDashboardController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly UserManager<AppUser> _userManager;
		private readonly IPhotoService _photoService;

		public AdminDashboardController(IUserRepository userRepository, UserManager<AppUser> userManager,
			IPhotoService photoService)
        {
			_userRepository = userRepository;
			_userManager = userManager;
			_photoService = photoService;
		}
        public async Task<IActionResult> Index()
		{
			return View(await createAdminDVM());
		}
		public async Task<IActionResult> Users()
		{
			return View(await createAdminDVM());
		}
		public async Task<IActionResult> MMG()
		{
			return View(await createAdminDVM());
		}
		public async Task<IActionResult> Colors()
		{
			return View(await createAdminDVM());
		}
		public async Task<IActionResult> BanUser(string userId)
		{
			var user = await _userRepository.GetById(userId);
			_photoService.DeletePhoto(user.PhotoPath);
			await _userManager.DeleteAsync(user);
			return RedirectToAction("Users");
		}
		private async Task<AdminDashboardVM> createAdminDVM()
		{
			var curUser = await _userRepository.GetCurrentUser();
			var user = new UserVM(curUser);
			List<AppUser> appUsers = await _userRepository.GetAllUsers();
			AdminDashboardVM adminDashboardVM = new AdminDashboardVM(user, appUsers);
			return adminDashboardVM;
		}
	}
}
