namespace UnprofessionalsApp.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class CommentsController : Controller
	{
		public IActionResult Index()
		{
			return this.View();
		}
	}
}
