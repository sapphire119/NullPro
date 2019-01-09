using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnprofessionalsApp.DataTransferObjects.Reoorts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Reports;
using UnprofessionalsApp.ViewInputModels.ViewModels.Reports;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IReportsService
	{
		Task<Report> CreateReportAsync(ReportCreateDto reportDto);

		Task<int> GetReportsCount();

		Task<IEnumerable<TViewModel>> GetReportsForCurrentPage<TViewModel>(
			int currentPage, int pageSize, string sortBy, string ordering);

		Task<TModel> GetReportByIdAsync<TModel>(int reportId);

		Task<int> DeleteComment(ReportEntityInputModel currentReport);
	}
}
