using AutoTradeHub.Data;
using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoTradeHub.Repository
{
	public class PhotoRepository : IPhotoRepository
	{
		private readonly AppDbContext _context;

		public PhotoRepository(AppDbContext context)
        {
			_context = context;
		}
        public bool Add(Photo photo)
		{
			_context.Add(photo);
			return Save();
		}

		public bool Delete(Photo photo)
		{
			_context.Remove(photo);
			return Save();
		}

		public async Task<bool> DeleteByCarAsync(int carId)
		{
			IEnumerable<Photo> photos = await GetByCarAsync(carId);
			foreach (var photo in photos)
			{
				_context.Remove(photo);
			}
			return Save();
		}

		public async Task<IEnumerable<Photo>> GetByCarAsync(Car car)
		{
			return await _context.photos.Where(c => c.carId == car.Id).ToListAsync();
		}

		public async Task<IEnumerable<Photo>> GetByCarAsync(int carId)
		{
			return await _context.photos.Where(c => c.carId == carId).ToListAsync();
		}

		public async Task<Photo> GetByIdAsync(int id)
		{
			return await _context.photos.FirstOrDefaultAsync(i => i.Id == id);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(Photo photo)
		{
			_context.Update(photo);
			return Save();
		}
	}
}
