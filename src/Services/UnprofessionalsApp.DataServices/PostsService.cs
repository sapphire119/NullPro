namespace UnprofessionalsApp.DataServices
{
	using UnprofessionalsApp.Common;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Dynamic.Core;
	//using UnprofessionalsApp.Mapping;
	using System;
	using System.Threading.Tasks;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;
	using AutoMapper;
	using Microsoft.Extensions.Configuration;
	using UnprofessionalsApp.ViewInputModels.InputModels.Posts;

	public class PostsService : IPostsService
	{
		private readonly IRepository<Post> postsRepository;
		private readonly IMapper mapper;
		private readonly IConfiguration configuration;

		public PostsService(IRepository<Post> postsRepository, IMapper mapper, IConfiguration configuration)
		{
			this.postsRepository = postsRepository;
			this.mapper = mapper;
			this.configuration = configuration;
		}

		public Task<int> CreatePost(PostCreateInputModel inputModel)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetAllPostsCount()
		{
			//this.configuration["Cloudinary"]
			//TODO: Test Me
			var result = Task.Run(() => this.postsRepository.All().Count());
			return result;
		}

		public Task<IEnumerable<PostViewModel>> GetAllPostsForCurrentPage(
			int currentPage, int pageSize, string orderByParam, string ordering)
		{
			//var test = this.configuration.GetSection("Cloudinary").GetChildren().ToDictionary(x => x.Key, k => k.Value);
			//TODO: Test me
			var postsViewModel = Task.Run(() =>
			{
				var source = this.postsRepository.All()
				/*.AsQueryable()*/ // Вече е IQueryable, но за всеки случай
				.OrderBy(string.Concat(orderByParam, $" {ordering}"))
				.Skip((currentPage - 1) * pageSize)
				.Take(pageSize);
				//.To<PostViewModel>() as IEnumerable<PostViewModel>

				var destination = this.mapper.ProjectTo<PostViewModel>(source);

				var result = destination as IEnumerable<PostViewModel>;

				return result;
			});

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
			var postTask = Task.Run(() =>
			{
				var source = this.postsRepository.All()
				.Where(p => p.Id == postId);
				//.To<TViewModel>()
				//.FirstOrDefault()

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination.FirstOrDefault();

				return result;
			});

			return postTask;
		}
	}
}
