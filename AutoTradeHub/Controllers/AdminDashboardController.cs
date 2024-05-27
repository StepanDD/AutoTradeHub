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
		private readonly IMarkaRepository _markaRepository;
		private readonly IModelRepository _modelRepository;
		private readonly IGenerationRepository _generationRepository;

		public AdminDashboardController(IUserRepository userRepository, UserManager<AppUser> userManager,
			IPhotoService photoService, IColorRepository colorRepository, IMarkaRepository markaRepository,
			IModelRepository modelRepository, IGenerationRepository generationRepository)
		{
			_userRepository = userRepository;
			_userManager = userManager;
			_photoService = photoService;
			_colorRepository = colorRepository;
			_markaRepository = markaRepository;
			_modelRepository = modelRepository;
			_generationRepository = generationRepository;
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
		public async Task<IActionResult> Models(int markaId, string markaName)
		{
			ViewBag.markaId = markaId;
			return View(await createAdminDVM(markaId, markaName));
		}
		public async Task<IActionResult> Generations(int modelId, string modelName, int markaId, string markaName)
		{
			ViewBag.modelId = modelId;
			ViewBag.markaId = markaId;
			return View(await createAdminDVM(markaId, markaName, modelId, modelName));
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
		[HttpPost]
		public IActionResult AddMarka(AdminDashboardVM vM)
		{
			if (!ModelState.IsValid || vM.NewMarka == "" || vM.NewMarka == null)
			{
				return RedirectToAction("MMG");
			}
			Marka newMarka = new Marka() { Name = vM.NewMarka, Id = 0 };
			_markaRepository.Add(newMarka);
			return RedirectToAction("MMG");
		}
		[HttpPost]
		public IActionResult AddModel(AdminDashboardVM vM)
		{
			if (!ModelState.IsValid || vM.NewModel == "" || vM.NewModel == null)
			{
				return RedirectToAction("Models", new { markaId = vM.NewModelMarkaFK, markaName = vM.NewModelMarkaName });
			}
			Model newModel = new Model() { Name = vM.NewModel, Id = 0, MarkaId = vM.NewModelMarkaFK };
			_modelRepository.Add(newModel);
			return RedirectToAction("Models", new { markaId = vM.NewModelMarkaFK, markaName = vM.NewModelMarkaName });
		}
		[HttpPost]
		public IActionResult AddGeneration(AdminDashboardVM vM)
		{
			if (!ModelState.IsValid || vM.NewGeneration == "" || vM.NewGeneration == null)
			{
				return RedirectToAction("Generations", new
				{
					modelId = vM.NewGenerationModelFK,
					modelName = vM.NewGenerationModelName,
					markaId = vM.NewModelMarkaFK,
					markaName = vM.NewModelMarkaName
				});
			}
			Generation newGeneration = new Generation() { Name = vM.NewGeneration, Id = 0, ModelId = vM.NewGenerationModelFK };
			_generationRepository.Add(newGeneration);
			return RedirectToAction("Generations", new
			{
				modelId = vM.NewGenerationModelFK,
				modelName = vM.NewGenerationModelName,
				markaId = vM.NewModelMarkaFK,
				markaName = vM.NewModelMarkaName
			});
		}
		public IActionResult DeleteColor(int id)
		{
			Color color = new Color() { Id = id };
			_colorRepository.Delete(color);
			return RedirectToAction("Colors");
		}
		private async Task<AdminDashboardVM> createAdminDVM(int markaId = -1, string markaName = "",
			int modelId = -1, string modelName = "")
		{
			var curUser = await _userRepository.GetCurrentUser();
			var user = new UserVM(curUser);
			List<AppUser> appUsers = await _userRepository.GetAllUsers();
			List<Color> colors = await _colorRepository.GetAll();
			List<Marka> marks = await _markaRepository.GetAll();
			AdminDashboardVM adminDashboardVM = new AdminDashboardVM(user, appUsers, colors, marks);
			if (markaId != -1)
			{
				adminDashboardVM.Models = await _modelRepository.GetByMarkaAsync(markaId);
			}
			if (markaName != "")
			{
				adminDashboardVM.NewModelMarkaName = markaName;
			}
			if (modelId != -1)
			{
				adminDashboardVM.Generations = await _generationRepository.GetByModelAsync(modelId);
			}
			if (modelName != "")
			{
				adminDashboardVM.NewGenerationModelName = modelName;
			}
			return adminDashboardVM;
		}
	}
}
