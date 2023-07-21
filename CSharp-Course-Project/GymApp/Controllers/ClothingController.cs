using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Controllers
{
    public class ClothingController : Controller
    {
        private GymAppDbContext dbContext;

        public ClothingController(GymAppDbContext dbContext)
        {
                this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Clothes()
        {
            var models = new CategoryListViewModel();
            var categories = await dbContext.WearCategories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
            models = new CategoryListViewModel()
            {
                Categories = categories
            };
            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> GetClothing(string id)
        {
            var clothes = await dbContext
                .Clothes
                .Where(c => c.WearCategoryId == int.Parse(id))
                .Select(c => new WearViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Description = c.Description,
                    Color = c.Color,
                    ImageUrl = c.ImageUrl,
                    Size = c.Size,
                    Fabric = c.Fabric,
                    WearCategory = c.WearCategory.Name
                })
                .ToListAsync();
            return View(clothes);
        }
    }
}
