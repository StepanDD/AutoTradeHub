using AutoTradeHub.Data;
using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoTradeHub.Repository
{
	public class FavoriteRepository : IFavoriteRepository
	{
		private readonly AppDbContext _appDbContext;

		public FavoriteRepository(AppDbContext appDbContext)
        {
			_appDbContext = appDbContext;
		}

		public bool AddToFavorite(int carId, string userId)
		{
			Favorites favorites = new Favorites(carId, userId);
			_appDbContext.Add(favorites);
			return Save();
		}

		public bool AddToFavorite(Favorites favorites)
		{
			_appDbContext.Add(favorites);
			return Save();
		}

		public bool DeleteFromFavorite(Favorites favorites)
		{
			_appDbContext.Remove(favorites);
			return Save();
		}

		public async Task<bool> DeleteFromFavorite(int carId, string userId)
		{
			Favorites favorites = await FindFavoritesAsync(carId, userId);
			_appDbContext.Remove(favorites);
			return Save();
		}

		public async Task<Favorites> FindFavoritesAsync(int carId, string userId)
		{
			return await _appDbContext.favorites.FirstOrDefaultAsync(i => i.CarId == carId && i.AppUserId == userId);
			//return await _appDbContext.favorites.FirstAsync(i => i.CarId == carId && i.AppUserId == userId);
		}

		public async Task<bool> IsInFavorite(int carId, string userId)
		{
			Favorites favorites = await FindFavoritesAsync(carId, userId);
			if (favorites == null)
				return false;
			return true;
		}

		public bool Save()
		{
			var saved = _appDbContext.SaveChanges();
			return saved > 0 ? true : false;
		}
	}
}
