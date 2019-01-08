using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
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

		public Task<XElement[]> GetAllDeedsFromXDoc(XDocument xDoc)
		{
			var deedsTask = Task.Run(() =>
			{
				var root = xDoc.Root.Elements();

				foreach (var xElement in root)
				{
					var elements = xElement.Elements().ToArray();
					if (xElement.Name.LocalName == "Body")
					{
						var deedsAll = elements.Elements().ToArray();

						return deedsAll;
					}
				}

				return default(XElement[]);
			});

			return deedsTask;
		}

		public Task<IEnumerable<Firm>> GetFirmsFromDeeds(XElement[] deeds)
		{
			//TODO: Refactor in future.
			var firmsTask = Task.Run(() =>
			{
				var currentFirms = new List<Firm>();

				foreach (var deed in deeds)
				{
					var firmId = deed.Attribute("GUID")?.Value ?? string.Empty;

					var bulstat = deed.Attribute("UIC")?.Value ?? string.Empty;

					var companyName = deed.Attribute("CompanyName")?.Value ?? string.Empty;

					var legalForm = deed.Attribute("LegalForm")?.Value ?? string.Empty;

					if (string.IsNullOrWhiteSpace(firmId) ||
						string.IsNullOrWhiteSpace(bulstat) ||
						string.IsNullOrWhiteSpace(companyName) ||
						string.IsNullOrWhiteSpace(legalForm))
					{
						continue;
					}

					var isValidGuid = Guid.TryParse(firmId, out var firmGuidId);
					if (!isValidGuid)
					{
						continue;
					}

					var currentFirm = new Firm
					{
						Id = firmGuidId,
						Name = companyName,
						UniqueFirmId = bulstat,
						LegalForm = legalForm,
					};

					if (currentFirms.Any(f =>
							f.Id == currentFirm.Id || f.UniqueFirmId == currentFirm.UniqueFirmId))
					{
						continue;
					}

					currentFirms.Add(currentFirm);

					if (currentFirms.Count() > GlobalConstants.AllowedFirmCapacityCount)
					{
						return currentFirms.AsEnumerable();
					}
				}

				return currentFirms.AsEnumerable();
			});

			return firmsTask;
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
		public Guid? GetParsedFirmId(string id)
		{
			var isParseSuccessful = Guid.TryParse(id, out var firmId);
			if (!isParseSuccessful)
			{
				return null;
			}

			return firmId;
		}

		public async Task<int> SeedFirmsIntoDbContext(IEnumerable<Firm> firms)
		{
			await this.firmsRepository.AddRangeAsync(firms);

			var statusCode = await this.firmsRepository.SaveChangesAsync();

			return statusCode;
		}

		public Task<IEnumerable<Firm>> RemoveDupicateFirms(IEnumerable<Firm> firms)
		{
			var firmsTask = Task.Run(() =>
			{
				var result = firms
					.Where(f => !this.firmsRepository.All().Any(@if => @if.UniqueFirmId == f.UniqueFirmId))
					.Distinct();

				return result;
			});

			return firmsTask;
		}
	}
}
