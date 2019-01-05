using System;
using System.Linq;
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

		public DateTime DateOfRegistration { get; set; }

		public int PostsAboutFirm { get; set; }

		public string LegalForm { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			//Check
			configuration.CreateMap<Firm, FirmViewModel>()
				.ForMember(f => f.PostsAboutFirm, opts => opts.MapFrom(f => f.Posts.Count()));

			configuration.CreateMap<FirmViewModel, Firm>()
				.ForMember(x => x.Reports, opts => opts.Ignore())
				.ForMember(x => x.Posts, opts => opts.Ignore());
		}
	}
}
