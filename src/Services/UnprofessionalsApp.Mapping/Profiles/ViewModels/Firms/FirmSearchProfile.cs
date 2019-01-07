using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

namespace UnprofessionalsApp.Mapping.Profiles.Firms
{
	public class FirmSearchProfile : Profile
	{
		public FirmSearchProfile()
		{
			CreateMap<Firm, FirmSearchViewModel>()
				.ForMember(x => x.Id,
						opts => opts.MapFrom(
								x => x.Id.ToString().ToLower().Replace("-", string.Empty)))
				.ForMember(x => x.DateOfRegistration, opts => opts.MapFrom(p => p.DateOfRegistration.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}
	}
}
