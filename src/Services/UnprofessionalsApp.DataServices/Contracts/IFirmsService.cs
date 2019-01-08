using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnprofessionalsApp.Models;
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

		Guid? GetParsedFirmId(string id);

		Task<int> GetAllFirmsCount();

		Task<XElement[]> GetAllDeedsFromXDoc(XDocument xDoc);

		Task<IEnumerable<Firm>> GetFirmsFromDeeds(XElement[] deeds);

		Task<int> SeedFirmsIntoDbContext(IEnumerable<Firm> firms);

		Task<IEnumerable<Firm>> RemoveDupicateFirms(IEnumerable<Firm> firms);
	}
}
