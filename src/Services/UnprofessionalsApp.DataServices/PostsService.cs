namespace UnprofessionalsApp.DataServices
{
	using UnprofessionalsApp.Common;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Dynamic.Core;
	using UnprofessionalsApp.Mapping;
	using System;
	using System.Threading.Tasks;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;

	public class PostsService : IPostsService
	{
		private readonly IRepository<Post> postsRepository;

		public PostsService(IRepository<Post> postsRepository)
		{
			this.postsRepository = postsRepository;
		}

		public Task<int> GetAllPostsCount()
		{
			//TODO: Test Me
			var result = Task.Run(() => this.postsRepository.All().Count());
			return result;
		}

		public Task<IEnumerable<PostViewModel>> GetAllPostsForCurrentPage(
			int currentPage, int pageSize, string orderByParam, string ordering)
		{
			//TODO: Test me
			var postsViewModel = Task.Run(() => this.postsRepository.All()
				/*.AsQueryable()*/ // Вече е IQueryable, но за всеки случай
				.OrderBy(string.Concat(orderByParam, $" {ordering}"))
				.Skip((currentPage - 1) * pageSize)
				.Take(pageSize)
				.To<PostViewModel>() as IEnumerable<PostViewModel>);

			return postsViewModel;
		}

		
		//public Task<IEnumerable<CommentPostDetailsViewModel>> GetCommentsAsync(Post post)
		//{
		//	var commentTask = Task.Run(() => this.postsRepository.All()
		//						.Where(p => p.Id == post.Id)
		//						.SelectMany(c => c.Comments.Select(x => x)));
		//}

		public Task<TViewModel> GetPostByIdAsync<TViewModel>(int postId)
		{
			//TODO: Test me
			//TODO: Validate postId
			var result = Task.Run(() => this.postsRepository.All()
				.Where(p => p.Id == postId)
				.To<TViewModel>()
				.FirstOrDefault());

			return result;
		}
	}
}
