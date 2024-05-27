using AutoTradeHub.Models;

namespace AutoTradeHub.ViewModels
{
	public class AdminDashboardVM
	{
		public UserVM? UserVM { get; set; }
		public List<AppUser>? AppUsers { get; set; }
		public List<Color>? Colors { get; set; }
		public List<Marka>? Marks { get; set; }
		public IEnumerable<Model>? Models { get; set; }
		public IEnumerable<Generation>? Generations { get; set; }
		public string? NewColor { get; set; }
		public string? NewMarka { get; set; }
		public string? NewModel { get; set; }
		public int NewModelMarkaFK { get; set; }
		public string? NewModelMarkaName { get; set; }
		public string? NewGeneration { get; set; }
		public int NewGenerationModelFK { get; set; }
		public string? NewGenerationModelName { get; set; }
		public AdminDashboardVM() { }
		public AdminDashboardVM(UserVM userVM, List<AppUser> appUsers, List<Color> colors,
			List<Marka> marks)
		{
			UserVM = userVM;
			AppUsers = appUsers;
			Colors = colors;
			Marks = marks;
		}
	}
}
