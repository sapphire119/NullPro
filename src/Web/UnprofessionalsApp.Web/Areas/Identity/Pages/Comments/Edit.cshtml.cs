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
    public class EditModel : PageModel
    {
		private readonly UserManager<UnprofessionalsAppUser> userManager;
		private readonly ICommentsService commentsService;

		public EditModel(UserManager<UnprofessionalsAppUser> userManager,
			ICommentsService commentsService)
		{
			this.userManager = userManager;
			this.commentsService = commentsService;
		}

		[BindProperty]
		public CommentEntityInputModel InputModel { get; set; }

		public async Task<IActionResult> OnGetAsync(int commentId)
		{
			this.InputModel = await this.commentsService
				.GetCommentIdAsync<CommentEntityInputModel>(commentId);

			if (this.InputModel == null)
			{
				return NotFound();
			}

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

			int status = await this.commentsService.EditComment(this.InputModel);
			if (status != GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				return this.NotFound();
			}

			return this.RedirectToPage("/comments/index");
		}
	}
}