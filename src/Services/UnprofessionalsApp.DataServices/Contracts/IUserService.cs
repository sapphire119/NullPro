using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IUsersService
	{
		Task<TViewModel> GetUserByIdAsync<TViewModel>(int userId);
	}
}
