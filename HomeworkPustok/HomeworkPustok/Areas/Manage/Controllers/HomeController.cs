using Microsoft.AspNetCore.Mvc;

namespace HomeworkPustok.Areas.Manage.Controllers
{
    public class HomeController : Controller
    {
        [Area("Manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
