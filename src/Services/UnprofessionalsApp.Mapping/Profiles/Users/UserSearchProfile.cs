using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Users;

namespace UnprofessionalsApp.Mapping.Profiles.Users
{
	public class UserSearchProfile : Profile
	{
		public UserSearchProfile()
		{
			CreateMap<UnprofessionalsAppUser, UserSearchViewModel>()
				.ForMember(x => x.DateOfRegistration,
				opts => opts.MapFrom(
					u => u.DateOfRegistration.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}
	}
}
