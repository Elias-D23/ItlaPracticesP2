using Microsoft.AspNetCore.Mvc;

namespace Crud.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
