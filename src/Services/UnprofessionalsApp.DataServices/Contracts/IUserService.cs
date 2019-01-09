namespace UnprofessionalsApp.DataServices.Contracts
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

	public interface IUsersService
	{
		Task<TViewModel> GetUserByIdAsync<TViewModel>(int userId);

		Task<IEnumerable<TViewModel>> GetAllUsers<TViewModel>();
	}
}
