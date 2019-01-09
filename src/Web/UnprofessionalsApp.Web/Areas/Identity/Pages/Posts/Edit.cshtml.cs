using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Posts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.Web.Areas.Identity.Pages.Posts
{
	[Authorize]
    public class EditModel : PageModel
    {
		private readonly UserManager<UnprofessionalsAppUser> userManager;
		private readonly IPostsService postsService;

		public EditModel(UserManager<UnprofessionalsAppUser> userManager, 
			IPostsService postsService)
		{
			this.userManager = userManager;
			this.postsService = postsService;
		}
		
		[BindProperty]
		public PostEntityDetailsInputModel InputModel { get; set; }

		public async Task<IActionResult> OnGetAsync(int postId)
        {
			this.InputModel = await this.postsService
				.GetPostByIdAsync<PostEntityDetailsInputModel>(postId);

			return this.Page();
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.SelectMany(e => e.Value.Errors);
				foreach (var error in errors)
				{
					ModelState.AddModelError(string.Empty, error.ErrorMessage);
				}

				return this.Page();
			}

			var status = await this.postsService.EditPost(this.InputModel);
			if (status != GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				return this.NotFound();
			}

			return this.RedirectToPage("/posts/index");
		}
	}
}