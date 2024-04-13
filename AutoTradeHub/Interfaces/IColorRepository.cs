using AutoTradeHub.Models;

namespace AutoTradeHub.Interfaces
{
    public interface IColorRepository
    {
        Task<IEnumerable<Color>> GetAll();
        Task<Color> GetByIdAsync(int id);
        bool Add(Color color);
        bool Update(Color color);
        bool Delete(Color color);
        bool Save();
    }
}
