using AutoTradeHub.Data;
using AutoTradeHub.Models;
using AutoTradeHub.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoTradeHub.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
			AppDbContext appDbContext)
        {
            _context = appDbContext;
			_userManager = userManager;
			_signInManager = signInManager;
        }

		[HttpGet]
        public IActionResult Login()
		{
			var response = new LoginVM();
			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVM)
		{
			if(!ModelState.IsValid)
			{
				return View(loginVM);
			}
			AppUser user = await _userManager.FindByEmailAsync(loginVM.Email);
			if(user != null)
			{
				bool passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
				if (passwordCheck)
				{
					var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, true, false);
					if (result.Succeeded)
					{
						return RedirectToAction("Index", "Home");
					}
				}
				TempData["Error"] = "Неверный Email или пароль";
				return View(loginVM);
			}
			TempData["Error"] = "Неверный Email или пароль";
			return View(loginVM);
		}
	}
}
