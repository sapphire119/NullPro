using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;
using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;

namespace UnprofessionalsApp.Web.Pages.Tags
{
    public class DetailsModel : PageModel
    {
		private readonly ITagsService tagsService;

		public DetailsModel(ITagsService tagsService)
		{
			this.tagsService = tagsService;
		}

		//Validate Me
		[BindProperty(SupportsGet = true)]
		public int TagId { get; set; }

		[BindProperty(SupportsGet = true)]
		public string CategoryName { get; set; }

		public bool AreThereAnyPostsForTag { get; set; }

		public IEnumerable<PostByCategoryViewModel> RelatedPosts { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			this.AreThereAnyPostsForTag =
				await this.tagsService.AreThereAnyPostsWithTag(this.TagId);

			if (this.AreThereAnyPostsForTag)
			{
				this.RelatedPosts = await this.tagsService
					.GetAllRealtedPosts<PostByCategoryViewModel>(this.TagId);

				return Page();
			}

			//TODO: Write a Display Error message for lack of posts on details tags page.
			return this.RedirectToPage("/tags/index");
		}
	}
}