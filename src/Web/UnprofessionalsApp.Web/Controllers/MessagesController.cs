namespace UnprofessionalsApp.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class MessagesController : Controller
	{
		public IActionResult Index()
		{
			return this.View();
		}
	}
}
