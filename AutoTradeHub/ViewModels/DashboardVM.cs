using AutoTradeHub.Models;

namespace AutoTradeHub.ViewModels
{
	public class DashboardVM
	{
        public DashboardVM() { }
        public DashboardVM(AppUser user, List<CarVM> cars)
        {
            UserCars = cars;
            AppUser = user;
        }
        public List<CarVM> UserCars { get; set; }
		public AppUser AppUser { get; set; }
	}
}
