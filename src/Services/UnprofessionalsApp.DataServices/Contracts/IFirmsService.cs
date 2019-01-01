using System.Collections.Generic;
using System.Threading.Tasks;
using UnprofessionalsApp.ViewInputModels.ViewModels;
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IFirmsService
	{
		IEnumerable<FirmViewModel> GetAllFirmsForCurrentPage(int pageId, int pageSize);
		
		TViewModel GetFirmById<TViewModel>(int id);

		int GetAllFirmsCount();
	}
}
