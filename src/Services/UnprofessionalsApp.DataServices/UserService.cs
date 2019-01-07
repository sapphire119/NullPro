namespace UnprofessionalsApp.DataServices
{
	using AutoMapper;
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using UnprofessionalsApp.Common;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

	public class UserService : IUsersService
	{
		private readonly IRepository<UnprofessionalsAppUser> userRepository;
		private readonly IMapper mapper;

		public UserService(IRepository<UnprofessionalsAppUser> userRepository, IMapper mapper)
		{
			this.userRepository = userRepository;
			this.mapper = mapper;
		}

		public Task<TViewModel> GetUserByIdAsync<TViewModel>(int userId)
		{
			//TODO: Check if invalid userId
			var userTask = Task.Run(() =>
			{
				var source = this.userRepository.All()
						.Where(u => u.Id == userId);
				//.To<TViewModel>()
				//.FirstOrDefault()

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination.FirstOrDefault();

				return result;
			});

			return userTask;
		}
	}
}
