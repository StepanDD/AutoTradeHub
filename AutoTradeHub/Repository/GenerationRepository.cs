﻿using AutoTradeHub.Data;
using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoTradeHub.Repository
{
    public class GenerationRepository : IGenerationRepository
    {
        private readonly AppDbContext _context;

        public GenerationRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(Generation generation)
        {
            _context.Add(generation);
            return Save();
        }

        public bool Delete(Generation generation)
        {
            _context.Remove(generation);
            return Save();
        }

        public async Task<IEnumerable<Generation>> GetAll()
        {
            return await _context.generations.Include(a => a.Model).ToListAsync();
        }

        public async Task<Generation> GetByIdAsync(int id)
        {
            return await _context.generations.Include(a => a.Model).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Generation>> GetByModelAsync(string model)
        {
            return await _context.generations.Include(a => a.Model).Where(c => c.Model.Name.Contains(model)).OrderBy(s => s.Name).ToListAsync();
        }

		public async Task<IEnumerable<Generation>> GetByModelAsync(int modelId)
		{
			return await _context.generations.Include(a => a.Model).Where(c => c.Model.Id == modelId).OrderBy(s => s.Name).ToListAsync();
		}

		public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Generation generation)
        {
            _context.Update(generation);
            return Save();
        }
    }
}
