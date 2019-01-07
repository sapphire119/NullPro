using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
//using AutoMapper;
//using UnprofessionalsApp.Mapping.Contracts;
//using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Firms
{
	public class FirmSearchViewModel /*: IMapFrom<Firm>, IHaveCustomMappings*/
	{
		public string Id { get; set; }

		public string UniqueFirmId { get; set; }

		public string Name { get; set; }

		public string DateOfRegistration { get; set; }

		public string LegalForm { get; set; }

		//public void CreateMappings(IMapperConfigurationExpression configuration)
		//{
		//	configuration.CreateMap<Firm, FirmSearchViewModel>()
		//		.ForMember(x => x.Id, 
		//				opts => opts.MapFrom(
		//						x => x.Id.ToString().ToLower().Replace("-",string.Empty)))
		//		.ForMember(x => x.DateOfRegistration, opts => opts.MapFrom(p => p.DateOfRegistration.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
		//}
	}
}
