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

		public UserRepository(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
			_appDbContext = appDbContext;
			_httpContextAccessor = httpContextAccessor;
		}
        public async Task<List<Car>> GetAllUserCars()
		{
			var user = _httpContextAccessor.HttpContext?.User;
			var userCars = _appDbContext.cars.Where(r => r.AppUser.Id == user.ToString());
			return userCars.ToList();
		}

		public async Task<AppUser> GetCurrentUser()
		{
			string userName = _httpContextAccessor.HttpContext.User.Identity.Name.ToString();
			AppUser user = await _appDbContext.Users.FirstOrDefaultAsync(i => i.UserName == userName);
			return user;
		}
	}
}
