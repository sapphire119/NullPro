using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;

namespace UnprofessionalsApp.Web.Pages.Tags
{
    public class IndexModel : PageModel
    {
		private readonly ITagsService tagsService;

		public IndexModel(ITagsService tagsService)
		{
			this.tagsService = tagsService;
		}

		public string LettersToPrint { get; set; }

		public IEnumerable<TagPostDetailsViewModel> Tags { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			this.Tags = await this.tagsService.GetAllTags<TagPostDetailsViewModel>();

			this.LettersToPrint = await this.tagsService.GetExistingStartingLettersForAllCategories();

			return this.Page();
		}
	}
}