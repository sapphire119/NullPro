namespace UnprofessionalsApp.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

	public class FirmsController : Controller
	{
		private readonly IFirmsService firmsService;

		public FirmsController(IFirmsService firmsService)
		{
			this.firmsService = firmsService;
		}

		public async Task<IActionResult> Details(string firmId)
		{
			var firmIdParsed = this.firmsService.GetParsedFirmId(firmId);
			if (firmIdParsed == null)
			{
				return NotFound();
			}

			var model = await this.firmsService.GetFirmById<FirmDetailsViewModel>(firmIdParsed.Value);

			return this.View(model);
		}
	}
}
