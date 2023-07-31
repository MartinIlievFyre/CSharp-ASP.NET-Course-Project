namespace GymApp.Controllers
{
    using GymApp.Data;
    using GymApp.Data.Models;
    using GymApp.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using static GymApp.Common.GeneralApplicationConstants;
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
                    ImageUrl = c.ImageUrl,
                })
                .ToListAsync();
            return View(clothes);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ClothingDetails(string id)
        {
            var currentProduct = await dbContext
         .Clothes
         .Where(c => c.Id == int.Parse(id))
         .Select(c => new WearViewModel()
         {
             Id = c.Id,
             Name = c.Name,
             Price = c.Price,
             Description = c.Description,
             Color = c.Color,
             Size = c.Size,
             Fabric = c.Fabric,
             WearCategory = c.WearCategory.Name,
             ImageUrl = c.ImageUrl,
         })
         .FirstOrDefaultAsync();

            if (currentProduct == null)
            {
                return NotFound();
            }

            var randomClothesIds = await dbContext.Clothes
                .Where(c => c.Id != int.Parse(id))
                .Select(c => c.Id)
                .OrderBy(x => Guid.NewGuid())
                .Take(3)
                .ToListAsync();

            var randomProducts = await dbContext.Clothes
                .Where(c => randomClothesIds.Contains(c.Id))
                .Select(c => new WearViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();

            var viewModel = new ClothingDetailsViewModel()
            {
                CurrentClothing = currentProduct,
                RandomClothes = randomProducts
            };

            return View(viewModel);
        }
       //[HttpPost]
       //public async Task<IActionResult> AddToCart(int id, string wearCategory)
       //{
       //    try
       //    {
       //        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
       //        Guid userGuidId;
       //        Guid.TryParse(userId, out userGuidId);
       //
       //        var clothing = await dbContext.Clothes.FirstOrDefaultAsync(c => c.Id == id);
       //
       //        if (!await dbContext.WearCartItems.AnyAsync(aci => aci.WearId == id))
       //        {
       //            if (!clothing.UsersClothes.Any(ue => ue.TrainingGuyId.ToString() == userId))
       //            {
       //                clothing.UsersClothes.Add(new ApplicationUserWear()
       //                {
       //                    WearId = id,
       //                    TrainingGuyId = userGuidId
       //                });
       //            }
       //            await dbContext.SaveChangesAsync();
       //            Task.Delay(3000).Wait();
       //        }
       //        Task.Delay(3000).Wait();
       //    }
       //    catch
       //    {
       //        BadRequest();
       //    };
       //    if (wearCategory == WearTShirtsCategory)
       //    {
       //        return RedirectToAction("GetClothing", "Clothing", new { id = WearTShirtsCategoryId });
       //    }
       //    else if (wearCategory == WearTShirtsCategory)
       //    { 
       //        return RedirectToAction("GetClothing", "Clothing", new {id = WearHoodiesCategoryId });
       //    }
       //    return RedirectToAction("Clothes", "Clothing");
       //}
    }
}
