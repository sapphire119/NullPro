using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Users;

namespace UnprofessionalsApp.Mapping.Profiles.ViewModels.Users
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UnprofessionalsAppUser, UserViewModel>()
				.ForMember(x => x.Username, opts => opts.MapFrom(x => x.UserName))
				.ForMember(x => x.ImageUrl, opts => opts.MapFrom(x => WebUtility.UrlDecode(x.Image.Url)));
		}
	}
}
