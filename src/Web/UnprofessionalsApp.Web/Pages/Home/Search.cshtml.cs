using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;
using UnprofessionalsApp.ViewInputModels.ViewModels.Home;
using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;
using UnprofessionalsApp.ViewInputModels.ViewModels.Users;

namespace UnprofessionalsApp.Web.Pages.Home
{
    public class SearchModel : PageModel
    {
		private IEnumerable<PostSearchViewModel> posts;
		private IEnumerable<UserSearchViewModel> users;
		private IEnumerable<CategorySearchViewModel> categories;
		private IEnumerable<TagPostDetailsViewModel> tags;
		private IEnumerable<FirmSearchViewModel> firms;
		private readonly IHomeService homeService;

		public SearchModel(IHomeService homeService)
		{
			this.homeService = homeService;
		}

		public int Counter { get; set; }

		//Validate
		[BindProperty(SupportsGet = true)]
		public string SearchResult { get; set; }

		public IEnumerable<PostSearchViewModel> Posts
		{
			get
			{
				return this.posts.Take(GlobalConstants.EntitiesPerPageLimit);
			}
			set
			{
				this.posts = value;
			}
		}

		public IEnumerable<UserSearchViewModel> Users
		{
			get
			{
				return this.users.Take(GlobalConstants.EntitiesPerPageLimit);
			}
			set
			{
				this.users = value;
			}
		}

		public IEnumerable<CategorySearchViewModel> Categories
		{
			get
			{
				return this.categories.Take(GlobalConstants.EntitiesPerPageLimit);
			}
			set
			{
				this.categories = value;
			}
		}

		public IEnumerable<TagPostDetailsViewModel> Tags
		{
			get
			{
				return this.tags.Take(GlobalConstants.EntitiesPerPageLimit);
			}
			set
			{
				this.tags = value;
			}
		}

		public IEnumerable<FirmSearchViewModel> Firms
		{
			get
			{
				return this.firms.Take(GlobalConstants.EntitiesPerPageLimit);
			}
			set
			{
				this.firms = value;
			}
		}

		public async Task<IActionResult> OnGetAsync()
        {
			this.Categories = await this.homeService.GetCategoriesWithMatchingResultAsync(this.SearchResult);
			this.Posts = await this.homeService.GetPostsWithMatchingResultAsync(this.SearchResult);
			this.Users = await this.homeService.GetUsersWithMatchingResultAsync(this.SearchResult);
			this.Tags = await this.homeService.GetTagsWithMatchingResultAsync(this.SearchResult);
			this.Firms = await this.homeService.GetFirmsWithMatchingResultAsync(this.SearchResult);

			return this.Page();
		}
    }
}