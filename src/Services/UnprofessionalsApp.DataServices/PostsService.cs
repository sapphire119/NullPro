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

	public class PostsService : IPostsService
	{
		private readonly IRepository<Post> postsRepository;

		public PostsService(IRepository<Post> postsRepository)
		{
			this.postsRepository = postsRepository;
		}

		//public IEnumerable<PostViewModel> GetAllPosts(int currentPage, int pageSize)
		//{
		//	//TODO: Test me
		//	var allPosts = this.postsRepository.All()
		//		.OrderBy(p => p.Id)
		//		.Skip((currentPage - 1) * pageSize)
		//		.Take(pageSize)
		//		.To<PostViewModel>()
		//		.ToList();
			
		//	return allPosts;
		//}

		public int GetAllPostsCount()
		{
			//TODO: Test Me
			return this.postsRepository.All().Count();
		}

		public IEnumerable<PostViewModel> GetAllPostsForCurrentPage(
			int currentPage, int pageSize, string orderByParam, string ordering)
		{
			//Test Me
			var postsViewModel = this.postsRepository.All()
				.AsQueryable() // Вече е IQueryable, но за всеки случай
				.OrderBy(string.Concat(orderByParam, $" {ordering}"))
				.Skip((currentPage - 1) * pageSize)
				.Take(pageSize)
				.To<PostViewModel>()
				.ToList();

			return postsViewModel;
		}

		public TViewModel GetPostById<TViewModel>(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
