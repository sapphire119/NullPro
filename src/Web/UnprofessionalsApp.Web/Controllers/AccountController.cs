namespace UnprofessionalsApp.Web.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Users;

	public class AccountController : Controller
	{
		private readonly IUsersService usersService;
		private readonly UserManager<UnprofessionalsAppUser> userManager;

		public AccountController(IUsersService usersService, UserManager<UnprofessionalsAppUser> userManager)
		{
			this.usersService = usersService;
			this.userManager = userManager;
		}

		
		public async Task<IActionResult> Index()
		{
			IEnumerable<UserViewModel> model = await this.usersService.GetAllUsers<UserViewModel>();

			return this.View(model);
		}

		[Route("Account/Details/{userId?}")]
		public async Task<IActionResult> Details(int userId)
		{
			var currentuser = await this.userManager.GetUserAsync(this.User);
			if (currentuser != null && currentuser.Id == userId)
			{
				return this.Redirect("/Identity/Account/Manage");
			}

			//TODO: Validate Details Action in AccountController
			var model = await this.usersService.GetUserByIdAsync<UserDetailsViewModel>(userId);
			return this.View(model);
		}
	}
}
