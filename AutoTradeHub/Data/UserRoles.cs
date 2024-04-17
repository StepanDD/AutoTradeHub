namespace AutoTradeHub.Data
{
	public static class UserRoles
	{
		public const string Admin = "Admin";
		public const string Manager = "Manager";
		public const string User = "User";

		public static List<string> getUserRolesArray ()
		{
			return new List<string>() { Admin, Manager, User };
		}
	}
}
