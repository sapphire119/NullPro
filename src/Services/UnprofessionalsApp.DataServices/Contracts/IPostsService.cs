using System.Collections.Generic;
using System.Threading.Tasks;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IPostsService
	{
		Task<TViewModel> GetPostById<TViewModel>(int id);

		Task<IEnumerable<PostViewModel>> GetAllPostsForCurrentPage(int pageId, int pageSize, string orderByParam, string ordering);

		Task<int> GetAllPostsCount();
	}
}
