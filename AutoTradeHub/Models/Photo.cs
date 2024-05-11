using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoTradeHub.Models
{
	public class Photo
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string? Path { get; set; }

		[ForeignKey("cars")]
		public int carId { get; set; }
		public Car? Car { get; set; }
	}
}
