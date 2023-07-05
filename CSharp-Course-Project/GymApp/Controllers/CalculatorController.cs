using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Calculator()
        {
            return View();
        }
    }
}
