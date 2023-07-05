using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    public class NotesController : Controller
    {
        public IActionResult Notes()
        {
            return View();
        }
    }
}
