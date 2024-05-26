using AutoTradeHub.Data;
using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoTradeHub.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _appDbContext;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ICarRepository _carRepository;

		public UserRepository(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor,
			ICarRepository carRepository)
		{
			_appDbContext = appDbContext;
			_httpContextAccessor = httpContextAccessor;
			_carRepository = carRepository;
		}

		public bool Add(AppUser user)
		{
			_appDbContext.Users.Add(user);
			return Save();
		}

		public bool Delete(AppUser user)
		{
			_appDbContext.Users.Remove(user);
			return Save();
		}

		public async Task<List<Car>> GetAllUserAds()
		{
			var userName = _httpContextAccessor.HttpContext?.User.Identity.Name.ToString();
			AppUser user = await _appDbContext.Users.FirstOrDefaultAsync(i => i.UserName == userName);

			return await _appDbContext.cars.Include(a => a.Color).Include(a => a.Generation).Include(a => a.Marka).Include(a => a.Model).Where(c => c.AppUserId == user.Id).ToListAsync();
		}

		public async Task<List<Car>> GetAllUserCars()
		{
			var userName = _httpContextAccessor.HttpContext?.User.Identity.Name.ToString();
			AppUser user = await _appDbContext.Users.Include(r => r.Favorites).FirstOrDefaultAsync(i => i.UserName == userName);

			List<Car> cars = new List<Car>();
			foreach (Favorites favorite in user.Favorites)
			{
				Car car = await _carRepository.GetByIdAsync(favorite.CarId);
				cars.Add(car);
			}

			return cars;
		}

		public async Task<List<AppUser>> GetAllUsers()
		{
			return await _appDbContext.Users.ToListAsync();
		}

		public async Task<AppUser> GetById(string id)
		{
			return await _appDbContext.Users.FirstOrDefaultAsync(i => i.Id == id);
		}

		public async Task<AppUser> GetCurrentUser()
		{
			string? userName = _httpContextAccessor.HttpContext?.User.Identity?.Name?.ToString();
			AppUser? user = await _appDbContext.Users.FirstOrDefaultAsync(i => i.UserName == userName);
			return user;
		}

		public bool Save()
		{
			var saved = _appDbContext.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(AppUser user)
		{
			_appDbContext.Users.Update(user);
			return Save();
		}
	}
}
