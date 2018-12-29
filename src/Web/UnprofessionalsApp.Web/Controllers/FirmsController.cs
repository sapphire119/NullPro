namespace UnprofessionalsApp.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class FirmsController : Controller
	{
		public IActionResult Index()
		{
			return this.View();
		}

		public IActionResult Create()
		{
			return this.View();
		}


	}
}
