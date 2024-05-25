using AutoTradeHub.Models;
using Microsoft.AspNetCore.Identity;

namespace AutoTradeHub.ViewModels
{
	public class UserVM : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? PhotoPath { get; set; }
		public IFormFile? Photo { get; set; }
		public UserVM() { }
        public UserVM(AppUser user)
        {
            FirstName = user.FirstName;
			LastName = user.LastName;
			PhotoPath = user.PhotoPath;
			PhoneNumber = user.PhoneNumber;
			Id = user.Id;
			Email = user.Email;
        }
		public string NormalizePath(string oldPath)
		{
			try
			{
				if (string.IsNullOrEmpty(oldPath))
					return "";
				string newPath = oldPath.Remove(0, 8);
				return newPath;
			}
			catch
			{
				return "";
			}
		}
	}
}
