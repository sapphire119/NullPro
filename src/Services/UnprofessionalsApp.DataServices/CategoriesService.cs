using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;
//using UnprofessionalsApp.Mapping;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Home;
//using AutoMapper;

namespace UnprofessionalsApp.DataServices
{
	public class CategoriesService : ICategoriesService
	{
		private readonly IRepository<Category> categoriesRepository;
		private readonly IMapper mapper;

		public CategoriesService(IRepository<Category> categoriesRepository, IMapper mapper)
		{
			this.categoriesRepository = categoriesRepository;
			this.mapper = mapper;
		}

		public Task<IEnumerable<CategorySearchViewModel>> GetAllCategories()
		{
			//TODO: Test me
			var categories = Task.Run(() => 
			{
				var source = this.categoriesRepository.All()
						.OrderBy(c => c.Name)
						//.To<CategorySearchViewModel>()
						.AsQueryable();

				var destination = this.mapper.ProjectTo<CategorySearchViewModel>(source);

				var result = destination.AsEnumerable();

				return result;
			});


			return categories;
		}

		public Task<IEnumerable<PostByCategoryViewModel>> GetAllRealtedPosts(int categoryId)
		{
			//TODO: Test me
			var relatedPosts = Task.Run(() => 
			{
				var source = this.categoriesRepository.All()
						.Where(c => c.Id == categoryId)
						.SelectMany(c => c.Posts)
						//.To<PostByCategoryViewModel>()
						.OrderBy(p => p.DateOfCreation)
						.AsQueryable();

				var destination = this.mapper.ProjectTo<PostByCategoryViewModel>(source);

				var result = destination.AsEnumerable();

				return result;
			});

			return relatedPosts;
		}

		public Task<string> GetExistingStartingLettersForAllCategories()
		{
			//TODO: Test me
			var lettersForCurrentCategories = Task.Run(() => string.Join("",
				this.categoriesRepository.All()
				.OrderBy(c => c.Name)
				.Select(c => c.Name[0])
				.Distinct()
				.ToArray()).ToUpper());

			return lettersForCurrentCategories;
		}

		public Task<bool> AreThereAnyPostsWithCategory(int categoryId)
		{
			//TODO: Test me
			var result = Task.Run(() => this.categoriesRepository.All()
				.Where(c => c.Id == categoryId)
				.SelectMany(c => c.Posts)
				.Any());

			return result;
		}
	}
}
