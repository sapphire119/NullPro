using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnprofessionalsApp.DataTransferObjects.Reoorts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IReportsService
	{
		Task<Report> CreateReportAsync(ReportCreateDto reportDto);
	}
}
