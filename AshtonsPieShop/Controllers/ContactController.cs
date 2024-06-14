using Microsoft.AspNetCore.Mvc;

namespace AshtonsPieShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
