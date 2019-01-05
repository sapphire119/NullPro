using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnprofessionalsApp.Web.Pages.Comments
{
    public class CreateModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
			return Page();
        }

		
		public async Task<IActionResult> OnPostAsync(int postId, int userId)
		{
			return RedirectToPage("/Posts/Details", postId);
		}
    }
}