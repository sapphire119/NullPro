using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.Mapping.Profiles.Posts
{
	public class PostDetailsProfile : Profile
	{
		public PostDetailsProfile()
		{
			CreateMap<Post, PostDetailsViewModel>()
				.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName))
				.ForMember(x => x.FirmName, opts => opts.MapFrom(p => p.Firm.Name))
				.ForMember(x => x.Comments, opts => opts.MapFrom(p => p.Comments))
				.ForMember(x => x.DateOfCreation, opts => opts.MapFrom(p =>
				string.Format(
					GlobalConstants.PostDetailsDateOfCreationFormat,
					p.DateOfCreation.ToString(@"d MMMM yyyy", CultureInfo.InvariantCulture),
					p.DateOfCreation.ToString(@"hh:mm tt", CultureInfo.InvariantCulture))));
		}
	}
}