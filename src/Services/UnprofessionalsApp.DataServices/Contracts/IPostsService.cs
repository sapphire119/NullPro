using System.Collections.Generic;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IPostsService
	{
		TViewModel GetPostById<TViewModel>(int id);

		IEnumerable<AllViewModel> GetAllPosts();
	}
}
