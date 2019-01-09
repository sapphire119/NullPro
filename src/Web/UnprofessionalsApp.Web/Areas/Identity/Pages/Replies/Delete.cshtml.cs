using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Replies;

namespace UnprofessionalsApp.Web.Areas.Identity.Pages.Replies
{
    public class DeleteModel : PageModel
    {
		private readonly UserManager<UnprofessionalsAppUser> userManager;
		private readonly IRepliesService repliesService;

		public DeleteModel(UserManager<UnprofessionalsAppUser> userManager,
			IRepliesService repliesService)
		{
			this.userManager = userManager;
			this.repliesService = repliesService;
		}


		public ReplyEntityInputModel Data { get; set; }

		public async Task<IActionResult> OnGetAsync(int replyId)
		{
			this.Data = await this.repliesService
				.GetReplyByIdAsync<ReplyEntityInputModel>(replyId);

			if (this.Data == null)
			{
				return this.NotFound();
			}

			return this.Page();
		}

		public async Task<IActionResult> OnPostAsync(int replyId)
		{
			var currentReply = await this.repliesService
				.GetReplyByIdAsync<ReplyEntityInputModel>(replyId);

			if (currentReply == null)
			{
				return this.NotFound();
			}

			int status = await this.repliesService.DeleteReply(currentReply);
			if (status < GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				return this.NotFound();
			}

			return this.LocalRedirect("/Posts/Index");
		}
	}
}