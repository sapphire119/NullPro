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
//using UnprofessionalsApp.Mapping;
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;
using AutoMapper;

namespace UnprofessionalsApp.DataServices
{
	public class HomeService : IHomeService
	{
		private readonly IRepository<Category> categoriesRepository;
		private readonly IRepository<Post> postsRepository;
		private readonly IRepository<UnprofessionalsAppUser> usersRepository;
		private readonly IRepository<Tag> tagsRepository;
		private readonly IRepository<Firm> firmsRepository;
		private readonly IMapper mapper;

		public HomeService(
			IRepository<Category> categoriesRepository,
			IRepository<Post> postsRepository,
			IRepository<UnprofessionalsAppUser> usersRepository,
			IRepository<Tag> tagsRepository,
			IRepository<Firm> firmsRepository,
			IMapper mapper)
		{
			this.categoriesRepository = categoriesRepository;
			this.postsRepository = postsRepository;
			this.usersRepository = usersRepository;
			this.tagsRepository = tagsRepository;
			this.firmsRepository = firmsRepository;
			this.mapper = mapper;
		}

		public Task<IEnumerable<CategorySearchViewModel>> GetCategoriesWithMatchingResultAsync(
			string searchResult)
		{
			//TODO: Test me
			var taskResult = Task.Run(() =>
			{
				var source = this.categoriesRepository.All()
				.Where(c => c.Name.Contains(searchResult))
				.Take(10); //TODO: Fix rendering for this
						   //.To<CategorySearchViewModel>()
						   //.AsEnumerable();

				var destination = this.mapper.ProjectTo<CategorySearchViewModel>(source);

				var result = destination.AsEnumerable();

				return result;
			});

			return taskResult;
		}

		public Task<IEnumerable<FirmSearchViewModel>> GetFirmsWithMatchingResultAsync(string searchResult)
		{
			//TODO: Test me
			var firmTaskResult = Task.Run(() =>
			{
				var source = this.firmsRepository.All()
				.Where(c => c.Name.Contains(searchResult));
				//.To<FirmSearchViewModel>()
				//.AsEnumerable());

				var destination = this.mapper.ProjectTo<FirmSearchViewModel>(source);

				var result = destination.AsEnumerable();

				return result;
			});

			return firmTaskResult;
		}

		public Task<IEnumerable<PostSearchViewModel>> GetPostsWithMatchingResultAsync(string searchResult)
		{
			//TODO: Test me
			var postsTaskResult = Task.Run(() =>
			{
				var source = this.postsRepository.All()
					.Where(c => c.Title.Contains(searchResult))
					.Take(10);//TODO: Fix rendering for this
							  //.To<PostSearchViewModel>()
							  //.AsEnumerable()

				var destination = this.mapper.ProjectTo<PostSearchViewModel>(source);

				var result = destination.AsEnumerable();

				return result;
			});

			return postsTaskResult;
		}

		public Task<IEnumerable<TagPostDetailsViewModel>> GetTagsWithMatchingResultAsync(string searchResult)
		{
			//TODO: Test me
			var tagsTaskResult = Task.Run(() =>
			{
				var source = this.tagsRepository.All()
					.Where(c => c.Name.Contains(searchResult))
					.Take(10);//TODO: Fix rendering for this
							  //.To<TagPostDetailsViewModel>()
							  //.AsEnumerable()
				var destination = this.mapper.ProjectTo<TagPostDetailsViewModel>(source);

				var result = destination.AsEnumerable();

				return result;
			});

			return tagsTaskResult;
		}

		public Task<IEnumerable<UserSearchViewModel>> GetUsersWithMatchingResultAsync(string searchResult)
		{
			//TODO: Test me
			var usersTaskResult = Task.Run(() =>
			{
				var source = this.usersRepository.All()
					.Where(c => c.UserName.Contains(searchResult))
					.Take(10);
				//.To<UserSearchViewModel>()
				//.AsEnumerable();

				var destination = this.mapper.ProjectTo<UserSearchViewModel>(source);

				var result = destination.AsEnumerable();

				return result;
			});

			return usersTaskResult;
		}
	}
}
