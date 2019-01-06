using System.Collections.Generic;
using System.Threading.Tasks;
using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;
using UnprofessionalsApp.ViewInputModels.ViewModels.Home;
using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;
using UnprofessionalsApp.ViewInputModels.ViewModels.Users;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IHomeService
	{
		Task<IEnumerable<PostSearchViewModel>> GetPostsWithMatchingResultAsync(string searchResult);

		Task<IEnumerable<UserSearchViewModel>> GetUsersWithMatchingResultAsync(string searchResult);

		Task<IEnumerable<CategorySearchViewModel>> GetCategoriesWithMatchingResultAsync(string searchResult);

		Task<IEnumerable<TagPostDetailsViewModel>> GetTagsWithMatchingResultAsync(string searchResult);
		Task<IEnumerable<FirmSearchViewModel>> GetFirmsWithMatchingResultAsync(string searchResult);
	}
}
