using AutoTradeHub.Models;

namespace AutoTradeHub.Interfaces
{
	public interface IUserRepository
	{
		Task<List<Car>> GetAllUserCars();
		Task<AppUser> GetCurrentUser();
	}
}
