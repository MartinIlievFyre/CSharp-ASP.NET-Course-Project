using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Controllers
{
    public class SupplementController : Controller
    {
        private readonly GymAppDbContext dbContext;
        public SupplementController(GymAppDbContext dbContext)
        {
                this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task< IActionResult> Supplements()
        {
            var models = await dbContext
                .Supplements
                .Select(a => new SupplementViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Manufacturer = a.Manufacturer,
                    Description = a.Description,
                    Benefits = a.Benefits,
                    Ingredients = a.Ingredients,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl
                })
                .ToListAsync();
            return View(models);
        }
    }
}
