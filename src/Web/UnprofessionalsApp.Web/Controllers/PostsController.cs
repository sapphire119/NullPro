namespace UnprofessionalsApp.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using System.Threading.Tasks;
	using UnprofessionalsApp.DataServices.Contracts;

	public class PostsController : Controller
	{
		private readonly IPostsService postsService;

		public PostsController(IPostsService postsService)
		{
			this.postsService = postsService;
		}

		/* --User can:
		 * ----View all posts
		 * ----Create post
		 * ----Order Posts by: date, popularity or rating //All checkmarks
		 * ----View Details on post (this is where he can comment or reply to a comment)
		 * 
		 */

		public IActionResult Index() //This is all posts page
		{
			var model = this.postsService.GetAllPosts();
			//TODO: Implement ordering for posts

			/*
			 * All logic should include:
			 * -- view posts in a table (list)
			 * -- be able to click on a post's name and href to post Details
			 * -- view post popularity
			 * -- view post rating
			 * -- view post creator and href to his details page on click.
			 * -- Implement ordering by: date, popularity
			 */

			return this.View(model);
		}

		[Authorize]
		public async Task<IActionResult> Create()
		{
			/*
			 * Creating a post should be simple, only logged in users can create posts.
			 * post creation may or may not include a firm (post about a firm)
			 * 
			 */
			int id = -1;
			return this.RedirectToAction("Details", new { id = id});
		}

		public IActionResult Details(int id)
		{
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
			return this.View();
		}
	}
}
