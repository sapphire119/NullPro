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

namespace UnprofessionalsApp.Web.Areas.Identity.Pages.Posts
{
	[Authorize]
    public class DeleteModel : PageModel
    {
		private readonly UserManager<UnprofessionalsAppUser> userManager;
		private readonly IPostsService postsService;

		public DeleteModel(UserManager<UnprofessionalsAppUser> userManager,
			IPostsService postsService)
		{
			this.userManager = userManager;
			this.postsService = postsService;
		}

		
		public PostEntityDetailsInputModel Data { get; set; }

		public async Task<IActionResult> OnGetAsync(int postId)
		{
			this.Data = await this.postsService
				.GetPostByIdAsync<PostEntityDetailsInputModel>(postId);

			if (this.Data == null)
			{
				return this.NotFound();
			}

			return this.Page();
		}

		public async Task<IActionResult> OnPostAsync(int postId)
		{
			var currentPost = await this.postsService
				.GetPostByIdAsync<PostEntityDetailsInputModel>(postId);

			if (currentPost == null)
			{
				return this.NotFound();
			}

			var status = await this.postsService.DeletePost(currentPost);
			if (status < GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				return this.NotFound();
			}

			return this.RedirectToPage("/posts/index");
		}
	}
}