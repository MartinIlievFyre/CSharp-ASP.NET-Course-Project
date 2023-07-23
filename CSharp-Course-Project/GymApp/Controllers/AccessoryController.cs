using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Controllers
{
    [Authorize]
    public class AccessoryController : Controller
    {
        private readonly GymAppDbContext dbContext;
        public AccessoryController(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Accessories()
        {
            var models = await dbContext
                .Accessories
                .Select(a => new AccessoryViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Manufacturer = a.Manufacturer,
                    Description = a.Description,
                    Benefits = a.Benefits,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl
                })
                .ToListAsync();
            return View(models);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AccessoryDetails(string id)
        {
            var currentProduct = await dbContext
         .Accessories
         .Where(a => a.Id == int.Parse(id))
         .Select(a => new AccessoryViewModel()
         {
             Id = a.Id,
             Name = a.Name,
             Manufacturer = a.Manufacturer,
             Price = a.Price,
             Description = a.Description,
             Benefits = a.Benefits,
             ImageUrl = a.ImageUrl,
         })
         .FirstOrDefaultAsync();

            if (currentProduct == null)
            {
                return NotFound();
            }

            // Get three random accessory IDs (excluding the current product ID)
            var randomAccessoryIds = await dbContext.Accessories
                .Where(a => a.Id != int.Parse(id))
                .Select(a => a.Id)
                .OrderBy(x => Guid.NewGuid())
                .Take(3)
                .ToListAsync();

            // Get the details of three random products
            var randomProducts = await dbContext.Accessories
                .Where(a => randomAccessoryIds.Contains(a.Id))
                .Select(a => new AccessoryViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Manufacturer = a.Manufacturer,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl
                })
                .ToListAsync();

            var viewModel = new AccessoryDetailsViewModel()
            {
                CurrentAccessory = currentProduct,
                RandomAccessories = randomProducts
            };

            return View(viewModel);
        }
    }
}
