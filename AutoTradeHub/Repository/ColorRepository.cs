using AutoTradeHub.Data;
using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoTradeHub.Repository
{
	public class ColorRepository : IColorRepository
	{
		private readonly AppDbContext _context;

		public ColorRepository(AppDbContext context)
		{
			_context = context;
		}

		public bool Add(Color color)
		{
			_context.Add(color);
			return Save();
		}

		public bool Delete(Color color)
		{
			_context.Remove(color);
			return Save();
		}

		public async Task<bool> DeleteById(int id)
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
