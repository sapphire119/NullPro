namespace UnprofessionalsApp.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Users;

	public class AccountController : Controller
	{
		private readonly IUsersService usersService;

		public AccountController(IUsersService usersService)
		{
			this.usersService = usersService;
		}

		[Route("Account/Details/{userId?}")]
		public async Task<IActionResult> Details(int userId)
		{
			//TODO: Validate Details Action in AccountController
			var model = await this.usersService.GetUserByIdAsync<UserDetailsViewModel>(userId);
			return this.View(model);
		}
	}
}
