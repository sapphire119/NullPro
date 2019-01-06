namespace UnprofessionalsApp.DataServices
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using UnprofessionalsApp.Common;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.Mapping;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

	public class UserService : IUsersService
	{
		private readonly IRepository<UnprofessionalsAppUser> userRepository;

		public UserService(IRepository<UnprofessionalsAppUser> userRepository)
		{
			this.userRepository = userRepository;
		}

		public Task<TViewModel> GetUserByIdAsync<TViewModel>(int userId)
		{
			//TODO: Check if invalid userId
			var userTask = Task.Run(() => this.userRepository.All()
						.Where(u => u.Id == userId)
						.To<TViewModel>()
						.FirstOrDefault());

			return userTask;
		}
	}
}
