using AutoTradeHub.Models;

namespace AutoTradeHub.Interfaces
{
	public interface IFavoriteRepository
	{
		Task<Favorites> FindFavoritesAsync(int carId, string userId);
		bool AddToFavorite(int carId, string userId);
		bool AddToFavorite(Favorites favorites);
		bool DeleteFromFavorite(Favorites favorites);
		Task<bool> DeleteFromFavorite(int carId, string userId);
		bool Save();
		Task<bool> IsInFavorite(int carId, string userId);
	}
}
