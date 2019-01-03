using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;

namespace UnprofessionalsApp.Web.Pages.Categories
{
    public class IndexModel : PageModel
    {
		public IndexModel(ICategoriesService categoriesService)
		{
			this.categoriesService = categoriesService;
		}

		private readonly ICategoriesService categoriesService;

		public string LettersToPrint { get; set; }

		public IEnumerable<CategoryViewModel> Categories { get; set; }

		public async Task OnGetAsync()
        {
			this.Categories = await this.categoriesService.GetAllCategories();
			this.LettersToPrint = await this.categoriesService.GetExistingStartingLettersForAllCategories();
        }
    }
}