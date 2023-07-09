using GymApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    [Authorize]
    public class CalculatorController : Controller
    {
        private readonly GymAppDbContext dbContext;

        public CalculatorController(GymAppDbContext dbContext)
        {
                this.dbContext = dbContext;
        }

        public IActionResult Calculator()
        {
            
            return View();
        }
    }
}
