namespace UnprofessionalsApp.DataServices.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;

	public interface ICategoriesService
	{
		Task<IEnumerable<CategoryViewModel>> GetAllCategories();

		Task<string> GetExistingStartingLettersForAllCategories();

		Task<IEnumerable<PostByCategoryViewModel>> GetAllRealtedPosts(int categoryId);

		Task<bool> AreThereAnyPostsWithCategory(int categoryId);
	}
}
