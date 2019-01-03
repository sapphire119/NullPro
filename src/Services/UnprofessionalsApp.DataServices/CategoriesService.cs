using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;
using UnprofessionalsApp.Mapping;

namespace UnprofessionalsApp.DataServices
{
	public class CategoriesService : ICategoriesService
	{
		private readonly IRepository<Category> categoriesRepository;

		public CategoriesService(IRepository<Category> categoriesRepository)
		{
			this.categoriesRepository = categoriesRepository;
		}

		public Task<IEnumerable<CategoryViewModel>> GetAllCategories()
		{
			var categories = Task.Run(() => this.categoriesRepository.All()
					.OrderBy(c => c.Name)
					.To<CategoryViewModel>()
					.AsEnumerable());

			return categories;
		}

		public Task<string> GetExistingStartingLettersForAllCategories()
		{
			var lettersForCurrentCategories = Task.Run(() => string.Join("",
				this.categoriesRepository.All()
				.OrderBy(c => c.Name)
				.Select(c => c.Name[0])
				.Distinct()
				.ToArray()).ToUpper());

			return lettersForCurrentCategories;
		}
	}
}
