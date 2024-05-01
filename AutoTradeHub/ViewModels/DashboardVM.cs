using AutoTradeHub.Models;

namespace AutoTradeHub.ViewModels
{
	public class DashboardVM
	{
        public DashboardVM() { }
        public DashboardVM(AppUser user, List<Car> cars)
        {
            UserCars = cars;
            AppUser = user;
        }
        public List<Car> UserCars { get; set; }
		public AppUser AppUser { get; set; }
	}
}
