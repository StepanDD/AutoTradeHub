using Microsoft.AspNetCore.Identity;

namespace AutoTradeHub.Models
{
	public class AppUser : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set;}
		public ICollection<Favorites> Favorites { get; set; }
	}
}
