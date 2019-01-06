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
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

namespace UnprofessionalsApp.DataServices
{
	public class HomeService : IHomeService
	{
		private readonly IRepository<Category> categoriesRepository;
		private readonly IRepository<Post> postsRepository;
		private readonly IRepository<UnprofessionalsAppUser> usersRepository;
		private readonly IRepository<Tag> tagsRepository;
		private readonly IRepository<Firm> firmsRepository;

		public HomeService(
			IRepository<Category> categoriesRepository,
			IRepository<Post> postsRepository,
			IRepository<UnprofessionalsAppUser> usersRepository,
			IRepository<Tag> tagsRepository,
			IRepository<Firm> firmsRepository)
		{
			this.categoriesRepository = categoriesRepository;
			this.postsRepository = postsRepository;
			this.usersRepository = usersRepository;
			this.tagsRepository = tagsRepository;
			this.firmsRepository = firmsRepository;
		}

		public Task<IEnumerable<CategorySearchViewModel>> GetCategoriesWithMatchingResultAsync(
			string searchResult)
		{
			//TODO: Test me
			var taskResult = Task.Run(() => this.categoriesRepository.All()
				.Where(c => c.Name.Contains(searchResult))
				.Take(10)
				.To<CategorySearchViewModel>()
				.AsEnumerable());

			return taskResult;
		}

		public Task<IEnumerable<FirmSearchViewModel>> GetFirmsWithMatchingResultAsync(string searchResult)
		{
			//TODO: Test me
			var firmTaskResult = Task.Run(() => this.firmsRepository.All()
				.Where(c => c.Name.Contains(searchResult))
				.To<FirmSearchViewModel>()
				.AsEnumerable());

			return firmTaskResult;
		}

		public Task<IEnumerable<PostSearchViewModel>> GetPostsWithMatchingResultAsync(string searchResult)
		{
			//TODO: Test me
			var postsTaskResult = Task.Run(() => this.postsRepository.All()
				.Where(c => c.Title.Contains(searchResult))
				.Take(10)
				.To<PostSearchViewModel>()
				.AsEnumerable());

			return postsTaskResult;
		}

		public Task<IEnumerable<TagPostDetailsViewModel>> GetTagsWithMatchingResultAsync(string searchResult)
		{
			//TODO: Test me
			var tagsTaskResult = Task.Run(() => this.tagsRepository.All()
				.Where(c => c.Name.Contains(searchResult))
				.Take(10)
				.To<TagPostDetailsViewModel>()
				.AsEnumerable());

			return tagsTaskResult;
		}

		public Task<IEnumerable<UserSearchViewModel>> GetUsersWithMatchingResultAsync(string searchResult)
		{
			//TODO: Test me
			var usersTaskResult = Task.Run(() => this.usersRepository.All()
				.Where(c => c.UserName.Contains(searchResult))
				.Take(10)
				.To<UserSearchViewModel>()
				.AsEnumerable());

			return usersTaskResult;
		}
	}
}
