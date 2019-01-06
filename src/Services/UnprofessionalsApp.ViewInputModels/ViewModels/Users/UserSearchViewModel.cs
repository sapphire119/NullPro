using System;
using System.Globalization;
using AutoMapper;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Users
{
	public class UserSearchViewModel : IMapFrom<UnprofessionalsAppUser>, IHaveCustomMappings
	{
		public int Id { get; set; }

		public string Username { get; set; }

		public string Email { get; set; }

		public string DateOfRegistration { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<UnprofessionalsAppUser, UserSearchViewModel>()
				.ForMember(x => x.DateOfRegistration, 
				opts => opts.MapFrom(
					u => u.DateOfRegistration.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}
	}
}
