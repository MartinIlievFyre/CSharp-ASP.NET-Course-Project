using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Controllers
{
    [Authorize]
    public class SupplementController : Controller
    {
        private readonly GymAppDbContext dbContext;
        public SupplementController(GymAppDbContext dbContext)
        {
                this.dbContext = dbContext;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task< IActionResult> Supplements()
        {
            var models = await dbContext
                .Supplements
                .Select(s => new SupplementViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Manufacturer = s.Manufacturer,
                    Price = s.Price,
                    ImageUrl = s.ImageUrl
                })
                .ToListAsync();
            return View(models);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> SupplementDetails(string id)
        {
            var currentProduct = await dbContext
         .Supplements
         .Where(s => s.Id == int.Parse(id))
         .Select(s => new SupplementViewModel()
         {
             Id = s.Id,
             Name = s.Name,
             Manufacturer = s.Manufacturer,
             Price = s.Price,
             Description = s.Description,
             Benefits = s.Benefits,
             Ingredients = s.Ingredients,
             ImageUrl = s.ImageUrl
         })
         .FirstOrDefaultAsync();

            if (currentProduct == null)
            {
                return NotFound();
            }

            // Get three random accessory IDs (excluding the current product ID)
            var randomSupplementsIds = await dbContext.Supplements
                .Where(s => s.Id != int.Parse(id))
                .Select(a => a.Id)
                .OrderBy(x => Guid.NewGuid())
                .Take(3)
                .ToListAsync();

            // Get the details of three random products
            var randomProducts = await dbContext.Supplements
                .Where(s => randomSupplementsIds.Contains(s.Id))
                .Select(s => new SupplementViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Manufacturer = s.Manufacturer,
                    Price = s.Price,
                    ImageUrl = s.ImageUrl
                })
                .ToListAsync();

            var viewModel = new SupplementDetailsViewModel()
            {
                CurrentSupplement = currentProduct,
                RandomSupplements = randomProducts
            };

            return View(viewModel);
        }
    }
}
