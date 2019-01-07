using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
//using AutoMapper;
//using UnprofessionalsApp.Mapping.Contracts;
//using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Firms
{
	public class FirmDetailsViewModel /*: IMapFrom<Firm>, IHaveCustomMappings*/
	{
		public string Id { get; set; }

		public string UniqueFirmId { get; set; }

		public string Name { get; set; }

		public string DateOfRegistration { get; set; }

		public string LegalForm { get; set; }

		public virtual IEnumerable<PostEntityDetailsViewModel> Posts { get; set; }

		//public void CreateMappings(IMapperConfigurationExpression configuration)
		//{
		//	configuration.CreateMap<Firm, FirmDetailsViewModel>()
		//		.ForMember(x => x.Id, 
		//			opts => opts.MapFrom(
		//					x => x.Id.ToString().ToLower().Replace("-", string.Empty)))
		//		.ForMember(x => x.DateOfRegistration, opts => opts.MapFrom(p => p.DateOfRegistration.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)))
		//		.ForMember(x => x.Posts, 
		//			opts => opts.MapFrom(
		//					x => x.Posts
		//						  .OrderByDescending(po => po.DateOfCreation)
		//						  .Select(p => p)));
		//}
	}
}
