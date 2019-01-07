//using AutoMapper;
//using UnprofessionalsApp.Mapping.Contracts;
//using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Tags
{
	public class TagPostDetailsViewModel/* : IMapFrom<TagPost>, IHaveCustomMappings*/
	{
		public int Id { get; set; }

		public string Name { get; set; }

		//public void CreateMappings(IMapperConfigurationExpression configuration)
		//{
		//	configuration.CreateMap<TagPost, TagPostDetailsViewModel>()
		//		.ForMember(t => t.Id, opts => opts.MapFrom(t => t.TagId))
		//		.ForMember(t => t.Name, opts => opts.MapFrom(t => t.Tag.Name));
		//}
	}
}
