using Microsoft.AspNetCore.Mvc;

namespace Mailing.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
