using AutoTradeHub.Models;

namespace AutoTradeHub.ViewModels
{
    public class AdminDashboardVM
    {
        public UserVM? UserVM { get; set; }
        public List<AppUser>? AppUsers { get; set; }
        public List<Color>? Colors { get; set; }
        public string? NewColor { get; set; }
        public AdminDashboardVM() { }
        public AdminDashboardVM(UserVM userVM, List<AppUser> appUsers, List<Color> colors)
        {
            UserVM = userVM;
            AppUsers = appUsers;
            Colors = colors;
        }
    }
}
