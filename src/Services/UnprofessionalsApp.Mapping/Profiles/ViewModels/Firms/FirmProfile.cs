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
	public class FirmProfile : Profile
	{
		public FirmProfile()
		{
			CreateMap<Firm, FirmViewModel>()
				.ForMember(f => f.PostsAboutFirm, opts => opts.MapFrom(f => f.Posts.Count()))
				.ForMember(f => f.DateOfRegistration, opts => opts.MapFrom(f => f.DateOfRegistration.ToString(@"d, MMMM yyyy", CultureInfo.InvariantCulture)));

			CreateMap<FirmViewModel, Firm>()
				.ForMember(x => x.Reports, opts => opts.Ignore())
				.ForMember(x => x.Posts, opts => opts.Ignore());
		}
	}
}
