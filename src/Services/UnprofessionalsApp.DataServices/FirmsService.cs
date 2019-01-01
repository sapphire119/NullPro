using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Mapping;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels;
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

namespace UnprofessionalsApp.DataServices
{
	public class FirmsService : IFirmsService
	{
		private readonly IRepository<Firm> firmsRepository;

		public FirmsService(IRepository<Firm> firmsRepository)
		{
			this.firmsRepository = firmsRepository;
		}

		public int GetAllFirmsCount()
		{
			return this.firmsRepository.All().Count();
		}

		public IEnumerable<FirmViewModel> GetAllFirmsForCurrentPage(int currentPage, int pageSize)
		{
			//TODO: Test Me

			var firmsForCurrentPage = this.firmsRepository.All()
				.OrderBy(d => d.Id)
				.Skip((currentPage - 1) * pageSize)
				.Take(pageSize)
				.To<FirmViewModel>()
				.ToList();

			return firmsForCurrentPage;
		}

		public TViewModel GetFirmById<TViewModel>(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
