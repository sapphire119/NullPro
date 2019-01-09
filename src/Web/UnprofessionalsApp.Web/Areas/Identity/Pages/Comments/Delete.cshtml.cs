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
using UnprofessionalsApp.ViewInputModels.InputModels.Comments;

namespace UnprofessionalsApp.Web.Areas.Identity.Pages.Comments
{
	[Authorize]
    public class DeleteModel : PageModel
    {
		private readonly UserManager<UnprofessionalsAppUser> userManager;
		private readonly ICommentsService commentsService;

		public DeleteModel(UserManager<UnprofessionalsAppUser> userManager,
			ICommentsService commentsService)
		{
			this.userManager = userManager;
			this.commentsService = commentsService;
		}


		public CommentEntityInputModel Data { get; set; }

		public async Task<IActionResult> OnGetAsync(int commentId)
		{
			this.Data = await this.commentsService
				.GetCommentIdAsync<CommentEntityInputModel>(commentId);

			if (this.Data == null)
			{
				return this.NotFound();
			}

			return this.Page();
		}

		public async Task<IActionResult> OnPostAsync(int commentId)
		{
			var currentComment = await this.commentsService
				.GetCommentIdAsync<CommentEntityInputModel>(commentId);

			if (currentComment == null)
			{
				return this.NotFound();
			}

			int status = await this.commentsService.DeleteComment(currentComment);
			if (status < GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				return this.NotFound();
			}

			return this.RedirectToPage("/posts/index");
		}
	}
}