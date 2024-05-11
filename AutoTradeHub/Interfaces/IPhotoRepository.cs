using AutoTradeHub.Models;

namespace AutoTradeHub.Interfaces
{
	public interface IPhotoRepository
	{
		Task<Photo> GetByIdAsync(int id);
		Task<IEnumerable<Photo>> GetByCarAsync(Car car);
		Task<IEnumerable<Photo>> GetByCarAsync(int carId);
		bool Add(Photo photo);
		bool Update(Photo photo);
		bool Delete(Photo photo);
		bool Save();
	}
}
