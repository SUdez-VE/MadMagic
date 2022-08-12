using Microsoft.AspNetCore.Mvc;

namespace MvcMadMagic.Controllers
{
    public class MadMagicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
