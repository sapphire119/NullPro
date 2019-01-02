using System.Collections.Generic;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IPostsService
	{
		TViewModel GetPostById<TViewModel>(int id);

		//IEnumerable<PostViewModel> GetAllPosts(int currentPage, int pageSize);

		IEnumerable<PostViewModel> GetAllPostsForCurrentPage(int pageId, int pageSize, string orderByParam, string ordering);

		int GetAllPostsCount();
	}
}
