using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.DataTransferObjects.Reoorts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.DataServices
{
	public class ReportsService : IReportsService
	{
		private readonly IMapper mapper;
		private readonly IRepository<Report> reportsRepositroy;

		public ReportsService(IMapper mapper, IRepository<Report> reportsRepositroy)
		{
			this.mapper = mapper;
			this.reportsRepositroy = reportsRepositroy;
		}

		public async Task<Report> CreateReportAsync(ReportCreateDto reportDto)
		{
			var currentReport = this.mapper.Map<Report>(reportDto);

			await this.reportsRepositroy.AddAsync(currentReport);

			var statusCode = await this.reportsRepositroy.SaveChangesAsync();
			if (statusCode != GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				return null;
			}

			return currentReport;
		}
	}
}
