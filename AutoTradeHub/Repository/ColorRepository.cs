using AutoTradeHub.Data;
using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoTradeHub.Repository
{
	public class ColorRepository : IColorRepository
	{
		private readonly AppDbContext _context;
		private readonly ICarRepository _carRepository;

		public ColorRepository(AppDbContext context, ICarRepository carRepository)
		{
			_context = context;
			_carRepository = carRepository;
		}

		public bool Add(Color color)
		{
			_context.Add(color);
			return Save();
		}

		public bool Delete(Color color)
		{
			if (color.Id == -1)
			{
				return false;
			}
			_carRepository.UpdateColorToDefault(color.Id);
			_context.Remove(color);
			return Save();
		}

		public async Task<bool> DeleteById(int id) //Не использовать (не работает)
		{
			Color color = await GetByIdAsync(id);
			Delete(color);
			return Save();
		}

		public async Task<List<Color>> GetAll()
		{
			return await _context.colors.OrderBy(s => s.Name).ToListAsync();
		}

		public async Task<Color> GetByIdAsync(int id)
		{
			return await _context.colors.FirstOrDefaultAsync(i => i.Id == id);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(Color color)
		{
			_context.Update(color);
			return Save();
		}
	}
}
