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

		[BindProperty(SupportsGet = true)]
		public int CurrentPage { get; set; } = 1;

		public int Count { get; set; }

		[BindProperty(SupportsGet = true)]
		public int PageSize { get; set; } = 10;

		[BindProperty(SupportsGet = true)]
		public int ResultPerPage { get; set; } = 10;

		public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

		public List<FirmViewModel> Data { get; set; }

		public void OnGetAsync()
        {
			this.Data = this.firmsService.GetAllFirmsForCurrentPage(CurrentPage, PageSize).ToList();
			this.Count = this.firmsService.GetAllFirmsCount();
        }
    }
}