using AutoMapper;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Tags
{
	public class TagViewModel : IMapFrom<TagPost>, IHaveCustomMappings
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<TagPost, TagViewModel>()
				.ForMember(t => t.Id, opts => opts.MapFrom(t => t.TagId))
				.ForMember(t => t.Name, opts => opts.MapFrom(t => t.Tag.Name));
		}
	}
}
