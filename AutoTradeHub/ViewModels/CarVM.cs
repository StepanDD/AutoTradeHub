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
		}
		public int Id { get; set; }

		// Марка
		public int MarkaId { get; set; }
		public Marka? Marka { get; set; }

		// Модель
		public int ModelId { get; set; }
		public Model? Model { get; set; }

		// Поколение
		public int GenerationId { get; set; }
		public Generation? Generation { get; set; }

		// Цвет
		public int ColorId { get; set; }
		public Color? Color { get; set; }

		// Цена
		[Required(ErrorMessage = "Введите стоимость!")]
		public uint Price { get; set; }

		// Объём двигателя
		[Required(ErrorMessage = "Введите объём двигателя!")]
		public float EngineVolume { get; set; }

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
	}
}
