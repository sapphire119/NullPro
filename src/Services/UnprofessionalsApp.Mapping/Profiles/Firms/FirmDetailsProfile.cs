using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

namespace UnprofessionalsApp.Mapping.Profiles.Firms
{
	public class FirmDetailsProfile : Profile
	{
		public FirmDetailsProfile()
		{
			CreateMap<Firm, FirmDetailsViewModel>()
				.ForMember(x => x.Id,
					opts => opts.MapFrom(
							x => x.Id.ToString().ToLower().Replace("-", string.Empty)))
				.ForMember(x => x.DateOfRegistration, opts => opts.MapFrom(p => p.DateOfRegistration.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)))
				.ForMember(x => x.Posts,
					opts => opts.MapFrom(
							x => x.Posts
								  .OrderByDescending(po => po.DateOfCreation)
								  .Select(p => p)));
		}
	}
}
