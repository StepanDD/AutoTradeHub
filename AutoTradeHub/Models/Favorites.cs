using System.ComponentModel.DataAnnotations;

namespace AutoTradeHub.Models
{
	public class Favorites
	{
		[Key]
		public int Id { get; set; }
		public int CarId { get; set; }
		public Car Car { get; set; }
		public AppUser AppUser { get; set; }
	}
}
