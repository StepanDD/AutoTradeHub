﻿using AutoTradeHub.Models;

namespace AutoTradeHub.Interfaces
{
    public interface IGenerationRepository
    {
        Task<IEnumerable<Generation>> GetAll();
        Task<Generation> GetByIdAsync(int id);
        Task<IEnumerable<Generation>> GetByModelAsync(string model);
        Task<IEnumerable<Generation>> GetByModelAsync(int modelId);
        bool Add(Generation generation);
        bool Update(Generation generation);
        bool Delete(Generation generation);
        bool Save();
    }
}
