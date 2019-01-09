using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.Web.Areas.Identity.Pages.Posts
{
	[Authorize]
	public class IndexModel : PageModel
    {
		private readonly IPostsService postsService;
		private readonly UserManager<UnprofessionalsAppUser> userManager;

		public IndexModel(IPostsService postsService,
			UserManager<UnprofessionalsAppUser> userManager)
		{
			this.postsService = postsService;
			this.userManager = userManager;
		}

		public IEnumerable<PostEntityDetailsViewModel> Data { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			var currentUser = await this.userManager.GetUserAsync(this.User);

			this.Data = await this.postsService
				.GetPostsByUsernameAsync<PostEntityDetailsViewModel>(currentUser);

			return this.Page();
		}
	}
}