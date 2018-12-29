namespace UnprofessionalsApp.DataServices
{
	using UnprofessionalsApp.Common;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

	using System.Collections.Generic;
	using System.Linq;
	using UnprofessionalsApp.Mapping;

	public class PostsService : IPostsService
	{
		private readonly IRepository<Post> postsRepository;

		public PostsService(IRepository<Post> postsRepository)
		{
			this.postsRepository = postsRepository;
		}

		public IEnumerable<AllViewModel> GetAllPosts()
		{
			var allPosts = this.postsRepository.All().To<AllViewModel>().ToList();
			
			return allPosts;
		}

		public TViewModel GetPostById<TViewModel>(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
