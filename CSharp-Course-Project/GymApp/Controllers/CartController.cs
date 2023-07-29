using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Xml.Linq;

namespace GymApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly GymAppDbContext dbContext;
        public CartController(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       [HttpGet]
       public async Task<IActionResult> MyCartItems()
       {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var accessories = await dbContext
               .Accessories
               .Where(a => a.UsersAccessories.Any(ua => ua.TrainingGuyId.ToString() == userId))
               .Select(a => new AccessoryViewModel()
               {
                   Id = a.Id,
                   Name = a.Name,
                   ImageUrl = a.ImageUrl,
                   Manufacturer = a.Manufacturer,
                   Price = a.Price
               })
               .ToListAsync();
            var supplements = await dbContext
               .Supplements
               .Where(s => s.UsersSupplements.Any(us => us.TrainingGuyId.ToString() == userId))
               .Select(s => new SupplementViewModel()
               {
                   Id = s.Id,
                   Name = s.Name,
                   ImageUrl = s.ImageUrl,
                   Manufacturer = s.Manufacturer,
                   Price = s.Price
               })
               .ToListAsync();

            var clothes = await dbContext
               .Clothes
               .Where(c => c.UsersClothes.Any(uc => uc.TrainingGuyId.ToString() == userId))
               .Select(c => new WearViewModel()
               {
                   Id = c.Id,
                   Name = c.Name,
                   ImageUrl = c.ImageUrl,
                   Price = c.Price
               })
               .ToListAsync();

            var models = new ListOfCartItemsViewModel();
            models = new ListOfCartItemsViewModel()
            {
                Accessories = accessories,
                Supplements = supplements,
                Clothes = clothes
            };
            return View(models);
           // var accessories = await dbContext
           //     .Accessories
           //     .Select(a => new AccessoryViewModel()
           //     {
           //         Id = a.Id,
           //         Name = a.Name,
           //         ImageUrl = a.ImageUrl,
           //         Manufacturer = a.Manufacturer,
           //         Description = a.Description,
           //         Benefits = a.Benefits,
           //         Price = a.Price
           //     })
           //     .ToListAsync();
           // var products = new List<AccessoryViewModel>();
           // return View(exercises);
        }
    }
}
