using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.DataTransferObjects.Reoorts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Reports;

namespace UnprofessionalsApp.Web.Controllers
{
	public class ReportsController : Controller
	{
		private readonly IReportsService reportsService;
		private readonly IMapper mapper;
		private readonly UserManager<UnprofessionalsAppUser> userManager;

		public ReportsController(IReportsService reportsService,
			IMapper mapper, 
			UserManager<UnprofessionalsAppUser> userManager)
		{
			this.reportsService = reportsService;
			this.mapper = mapper;
			this.userManager = userManager;
		}

	    public IActionResult Index()
		{
			return this.View();
		}
	}
}
