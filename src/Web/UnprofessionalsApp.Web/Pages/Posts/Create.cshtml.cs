using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.DataTransferObjects.Posts;
using UnprofessionalsApp.Models;
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
		private readonly IMapper mapper;
		private readonly IImagesService imagesService;
		private readonly ITagsService tagsService;
		private readonly IFilesService filesSerivce;
		private readonly UserManager<UnprofessionalsAppUser> userManager;

		public CreateModel(
			IMapper mapper,
			IPostsService postsService, 
			ICategoriesService categoriesService, 
			IImagesService imagesService, 
			ITagsService tagsService,
			IFilesService filesSerivce,
			UserManager<UnprofessionalsAppUser> userManager)
		{
			this.postsService = postsService;
			this.categoriesService = categoriesService;
			this.mapper = mapper;
			this.imagesService = imagesService;
			this.tagsService = tagsService;
			this.filesSerivce = filesSerivce;
			this.userManager = userManager;
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

		public IActionResult OnGet()
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

			//this.imagesService.Test();
			var postDto = this.mapper.Map<PostCreateDto>(InputModel);

			if (InputModel.ImageFile != null)
			{
				var filePath = await this.filesSerivce.ReadFile(this.InputModel.ImageFile);

				var uploadResult = await this.imagesService.UploadImageFromFilePath(filePath);

				var imageUrl = this.imagesService.GetUrlPath(uploadResult);

				var currentImage = await this.imagesService.CreateImage(imageUrl);

				postDto.ImageId = currentImage.Id;
			}
			else
			{
				postDto.ImageId = GlobalConstants.DefaultPostImageId;
			}

			var currentUser = await this.userManager.GetUserAsync(this.User);
			//postDto.Tags = currentTags;

			postDto.UsernId = currentUser.Id;

			var currentPost = await this.postsService.CreatePost(postDto);
			if (currentPost == null)
			{
				return this.NotFound();
			}

			var tags = await this.tagsService.CreateTags(this.InputModel.Tags);

			var currentTags = await this.tagsService.RemoveDuplicates(tags);

			await this.postsService.AddTagsToPost(currentPost, currentTags);

			return this.Redirect(string.Format("/Posts/Details/{0}", currentPost.Id));
		}
    }
}