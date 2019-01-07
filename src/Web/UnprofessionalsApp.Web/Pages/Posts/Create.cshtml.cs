using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.InputModels.Posts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;

namespace UnprofessionalsApp.Web.Pages.Posts
{
	[Authorize]
    public class CreateModel : PageModel
    {
		private readonly IEnumerable<CategorySearchViewModel> categories;
		private readonly IPostsService postsService;
		private readonly ICategoriesService categoriesService;

		public CreateModel(IPostsService postsService, ICategoriesService categoriesService)
		{
			this.postsService = postsService;
			this.categoriesService = categoriesService;
			this.categories = this.categoriesService.GetAllCategories().GetAwaiter().GetResult();
		}

		[BindProperty]
		public PostCreateInputModel InputModel { get; set; }

		public IEnumerable<CategorySearchViewModel> Categories
		{
			get
			{
				return this.categories;
			}
		}

		//public int MyProperty { get; set; }

		public IActionResult OnGetAsync()
        {
			return this.Page();
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.SelectMany(e => e.Value.Errors);
				foreach (var error in errors)
				{
					ModelState.AddModelError(string.Empty, error.ErrorMessage);
				}

				return this.Page();
			}

			var result = await this.postsService.CreatePost(this.InputModel);

			return this.Page();
			//return this.RedirectToAction(string.Format("/Posts/details/{0}", ));
		}
    }
}