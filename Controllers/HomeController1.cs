using Microsoft.AspNetCore.Mvc;

namespace MainProgram.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
