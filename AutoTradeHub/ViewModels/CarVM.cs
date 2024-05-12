using AutoTradeHub.Data.Enum;
using AutoTradeHub.Models;
using System.ComponentModel.DataAnnotations;

namespace AutoTradeHub.ViewModels
{
	public class CarVM
	{
		public CarVM() { }
		public CarVM(Car car)
		{
			this.Id = car.Id;
			this.MarkaId = car.MarkaId;
			this.Marka = car.Marka;
			this.ModelId = car.ModelId;
			this.Model = car.Model;
			this.GenerationId = car.GenerationId;
			this.Generation = car.Generation;
			this.ColorId = car.ColorId;
			this.Color = car.Color;
			this.Price = car.Price;
			this.EngineVolume = car.EngineVolume;
			this.EnginePower = car.EnginePower;
			this.SteeringWheel = car.SteeringWheel;
			this.Gearbox = car.Gearbox;
			this.Description = car.Description;
			this.Year = car.Year;
			this.EngineType = car.EngineType;
			this.Privod = car.Privod;
			this.BodyType = car.BodyType;
			this.Probeg = car.Probeg;
			this.AppUser = car.AppUser;
			this.AppUserId = car.AppUserId;
			this.MainPhotoPath = NormalizePath(car.Path);
			this.PhotosPath = new List<string>();
			this.TextPrice = NormalizePrice(this.Price, '₽');
		}
		public int Id { get; set; }

		// Марка
		[Required(ErrorMessage = "Выберите марку!")]
		public int MarkaId { get; set; }
		public Marka? Marka { get; set; }

		// Модель
		[Required(ErrorMessage = "Выберите модель!")]
		public int ModelId { get; set; }
		public Model? Model { get; set; }

		// Поколение
		[Required(ErrorMessage = "Выберите поколение!")]
		public int GenerationId { get; set; }
		public Generation? Generation { get; set; }

		// Цвет
		[Required(ErrorMessage = "Выберите цвет!")]
		public int ColorId { get; set; }
		public Color? Color { get; set; }

		// Цена
		[Required(ErrorMessage = "Введите стоимость!")]
		public uint Price { get; set; }

		// Объём двигателя
		//[Required(ErrorMessage = "Введите объём двигателя!")]
		[Range(0.0, 1000.0, ErrorMessage = "Недопустимое значение объёма!")]
		public double EngineVolume { get; set; }

		// Мощность двигателя
		[Required(ErrorMessage = "Введите мощность двигателя!")]
		public ushort EnginePower { get; set; }

		// Расположение руля
		public SteeringWheel SteeringWheel { get; set; }

		// КПП
		public GearBox Gearbox { get; set; }

		// Описание
		public string? Description { get; set; }

		// Год
		[Required(ErrorMessage = "Введите год выпуска!")]
		public ushort Year { get; set; }

		// Тип двигателя
		public EngineType EngineType { get; set; }

		// Привод
		public Privod Privod { get; set; }

		// Тип кузова
		public BodyType BodyType { get; set; }

		// Пробег
		[Required(ErrorMessage = "Введите пробег!")]
		public uint Probeg { get; set; }

		public string? AppUserId { get; set; }
		public AppUser? AppUser { get; set; }

		public IFormFile? MainPhoto { get; set; }
		public string? MainPhotoPath { get; set; }
		public IEnumerable<IFormFile>? Photos { get; set; }
		public List<string>? PhotosPath { get; set; }
		public string? TextPrice { get; set; }



		public string NormalizePath(string oldPath)
		{
			if (string.IsNullOrEmpty(oldPath))
				return "";
			string newPath = oldPath.Remove(0, 8);
			return newPath;
		}
		public string NormalizePrice(uint oldPrice, char MoneySymbol)
		{
			string TextPrice = Convert.ToString(oldPrice);
			int count = 0;
			int startIndexProbel = 0;
			int countOfProbel = 0;
			while (Price > 0)
			{
				Price = Price / 10;
				count++;
			}
			if (count > 3)
			{
				countOfProbel = (count - 1) / 3;
				startIndexProbel = count - 3 * countOfProbel;
				for (int i = 0; i < countOfProbel; i++)
				{
					TextPrice = TextPrice.Insert(startIndexProbel + i * 3 + i, " ");
				}
			}
			TextPrice = TextPrice + " " + MoneySymbol;
			return TextPrice;
		}
	}
}
