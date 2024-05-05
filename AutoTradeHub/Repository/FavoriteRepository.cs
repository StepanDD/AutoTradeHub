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

		public bool DeleteFromFavorite(Favorites favorites)
		{
			throw new NotImplementedException();
		}

		public bool IsInFavorite(int carId, string userId)
		{
			return false;
		}

		public bool Save()
		{
			var saved = _appDbContext.SaveChanges();
			return saved > 0 ? true : false;
		}
	}
}
