using AutoTradeHub.Models;

namespace AutoTradeHub.Interfaces
{
	public interface IPhotoService
	{
		Task<string> SavePhoto(IFormFile file);
		Task<bool> SavePhotos(IEnumerable<IFormFile> files, int carId, IPhotoRepository photoRepository);
		bool DeletePhoto(string fileName);
		bool DeletePhotos(IEnumerable<string> fileNames);
		bool DeletePhotos(IEnumerable<Photo> photos);
	}
}
