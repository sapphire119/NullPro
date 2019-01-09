using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.Pagination.Reports;
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

		[BindProperty(SupportsGet = true)]
		public PostPaginationModel Pagination { get; set; }

										   //Data Validation: Validate me
		//[BindProperty(SupportsGet = true)]
		//public int CurrentPage { get; set; } = 1;

		//public int Count { get; set; }

		////Data Validation: Validate me
		//[BindProperty(SupportsGet = true)]
		//public int PageSize { get; set; } = 5;

		////Data Validation: Validate me !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//[BindProperty(SupportsGet = true)]
		//public string SortBy { get; set; }

		////Data Validation: Validate me !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//[BindProperty(SupportsGet = true)]
		//public string Ordering { get; set; }

		//public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

		public IEnumerable<PostViewModel> Data { get; set; }

		public async Task<IActionResult> OnGetAsync()  
        {
			this.Pagination.Count = await this.postsService.GetAllPostsCount();

			if (!ModelState.IsValid || !(0 < this.Pagination.CurrentPage &&
				this.Pagination.CurrentPage <= this.Pagination.TotalPages))
			{
				return NotFound();
			}

			this.Data = await this.postsService.GetAllPostsForCurrentPage(
				this.Pagination.CurrentPage, this.Pagination.PageSize, this.Pagination.SortBy, this.Pagination.Ordering);

			return this.Page();
        }
    }
}