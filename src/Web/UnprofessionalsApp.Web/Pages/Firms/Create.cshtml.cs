using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.InputModels.Firms;

namespace UnprofessionalsApp.Web.Pages.Firms
{
	[Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
		private readonly IFilesService filesService;
		private readonly IFirmsService firmsService;

		public CreateModel(IFilesService filesService, IFirmsService firmsService)
		{
			this.filesService = filesService;
			this.firmsService = firmsService;
		}

		[BindProperty]
		public CreateFirmInputModel InputModel { get; set; }

		public IActionResult OnGet()
        {
			return this.Page();
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				var errors = this.ModelState.SelectMany(x => x.Value.Errors.Select(e => e.ErrorMessage));
				foreach (var error in errors)
				{
					this.ModelState.AddModelError(string.Empty, error);
				}

				return this.Page();
			}
			var filePath = await this.filesService.ReadFile(this.InputModel.FirmFile);

			var readFile = this.filesService.ReadAllTextFromFile(filePath);
			if (readFile == null)
			{
				return this.NotFound();
			}

			XDocument xDoc;
			try
			{
				xDoc = this.filesService.ParseToXDocument(readFile);
			}
			catch (Exception)
			{
				return this.NotFound();
			}

			var deeds = await this.firmsService.GetAllDeedsFromXDoc(xDoc);

			if (xDoc == null || deeds == null)
			{
				return NotFound();
			}

			var firms = await this.firmsService.GetFirmsFromDeeds(deeds);

			var filteredFirms = await this.firmsService.RemoveDupicateFirms(firms);

			var statusCode = await this.firmsService.SeedFirmsIntoDbContext(filteredFirms);
			if (statusCode < GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				this.ModelState.AddModelError(string.Empty, GlobalConstants.DefaultNotSavedIntoDbContextMessage);

				return this.Page();
			}

			return this.Redirect("/Firms/Index");
		}
	}
}