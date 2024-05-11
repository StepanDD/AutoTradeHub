using AutoTradeHub.Interfaces;
using AutoTradeHub.Models;
using AutoTradeHub.Repository;
using AutoTradeHub.ViewModels;

namespace AutoTradeHub.Service
{
	public class PhotoService : IPhotoService
	{
		private readonly string directoryPath = "wwwroot/photos";
        public bool DeletePhoto(string fileName)
		{
			throw new NotImplementedException();
		}

		public async Task<string> SavePhoto(IFormFile file)
		{
			string extension = Path.GetExtension(file.FileName);
			string fullPath = $"{directoryPath}/{Guid.NewGuid()}{extension}";
			using (var fileStream = new FileStream(fullPath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}
			return fullPath;
		}

		public async Task<bool> SavePhotos(IEnumerable<IFormFile> files, int _carId, IPhotoRepository _photoRepository)
		{
			foreach (var file in files)
			{
				Photo photo = new Photo()
				{
					carId = _carId,
					Path = await SavePhoto(file),
				};
				_photoRepository.Add(photo);
			}
			return true;
		}
	}
}
