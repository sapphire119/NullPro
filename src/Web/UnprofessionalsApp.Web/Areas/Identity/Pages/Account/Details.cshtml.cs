﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.Web.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class DetailsModel : PageModel
    {
		private readonly UserManager<UnprofessionalsAppUser> userManager;

		public DetailsModel(UserManager<UnprofessionalsAppUser> userManager)
		{
			this.userManager = userManager;
		}

		[BindProperty(SupportsGet = true)]
		public int UserId { get; set; }

		[BindProperty(SupportsGet = true)]
		public string UserName { get; set; }

		[TempData]
		public string StatusMessage { get; set; }

		public async Task<IActionResult> OnGetAsync(string id, string returnUrl = null)
        {
			//Във userId и Username са стойностите.
			var user = await this.userManager.FindByIdAsync(id);

			if (user == null)
			{
				return NotFound($"Unable to load user with ID '{id}'.");
			}

			return this.Page();
		}
    }
}