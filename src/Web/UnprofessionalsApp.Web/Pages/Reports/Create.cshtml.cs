using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.DataServices;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.DataTransferObjects.Reoorts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Reports;

namespace UnprofessionalsApp.Web.Pages.Reports
{
	[Authorize]
    public class CreateModel : PageModel
    {
		private readonly IReportsService reportsService;
		private readonly IFirmsService firmsService;
		private readonly IMapper mapper;
		private readonly UserManager<UnprofessionalsAppUser> userManager;

		public CreateModel(IReportsService reportsService,
			IFirmsService firmsService,
			IMapper mapper,
			UserManager<UnprofessionalsAppUser> userManager)
		{
			this.reportsService = reportsService;
			this.firmsService = firmsService;
			this.mapper = mapper;
			this.userManager = userManager;
		}

		[BindProperty(SupportsGet = true)]
		public ReporCreateInputModel InputModel { get; set; }

		public IActionResult OnGet()
        {
			return this.Page();
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				var errors = this.ModelState.Values
					.SelectMany(t => t.Errors.Select(e => e.ErrorMessage));

				foreach (var error in errors)
				{
					this.ModelState.AddModelError(string.Empty, error);
				}

				return this.Page();
			}

			var reportDto = this.mapper.Map<ReportCreateDto>(this.InputModel);

			var currentUser = await this.userManager.GetUserAsync(this.User);

			reportDto.UserId = currentUser.Id;
			reportDto.FirmId = this.firmsService.GetParsedFirmId(InputModel.FirmId);

			//TODO: Validate that user cannot report himself
			if (reportDto.ReportedUserId == reportDto.UserId)
			{
				ModelState.AddModelError(string.Empty, "You cannot report yourself.");
				return this.Page();
			}

			var report = await this.reportsService.CreateReportAsync(reportDto);

			//TODO: Redirect to all submitted form (Report/Details)
			//return this.Redirect(string.Format("/Reports/Index"));
			return this.Redirect("/Home/Index");
		}
	}
}