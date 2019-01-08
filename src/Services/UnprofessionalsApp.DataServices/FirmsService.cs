using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
//using UnprofessionalsApp.Mapping;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels;
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

namespace UnprofessionalsApp.DataServices
{
	public class FirmsService : IFirmsService
	{
		private readonly IRepository<Firm> firmsRepository;
		private readonly IMapper mapper;

		public FirmsService(IRepository<Firm> firmsRepository, IMapper mapper)
		{
			this.firmsRepository = firmsRepository;
			this.mapper = mapper;
		}

		public Task<int> GetAllFirmsCount()
		{
			//TODO: Test Me
			var result = Task.Run(() => this.firmsRepository.All().Count());
			return result;
		}

		public Task<IEnumerable<FirmViewModel>> GetAllFirmsForCurrentPage(
			int currentPage, 
			int pageSize, 
			string orderByParam, 
			string ordering)
		{
			//TODO: Validate somewhere else sortBy
			var sortBy = orderByParam == "PostsAboutFirm" ? "Posts.Count()" : orderByParam;

			//Test And Validate Me.
			var firmsForCurrentPage = Task.Run(() =>
			{
				var source = this.firmsRepository.All() // Вече е IQueryable, но за всеки случай
				.OrderBy(string.Concat(sortBy, $" {ordering}"))
				.ThenBy(f => f.Posts.Count())
				.Skip((currentPage - 1) * pageSize)
				.Take(pageSize);
				//.To<IEnumerable<FirmViewModel>>();

				var destination = this.mapper.ProjectTo<FirmViewModel>(source);

				var result = destination as IEnumerable<FirmViewModel>;

				return result;
			});

			return firmsForCurrentPage;
		}

		public Task<TViewModel> GetFirmById<TViewModel>(Guid firmId)
		{
			var firmTask = Task.Run(() =>
			{
				var source = this.firmsRepository.All()
						.Where(f => f.Id == firmId);

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination.FirstOrDefault();

				return result;
			});

			return firmTask;
		}

		public Task<TViewModel> GetFirmByUniqueId<TViewModel>(string uniqueFirmdId)
		{
			var firmTask = Task.Run(() =>
			{
				var source = this.firmsRepository.All()
						.Where(f => f.UniqueFirmId == uniqueFirmdId);

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination.FirstOrDefault();

				return result;
			});

			return firmTask;
		}

		//TODO: Think if GetParsedFirmId should be a service.
		public Guid GetParsedFirmId(string id)
		{
			var isParseSuccessful = Guid.TryParse(id, out var firmId);
			if (!isParseSuccessful)
			{
				//TODO: Think of a proper way to throw exception
			}

			return firmId;
		}
	}
}
