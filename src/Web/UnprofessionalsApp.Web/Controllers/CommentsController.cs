namespace UnprofessionalsApp.Web.Controllers
{
	using System.Threading.Tasks;
	using System.Linq;
	using Microsoft.AspNetCore.Mvc;
	using UnprofessionalsApp.ViewInputModels.InputModels.Comments;
	using UnprofessionalsApp.DataServices.Contracts;

	public class CommentsController : Controller
	{
		private readonly ICommentsService commentsService;

		public CommentsController(ICommentsService commentsService)
		{
			this.commentsService = commentsService;
		}

		[HttpPost]
		[Route("Comments/Create")]
		//TODO: Filter Input Model
		public async Task<IActionResult> CreateAsync(CreateInputModel inputModel)
		{
			if (!ModelState.IsValid)
			{
				return this.Redirect($"/Posts/Details/{inputModel.PostId}");
			}

			var result = await this.commentsService.CreateComment(inputModel);

			return this.Redirect($"/Posts/Details/{inputModel.PostId}");
		}
	}
}
