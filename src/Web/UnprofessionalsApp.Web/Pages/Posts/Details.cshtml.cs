using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnprofessionalsApp.Web.Pages.Posts
{
    public class DetailsModel : PageModel
    {
		public async Task<IActionResult> OnGetAsync()
        {
			return this.Page();
        }
    }
}