using AutoTradeHub.Models;

namespace AutoTradeHub.ViewModels
{
    public class AdminDashboardVM
    {
        public UserVM? UserVM { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public AdminDashboardVM() { }
        public AdminDashboardVM(UserVM userVM, List<AppUser> appUsers)
        {
            UserVM = userVM;
            AppUsers = appUsers;
        }
    }
}
