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
using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;

namespace UnprofessionalsApp.Web.Areas.Identity.Pages.Comments
{
	[Authorize]
	public class IndexModel : PageModel
    {
		private readonly ICommentsService commentsService;
		private readonly UserManager<UnprofessionalsAppUser> userManager;

		public IndexModel(ICommentsService commentsService,
			UserManager<UnprofessionalsAppUser> userManager)
		{
			this.commentsService = commentsService;
			this.userManager = userManager;
		}

		public IEnumerable<CommentUserProfileViewModel> Data { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			var currentUser = await this.userManager.GetUserAsync(this.User);

			this.Data = await this.commentsService.
				GetCommentsForCurrentUser<CommentUserProfileViewModel>(currentUser);

			return this.Page();
		}
	}
}