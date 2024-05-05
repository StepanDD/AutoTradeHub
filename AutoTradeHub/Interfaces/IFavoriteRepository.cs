using AutoTradeHub.Models;

namespace AutoTradeHub.Interfaces
{
	public interface IFavoriteRepository
	{
		bool AddToFavorite(int carId, string userId);
		bool DeleteFromFavorite(Favorites favorites);
		bool Save();
		bool IsInFavorite(int carId, string userId);
	}
}
