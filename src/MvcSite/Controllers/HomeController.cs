using Microsoft.AspNetCore.Mvc;

namespace MvcSite.Controllers
{
	public class HomeController : Controller
    {
		[HttpGet]
		public IActionResult Index()
		{
		    ViewData["Key"] = "Fish";
			return View();
		}

		[HttpGet]
		public IActionResult Index2()
		{
			return Content("Hello World 2");
		}
    }
}
