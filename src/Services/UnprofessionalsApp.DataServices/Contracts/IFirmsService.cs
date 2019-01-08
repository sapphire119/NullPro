using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnprofessionalsApp.ViewInputModels.ViewModels;
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IFirmsService
	{
		//IEnumerable<FirmViewModel> GetAllFirmsForCurrentPage(int pageId, int pageSize);

		Task<IEnumerable<FirmViewModel>> GetAllFirmsForCurrentPage(int pageId, int pageSize, string orderByParam, string ordering);
		
		Task<TViewModel> GetFirmById<TViewModel>(Guid id);

		Task<TViewModel> GetFirmByUniqueId<TViewModel>(string uniqueFirmdId);

		Guid GetParsedFirmId(string id);

		Task<int> GetAllFirmsCount();
	}
}
