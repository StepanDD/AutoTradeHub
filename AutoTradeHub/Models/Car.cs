﻿using AutoTradeHub.Data.Enum;
using AutoTradeHub.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTradeHub.Models
{
	public class Car
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		// Марка

		[ForeignKey("marks")]
		public int MarkaId { get; set; }
		public Marka? Marka { get; set; }

		// Модель

		[ForeignKey("models")]
		public int ModelId { get; set; }
		public Model? Model { get; set; }

		// Поколение

		[ForeignKey("generations")]
		public int GenerationId { get; set; }
		public Generation? Generation { get; set; }

		// Цвет

		[ForeignKey("colors")]
		public int ColorId { get; set; }
		public Color? Color { get; set; }

		// Цена
		public uint Price { get; set; }

		// Объём двигателя
		public double EngineVolume { get; set; }

		// Мощность двигателя
		public ushort EnginePower { get; set; }

		// Расположение руля
		public SteeringWheel SteeringWheel { get; set; }

		// КПП
		public GearBox Gearbox { get; set; }

		// Описание
		public string? Description { get; set; }

		// Год
		public ushort Year { get; set; }

		// Тип двигателя
		public EngineType EngineType { get; set; }

		// Привод
		public Privod Privod { get; set; }

		// Тип кузова
		public BodyType BodyType { get; set; }

		// Пробег
		public uint Probeg { get; set; }

		// Собственник
		[ForeignKey("AppUser")]
		public string AppUserId { get; set; }
		public AppUser? AppUser { get; set; }

		// Добавившие в избранное
		public ICollection<Favorites>? Favorites { get; set; }

		// Главная фотография
		public string Path { get; set; }

		public Car() { }
        public Car(CarVM carVM, int id = 0)
		{
			this.Id = id;
			this.MarkaId = carVM.MarkaId;
			this.Marka = carVM.Marka;
			this.ModelId = carVM.ModelId;
			this.Model = carVM.Model;
			this.GenerationId = carVM.GenerationId;
			this.Generation = carVM.Generation;
			this.ColorId = carVM.ColorId;
			this.Color = carVM.Color;
			this.Price = carVM.Price;
			this.EngineVolume = carVM.EngineVolume;
			this.EnginePower = carVM.EnginePower;
			this.SteeringWheel = carVM.SteeringWheel;
			this.Gearbox = carVM.Gearbox;
			this.Description = carVM.Description;
			this.Year = carVM.Year;
			this.EngineType = carVM.EngineType;
			this.Privod = carVM.Privod;
			this.BodyType = carVM.BodyType;
			this.Probeg = carVM.Probeg;
			this.AppUser = carVM.AppUser;
			this.AppUserId = carVM.AppUserId;
			this.Path = carVM.Path;
		}
		public static Car CreateRandomCar()
		{
			Random random = new Random();
			Car createdCar = new Car();
			createdCar.MarkaId = random.Next(1, 5);
			createdCar.ModelId = random.Next(1, 5);
			createdCar.GenerationId = random.Next(1, 5);
			createdCar.ColorId = 5;
			createdCar.Price = Convert.ToUInt32(random.Next(1, 2000000));
			createdCar.EngineVolume = random.Next(1, 10);
			createdCar.EnginePower = Convert.ToUInt16(random.Next(1, 1000));
			createdCar.SteeringWheel = SteeringWheel.Левый;
			createdCar.Gearbox = GearBox.Автомат;
			createdCar.Description = "типа описание";
			createdCar.Year = Convert.ToUInt16(random.Next(1990, 2020));
			createdCar.EngineType = EngineType.Бензиновый;
			createdCar.Privod = Privod.Передний;
			createdCar.BodyType = BodyType.Седан;
			createdCar.Probeg = Convert.ToUInt32(random.Next(100, 100000));
			createdCar.Path = "wwwroot/img/DefaultCar.png";
			return createdCar;
		}
	}
}
