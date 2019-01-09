using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Reports;

namespace UnprofessionalsApp.Web.Areas.Administrator.Pages.Reports
{
	[Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
		private readonly UserManager<UnprofessionalsAppUser> userManager;
		private readonly IReportsService reportsService;

		public DeleteModel(UserManager<UnprofessionalsAppUser> userManager,
			IReportsService reportsService)
		{
			this.userManager = userManager;
			this.reportsService = reportsService;
		}


		public ReportEntityInputModel Data { get; set; }

		public async Task<IActionResult> OnGetAsync(int reportId)
		{
			this.Data = await this.reportsService
				.GetReportByIdAsync<ReportEntityInputModel>(reportId);

			if (this.Data == null)
			{
				return this.NotFound();
			}

			return this.Page();
		}

		public async Task<IActionResult> OnPostAsync(int reportId)
		{
			var currentReport = await this.reportsService
				.GetReportByIdAsync<ReportEntityInputModel>(reportId);

			if (currentReport == null)
			{
				return this.NotFound();
			}

			int status = await this.reportsService.DeleteComment(currentReport);
			if (status < GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				return this.NotFound();
			}

			return this.RedirectToPage("/reports/index");
		}
	}
}