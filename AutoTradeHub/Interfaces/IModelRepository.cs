using AutoTradeHub.Models;

namespace AutoTradeHub.Interfaces
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAll();
        Task<Model> GetByIdAsync(int id);
        Task<IEnumerable<Model>> GetByMarkaAsync(string marka);
        Task<IEnumerable<Model>> GetByMarkaAsync(int markaId);
        bool Add(Model model);
        bool Update(Model model);
        bool Delete(Model model);
        bool Save();
    }
}
