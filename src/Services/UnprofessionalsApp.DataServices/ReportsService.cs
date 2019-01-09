using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.DataTransferObjects.Reoorts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Reports;
using UnprofessionalsApp.ViewInputModels.ViewModels.Reports;

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

		public async Task<int> DeleteComment(ReportEntityInputModel inputModel)
		{
			var currentReport = this.reportsRepositroy.All()
					.Where(r => r.Id == inputModel.Id).FirstOrDefault();

			if (currentReport == null)
			{
				return default(int);
			}

			currentReport.IsDeleted = true;

			var statusCode = await this.reportsRepositroy.SaveChangesAsync();

			return statusCode;
		}

		public Task<TModel> GetReportByIdAsync<TModel>(int reportId)
		{
			var reportTask = Task.Run(() =>
			{
				var source = this.reportsRepositroy.All()
				.Where(r => r.Id == reportId);

				var destination = this.mapper.ProjectTo<TModel>(source);

				var result = destination.FirstOrDefault();

				return result;
			});

			return reportTask;
		}

		public Task<int> GetReportsCount()
		{
			var result = Task.Run(() => this.reportsRepositroy.All().Count());
			return result;
		}

		public Task<IEnumerable<TViewModel>> GetReportsForCurrentPage<TViewModel>(int currentPage, int pageSize, string orderByParam, string ordering)
		{
			var firmsForCurrentPage = Task.Run(() =>
			{
				var source = this.reportsRepositroy.All()
				.Where(r => r.IsDeleted != true)// Вече е IQueryable, но за всеки случай
				.OrderBy(string.Concat(orderByParam, $" {ordering}"))
				.Skip((currentPage - 1) * pageSize)
				.Take(pageSize);
				//.To<IEnumerable<FirmViewModel>>();

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination as IEnumerable<TViewModel>;

				return result;
			});

			return firmsForCurrentPage;
		}
	}
}
