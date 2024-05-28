using AutoTradeHub.Data.Enum;
using AutoTradeHub.Models;
using System.ComponentModel.DataAnnotations;

namespace AutoTradeHub.ViewModels
{
	public class CarSearchVM
	{
		public List<CarVM>? Cars { get; set; } = new List<CarVM>();

		// Марка
		public int MarkaId { get; set; }

		// Модель
		public int ModelId { get; set; }

		// Поколение
		public int GenerationId { get; set; }

		// Цвет
		public int ColorId { get; set; }

		// Цена
		public uint MinPrice { get; set; }
		public uint MaxPrice { get; set; }

		// Год
		public ushort MinYear { get; set; }
		public ushort MaxYear { get; set; }

		// Пробег
		public uint MaxProbeg { get; set; }
    }
}
