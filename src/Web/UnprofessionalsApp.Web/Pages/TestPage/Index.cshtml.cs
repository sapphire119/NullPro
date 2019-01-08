using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.InputModels.Firms;

namespace UnprofessionalsApp.Web.Pages.TestPage
{
    public class IndexModel : PageModel
    {
		private readonly IFilesService filesService;
		private readonly IFirmsService firmsService;

		public IndexModel(IFilesService filesService, IFirmsService firmsService)
		{
			this.filesService = filesService;
			this.firmsService = firmsService;
		}

		[BindProperty]
		public CreateFirmInputModel InputModel { get; set; }

		public void OnGet()
        {
        }

		public async Task<IActionResult> OnPostAsync()
		{
			var filePath = await this.filesService.ReadFile(this.InputModel.FirmFile);

			var readFile = this.filesService.ReadAllTextFromFile(filePath);

			var xDoc = this.filesService.ParseToXDocument(readFile);

			var deeds = await this.firmsService.GetAllDeedsFromXDoc(xDoc);

			if (xDoc == null || deeds == null)
			{
				return NotFound();
			}

			var firms = await this.firmsService.GetFirmsFromDeeds(deeds);

			var filteredFirms = await this.firmsService.RemoveDupicateFirms(firms);

			var statusCode = await this.firmsService.SeedFirmsIntoDbContext(filteredFirms);
			if (statusCode != GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				return NotFound();
			}

			return this.Redirect("/Firms/Index");
		}
    }
}