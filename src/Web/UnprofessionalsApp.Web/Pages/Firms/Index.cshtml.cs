namespace UnprofessionalsApp.Web.Pages.Firms
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.RazorPages;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.ViewInputModels.InputModels.Firms;
	using UnprofessionalsApp.ViewInputModels.InputModels.Pagination;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

	public class IndexModel : PageModel
    {
		private readonly IFirmsService firmsService;

		public IndexModel(IFirmsService firmsService)
		{
			this.firmsService = firmsService;
		}
		
		////Data Validation: Validate me
		//[BindProperty(SupportsGet = true)]
		//public int CurrentPage { get; set; } = 1;

		//public int Count { get; set; }

		[BindProperty(SupportsGet = true)]
		public FirmPaginationModel Pagination { get; set; }

		////Data Validation: Validate me
		//[BindProperty(SupportsGet = true)]
		//public int PageSize { get; set; } = 10;

		////Data Validation: Validate me !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//[BindProperty(SupportsGet =true)]
		//public string SortBy { get; set; }

		////Data Validation: Validate me !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//[BindProperty(SupportsGet = true)]
		//public string Ordering { get; set; }

		////[BindProperty(SupportsGet = true)]
		//public int ResultPerPage { get; set; } = 10;

		//public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

		public IEnumerable<FirmViewModel> Data { get; set; }

		//TODO: Filter Request.
		public async Task<IActionResult> OnGetAsync()
        {
			this.Pagination.Count = await this.firmsService.GetAllFirmsCount();

			if (!ModelState.IsValid || !(0 < this.Pagination.CurrentPage &&
				this.Pagination.CurrentPage <= this.Pagination.TotalPages))
			{
				return NotFound();
			}

			this.Data = await this.firmsService.GetAllFirmsForCurrentPage(
				this.Pagination.CurrentPage, this.Pagination.PageSize, this.Pagination.SortBy, this.Pagination.Ordering);


			return this.Page();
        }
    }
}