using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.Pagination.Reports;
using UnprofessionalsApp.ViewInputModels.ViewModels.Reports;

namespace UnprofessionalsApp.Web.Areas.Administrator.Pages.Reports
{
	[Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
		private readonly IReportsService reportsService;

		public IndexModel(IReportsService reportsService)
		{
			this.reportsService = reportsService;
		}

		[BindProperty(SupportsGet = true)]
		public ReportsPaginationModel Pagination { get; set; }

		public IEnumerable<ReportViewModel> Data { get; set; }

		public async Task<IActionResult> OnGetAsync()
        {
			this.Pagination.Count = await this.reportsService.GetReportsCount();

			if (!this.ModelState.IsValid || !(0 < this.Pagination.CurrentPage &&
				this.Pagination.CurrentPage <= this.Pagination.TotalPages))
			{
				return NotFound();
			}

			this.Data = await this.reportsService
				.GetReportsForCurrentPage<ReportViewModel>(
				this.Pagination.CurrentPage, this.Pagination.PageSize, this.Pagination.SortBy, this.Pagination.Ordering);

			return this.Page();
        }
    }
}