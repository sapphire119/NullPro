using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Users;

namespace UnprofessionalsApp.Mapping.Profiles.Users
{
	public class UserDetailsProfile : Profile
	{
		public UserDetailsProfile()
		{
			CreateMap<UnprofessionalsAppUser, UserDetailsViewModel>()
				.ForMember(x => x.ImageUrl, opts => opts.MapFrom(x => WebUtility.UrlDecode(x.Image.Url)))
				.ForMember(x => x.Username, opts => opts.MapFrom(x => x.UserName))
				.ForMember(x => x.Email, opts => opts.MapFrom(x => x.Email))
				.ForMember(x => x.PhoneNumber, opts => opts.MapFrom(x => x.PhoneNumber))
				.ForMember(x => x.FirmPosts,
						opts => opts.MapFrom(
									x => x.Posts
										  .Where(p => p.FirmId != null)
										  .OrderByDescending(p => p.DateOfCreation)
										  .Select(c => c)))
				.ForMember(x => x.Posts,
						opts => opts.MapFrom(
									x => x.Posts
										  .Where(p => p.FirmId == null)
										  .OrderByDescending(p => p.DateOfCreation)
										  .Select(c => c)))
				.ForMember(x => x.Comments,
						opts => opts.MapFrom(
									x => x.Comments
										  .OrderByDescending(p => p.DateOfCreation)
										  .Select(c => c)))
				.ForMember(x => x.DateOfRegistration,
						opts => opts.MapFrom(
									u => u.DateOfRegistration
										  .ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}
	}
}
