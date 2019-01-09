using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnprofessionalsApp.DataTransferObjects.Posts;
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

		Task<Post> GetPostByPostName(string postName);

		Task<IEnumerable<PostViewModel>> GetAllPostsForCurrentPage(int pageId, int pageSize, string orderByParam, string ordering);

		Task<int> GetAllPostsCount();

		Task<Post> CreatePost(PostCreateDto postDto);

		Task<int> AddTagsToPost(Post result, IEnumerable<Tag> currentTags);

		Task<IEnumerable<TViewModel>> GetPostsByUsernameAsync<TViewModel>(UnprofessionalsAppUser currentUser);
	}
}
