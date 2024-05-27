using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using AutoTradeHub.Service;
using AutoTradeHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AutoTradeHub.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminDashboardController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly UserManager<AppUser> _userManager;
		private readonly IPhotoService _photoService;
		private readonly IColorRepository _colorRepository;

		public AdminDashboardController(IUserRepository userRepository, UserManager<AppUser> userManager,
			IPhotoService photoService, IColorRepository colorRepository)
        {
			_userRepository = userRepository;
			_userManager = userManager;
			_photoService = photoService;
			_colorRepository = colorRepository;
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
		[HttpPost]
		public IActionResult AddColor(AdminDashboardVM vM)
		{
			if (!ModelState.IsValid || vM.NewColor == "" || vM.NewColor == null)
			{
				return RedirectToAction("Colors");
			}
			Color newColor = new Color() { Name = vM.NewColor, Id = 0 };
			_colorRepository.Add(newColor);
			return RedirectToAction("Colors");
		}
		public IActionResult DeleteColor(int id)
		{
			Color color = new Color() { Id = id };
			_colorRepository.Delete(color);
			return RedirectToAction("Colors");
		}
		private async Task<AdminDashboardVM> createAdminDVM()
		{
			var curUser = await _userRepository.GetCurrentUser();
			var user = new UserVM(curUser);
			List<AppUser> appUsers = await _userRepository.GetAllUsers();
			List<Color> colors = await _colorRepository.GetAll();
			AdminDashboardVM adminDashboardVM = new AdminDashboardVM(user, appUsers, colors);
			return adminDashboardVM;
		}
	}
}
