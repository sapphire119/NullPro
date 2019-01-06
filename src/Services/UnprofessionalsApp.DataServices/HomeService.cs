using System.Collections.Generic;
using System.Threading.Tasks;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;
using UnprofessionalsApp.ViewInputModels.ViewModels.Home;
using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;
using UnprofessionalsApp.ViewInputModels.ViewModels.Users;
using System.Linq;
using UnprofessionalsApp.Mapping;

namespace UnprofessionalsApp.DataServices
{
	public class HomeService : IHomeService
	{
		private readonly IRepository<Category> categoriesRepository;
		private readonly IRepository<Post> postsRepository;
		private readonly IRepository<UnprofessionalsAppUser> usersRepository;
		private readonly IRepository<Tag> tagsRepository;

		public HomeService(
			IRepository<Category> categoriesRepository,
			IRepository<Post> postsRepository,
			IRepository<UnprofessionalsAppUser> usersRepository,
			IRepository<Tag> tagsRepository)
		{
			this.categoriesRepository = categoriesRepository;
			this.postsRepository = postsRepository;
			this.usersRepository = usersRepository;
			this.tagsRepository = tagsRepository;
		}

		public Task<IEnumerable<CategoryViewModel>> GetCategoriesWithMatchingResultAsync(
			string searchResult)
		{
			//TODO: Test me
			var taskResult = Task.Run(() => this.categoriesRepository.All()
				.Where(c => c.Name.Contains(searchResult))
				.Take(10)
				.To<CategoryViewModel>()
				.AsEnumerable());

			return taskResult;
		}

		public Task<IEnumerable<PostSearchViewModel>> GetPostsWithMatchingResultAsync(string searchResult)
		{
			//TODO: Test me
			var taskResult = Task.Run(() => this.postsRepository.All()
				.Where(c => c.Title.Contains(searchResult))
				.Take(10)
				.To<PostSearchViewModel>()
				.AsEnumerable());

			return taskResult;
		}

		public Task<IEnumerable<TagPostDetailsViewModel>> GetTagsWithMatchingResultAsync(string searchResult)
		{
			//TODO: Test me
			var taskResult = Task.Run(() => this.tagsRepository.All()
				.Where(c => c.Name.Contains(searchResult))
				.Take(10)
				.To<TagPostDetailsViewModel>()
				.AsEnumerable());

			return taskResult;
		}

		public Task<IEnumerable<UserSearchViewModel>> GetUsersWithMatchingResultAsync(string searchResult)
		{
			//TODO: Test me
			var taskResult = Task.Run(() => this.usersRepository.All()
				.Where(c => c.UserName.Contains(searchResult))
				.Take(10)
				.To<UserSearchViewModel>()
				.AsEnumerable());

			return taskResult;
		}
	}
}
