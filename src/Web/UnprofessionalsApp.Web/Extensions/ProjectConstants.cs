namespace UnprofessionalsApp.Web.Extensions
{
	public static class ProjectConstants
	{
		public static readonly string[] ApprovedRoles = { "Admin", "Manager", "User" };

		public const string AdminRole = "Admin";
		
		public const string ManagerRole = "Manager";
		
		public const string UserRole = "User";

		public const string CannotCreateDbMessage = @"An error occurred creating the DB.";
	}
}
