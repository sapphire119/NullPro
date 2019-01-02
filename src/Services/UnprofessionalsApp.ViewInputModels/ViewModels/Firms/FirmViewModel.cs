using System;
using AutoMapper;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Firms
{
	public class FirmViewModel : IMapFrom<Firm>, IHaveCustomMappings
	{
		public Guid Id { get; set; }

		public string UniqueFirmId { get; set; }

		public string Name { get; set; }

		public int Popularity { get; set; }

		public int Rating { get; set; }

		public string LegalForm { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Firm, FirmViewModel>();

			configuration.CreateMap<FirmViewModel, Firm>()
				.ForMember(x => x.Reports, opts => opts.Ignore())
				.ForMember(x => x.Posts, opts => opts.Ignore());
		}
	}
}
