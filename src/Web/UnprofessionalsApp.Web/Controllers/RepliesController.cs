namespace UnprofessionalsApp.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using System.Threading.Tasks;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.ViewInputModels.InputModels.Replies;

	public class RepliesController : Controller
	{
		private readonly IRepliesService repliesSerivce;

		public RepliesController(IRepliesService repliesSerivce)
		{
			this.repliesSerivce = repliesSerivce;
		}

		//TODO: Filter InputModel.
		[Authorize]
		[HttpPost]
		[Route("Replies/Create")]
		public async Task<IActionResult> CreateAsync(CreateInputModel inputModel)
		{
			if (!ModelState.IsValid)
			{
				return this.Redirect(string.Format("/Posts/Details/{0}", inputModel.PostId));
			}

			await this.repliesSerivce.CreateReply(inputModel);

			return this.Redirect(string.Format("/Posts/Details/{0}", inputModel.PostId));
		}
	}
}
