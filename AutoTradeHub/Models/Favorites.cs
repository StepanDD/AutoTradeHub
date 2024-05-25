using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTradeHub.Models
{
	public class Favorites
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int CarId { get; set; }
		public Car Car { get; set; }
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public Favorites() { }
        public Favorites(int carId, string userId)
        {
            CarId = carId;
			AppUserId = userId;
        }
    }
}
