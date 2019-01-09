using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.InputModels.Categories;

namespace UnprofessionalsApp.Web.Pages.Categories
{
    public class CreateModel : PageModel
    {
		private readonly ICategoriesService categoriesService;

		public CreateModel(ICategoriesService categoriesService)
		{
			this.categoriesService = categoriesService;
		}

		[BindProperty]
		public CreateCategoryInputModel InputModel { get; set; }

		public IActionResult OnGet()
        {
			return this.Page();
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				var errors =
					this.ModelState.SelectMany(t => t.Value.Errors.Select(e => e.ErrorMessage));

				foreach (var error in errors)
				{
					this.ModelState.AddModelError(string.Empty, error);
				}
			}

			var isCategoryPresent = await this.categoriesService.FindByName(InputModel.Name);
			if (isCategoryPresent != null)
			{
				this.ModelState
					.AddModelError(string.Empty, GlobalConstants.CategoryIsPresentMessage);

				return this.Page();
			}

			var statusResult = await this.categoriesService.CreateCategory(this.InputModel);

			if (statusResult < GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				this.ModelState.AddModelError(string.Empty, GlobalConstants.DefaultNotSavedIntoDbContextMessage);

				return this.Page();
			}

			return this.Redirect("/categories/index");
		}
	}
}