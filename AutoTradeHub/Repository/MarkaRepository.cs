using AutoTradeHub.Data;
using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoTradeHub.Repository
{
    public class MarkaRepository : IMarkaRepository
    {
        private readonly AppDbContext _context;

        public MarkaRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Marka marka)
        {
            _context.Add(marka);
            return Save();
        }

        public bool Delete(Marka marka)
        {
            _context.Remove(marka);
            return Save();
        }

        public async Task<IEnumerable<Marka>> GetAll()
        {
            return await _context.marks.ToListAsync();
        }

        public async Task<Marka> GetByIdAsync(int id)
        {
            return await _context.marks.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Marka marka)
        {
            _context.Update(marka);
            return Save();
        }
    }
}
