namespace UnprofessionalsApp.DataServices.Contracts
{
    using Microsoft.AspNetCore;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.InputModels.Categories;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;

	public interface ICategoriesService
	{
		Task<IEnumerable<CategorySearchViewModel>> GetAllCategories();

		Task<string> GetExistingStartingLettersForAllCategories();

		Task<IEnumerable<PostByCategoryViewModel>> GetAllRealtedPosts(int categoryId);

		Task<bool> AreThereAnyPostsWithCategory(int categoryId);

		Task<int> CreateCategory(CreateCategoryInputModel inputModel);
		
		int GetCount();

		Task<Category> FindByName(string name);
	}
}
