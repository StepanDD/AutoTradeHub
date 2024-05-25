using AutoTradeHub.Models;

namespace AutoTradeHub.ViewModels
{
	public class DashboardVM
	{
        public DashboardVM() { }
        public DashboardVM(AppUser user, List<CarVM> cars, UserVM userVM)
        {
            UserCars = cars;
            AppUser = user;
            UserVM = userVM;
        }
        public List<CarVM>? UserCars { get; set; }
		public AppUser? AppUser { get; set; }
        public UserVM? UserVM { get; set; }
	}
}
