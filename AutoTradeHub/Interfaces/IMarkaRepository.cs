﻿using AutoTradeHub.Models;

namespace AutoTradeHub.Interfaces
{
    public interface IMarkaRepository
    {
        Task<List<Marka>> GetAll();
        Task<Marka> GetByIdAsync(int id);
        bool Add(Marka marka);
        bool Update(Marka marka);
        bool Delete(Marka marka);
        bool Save();
    }
}
