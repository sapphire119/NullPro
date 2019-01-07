using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Posts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IPostsService
	{
		Task<TViewModel> GetPostByIdAsync<TViewModel>(int postId);

		Task<IEnumerable<PostViewModel>> GetAllPostsForCurrentPage(int pageId, int pageSize, string orderByParam, string ordering);

		Task<int> GetAllPostsCount();

		Task<int> CreatePost(PostCreateInputModel inputModel);
	}
}
