using AutoTradeHub.Models;

namespace AutoTradeHub.Interfaces
{
	public interface IUserRepository
	{
		Task<List<Car>> GetAllUserCars();
		Task<List<Car>> GetAllUserAds();
		Task<AppUser> GetCurrentUser();
		Task<List<AppUser>> GetAllUsers();
		Task<AppUser> GetById(string id);
		bool Add(AppUser user);
		bool Update(AppUser user);
		bool Delete(AppUser user);
		bool Save();
	}
}
