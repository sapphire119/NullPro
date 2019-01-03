using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.Web.Pages.Posts
{
    public class IndexModel : PageModel
    {
		private readonly IPostsService postsService;

		public IndexModel(IPostsService postsService)
		{
			this.postsService = postsService;
		}

		//Data Validation: Validate me
		[BindProperty(SupportsGet = true)]
		public int CurrentPage { get; set; } = 1;

		public int Count { get; set; }

		//Data Validation: Validate me
		[BindProperty(SupportsGet = true)]
		public int PageSize { get; set; } = 5;

		//Data Validation: Validate me !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		[BindProperty(SupportsGet = true)]
		public string SortBy { get; set; }

		//Data Validation: Validate me !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		[BindProperty(SupportsGet = true)]
		public string Ordering { get; set; }

		public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

		public IEnumerable<PostViewModel> Data { get; set; }

		public async Task<IActionResult> OnGet()
        {
			this.Data = await this.postsService.GetAllPostsForCurrentPage(
				this.CurrentPage, this.PageSize, this.SortBy, this.Ordering);

			this.Count = await this.postsService.GetAllPostsCount();

			return this.Page();
        }
    }
}