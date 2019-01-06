using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.Web.Controllers
{
	public class PostsController : Controller
	{
		private readonly IPostsService postsService;

		public PostsController(IPostsService postsService)
		{
			this.postsService = postsService;
		}
		
		[Route("Posts/Details/{postId?}")]
		public async Task<IActionResult> Details(int postId)
		{
			//TODO: Validate Details Action in PostsController
			var model = await this.postsService.GetPostByIdAsync<PostDetailsViewModel>(postId);
			//This is where the user can comment or reply to a comment on a post.
			//Post details should include:

			/* --post description
			 * --post title
			 * --post comments
			 * --post replies
			 * --post category
			 * --created on date
			 * --created by which user
			 * --link to user details on click of user's username
			 * --rating of post
			 * --popularity of post
			 * --total comments count
			 * --On click expand comment section and be able to see all comments and replies to comments
			 * --be able to create a comment on a post (CommentsController)
			 * -- ....
			 */
			return this.View(model);
		}
	}
}
