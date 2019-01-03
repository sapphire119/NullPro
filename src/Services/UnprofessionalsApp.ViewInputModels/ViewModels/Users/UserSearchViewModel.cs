using System;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Users
{
	public class UserSearchViewModel : IMapFrom<UnprofessionalsAppUser>
	{
		public int Id { get; set; }

		public string Username { get; set; }

		public string Email { get; set; }

		public DateTime DateOfRegistration { get; set; }
	}
}
