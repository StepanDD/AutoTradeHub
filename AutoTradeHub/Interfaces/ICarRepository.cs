using AutoTradeHub.Models;

namespace AutoTradeHub.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAll();
        Task<Car> GetByIdAsync(int id);
        Task<IEnumerable<Car>> GetCarByMarka(string marka);
        Task UpdateColorToDefault(int colorId);
        bool Add(Car car);
        bool Update(Car car);
        bool Delete(Car car);
        Task<bool> DeleteById(int id);
        bool Save();
    }
}
