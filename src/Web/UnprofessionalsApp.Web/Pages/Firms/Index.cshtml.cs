namespace UnprofessionalsApp.Web.Pages.Firms
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.RazorPages;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

	public class IndexModel : PageModel
    {
		private readonly IFirmsService firmsService;

		public IndexModel(IFirmsService firmsService)
		{
			this.firmsService = firmsService;
		}
		
		//Data Validation: Validate me
		[BindProperty(SupportsGet = true)]
		public int CurrentPage { get; set; } = 1;

		public int Count { get; set; }

		//Data Validation: Validate me
		[BindProperty(SupportsGet = true)]
		public int PageSize { get; set; } = 10;

		//Data Validation: Validate me !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		[BindProperty(SupportsGet =true)]
		public string SortBy { get; set; }

		//Data Validation: Validate me !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		[BindProperty(SupportsGet = true)]
		public string Ordering { get; set; }

		//[BindProperty(SupportsGet = true)]
		public int ResultPerPage { get; set; } = 10;

		public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

		public IEnumerable<FirmViewModel> Data { get; set; }

		[BindProperty(SupportsGet = true)]
		public bool DateOfRegistration { get; set; }

		public async Task<IActionResult> OnGetAsync()
        {
			this.Data = await this.firmsService.GetAllFirmsForCurrentPage(
				this.CurrentPage, this.PageSize, this.SortBy, this.Ordering);

			this.Count = await this.firmsService.GetAllFirmsCount();

			return this.Page();
        }
    }
}