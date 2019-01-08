namespace UnprofessionalsApp.Web.Pages.Categories
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.RazorPages;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Home;

	public class DetailsModel : PageModel
	{
		private readonly ICategoriesService categoriesService;

		public DetailsModel(ICategoriesService categoriesService)
		{
			this.categoriesService = categoriesService;
		}

		//Validate Me
		[BindProperty(SupportsGet = true)]
		public int CategoryId { get; set; }

		[BindProperty(SupportsGet = true)]
		public string CategoryName { get; set; }

		public bool AreThereAnyPostsForCategory { get; set; }

		public IEnumerable<PostByCategoryViewModel> RelatedPosts { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			this.AreThereAnyPostsForCategory =
				await this.categoriesService.AreThereAnyPostsWithCategory(this.CategoryId);

			if (this.AreThereAnyPostsForCategory)
			{
				this.RelatedPosts = await this.categoriesService.GetAllRealtedPosts(this.CategoryId);
				return Page();
			}
			//TODO: Write a Display Error message for lack of posts on details category page.
			return this.RedirectToPage("/Categories/Index");
		}
	}
}