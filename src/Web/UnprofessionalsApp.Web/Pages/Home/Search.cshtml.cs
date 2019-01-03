using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;
using UnprofessionalsApp.ViewInputModels.ViewModels.Home;
using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;
using UnprofessionalsApp.ViewInputModels.ViewModels.Users;

namespace UnprofessionalsApp.Web.Pages.Home
{
    public class SearchModel : PageModel
    {
		private readonly IHomeService homeService;

		public SearchModel(IHomeService homeService)
		{
			this.homeService = homeService;
		}

		public int Counter { get; set; }

		//Validate
		[BindProperty(SupportsGet = true)]
		public string SearchResult { get; set; }

		public IEnumerable<PostSearchViewModel> Posts { get; set; }

		public IEnumerable<UserSearchViewModel> Users { get; set; }

		public IEnumerable<CategoryViewModel> Categories { get; set; }

		public IEnumerable<TagViewModel> Tags { get; set; }

		public async Task<IActionResult> OnGetAsync()
        {
			this.Categories = await this.homeService.GetCategoriesWithMatchingResultAsync(this.SearchResult);
			this.Posts = await this.homeService.GetPostsWithMatchingResultAsync(this.SearchResult);
			this.Users = await this.homeService.GetUsersWithMatchingResultAsync(this.SearchResult);
			this.Tags = await this.homeService.GetTagsWithMatchingResultAsync(this.SearchResult);

			return this.Page();
		}
    }
}