namespace GymApp.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using GymApp.Data;
    using GymApp.Models;
    using System.Security.Claims;
    using GymApp.Data.Models;

    [Authorize]
    public class CalculatorController : Controller
    {
        private readonly GymAppDbContext dbContext;

        public CalculatorController(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> CalMacro()
        {
            var foods = await this.dbContext
                .Foods
                .Select(f => new FoodViewModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Calories = f.Calories,
                    Carbs = f.Carbs,
                    Fat = f.Fat,
                    Protein = f.Protein
                })
                .ToListAsync();
            return View(foods);
        }
        public async Task<IActionResult> AllProducts()
        {
            var foods = await this.dbContext
                .Foods
                .Select(f => new FoodViewModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Calories = f.Calories,
                    Carbs = f.Carbs,
                    Fat = f.Fat,
                    Protein = f.Protein
                })
                .ToListAsync();
            return View(foods);
        }
        [HttpPost]
        public async Task<IActionResult> AddProductToList(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userGuidId;
            Guid.TryParse(userId, out userGuidId);

            var food = await dbContext.Foods.FirstOrDefaultAsync(e => e.Id == id);
            try
            {
                if (!food.UsersFood.Any(ue => ue.TrainingGuyId.ToString() == userId))
                {
                    food.UsersFood.Add(new ApplicationUserFood()
                    {
                        FoodId = id,
                        TrainingGuyId = userGuidId
                    });
                }

                await dbContext.SaveChangesAsync();
            }
            catch
            {
                BadRequest();
            }
            return RedirectToAction($"AllProducts", "Calculator");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromFoodList(int id, ICollection<FoodViewModel> foods)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await dbContext.
                IdentityUsersFoods.
                FirstAsync(u => u.TrainingGuyId.ToString() == userId);

            var food = await dbContext
                .IdentityUsersFoods
                .FirstOrDefaultAsync(uf => uf.FoodId == id && uf.TrainingGuyId.ToString() == userId);

            try
            {
                if (user != null)
                    dbContext.IdentityUsersFoods.Remove(food!);


                await dbContext.SaveChangesAsync();
            }
            catch
            {
                BadRequest();
            }
            return RedirectToAction("CalMacro", "Calculator");
        }
        [HttpGet]
        public async Task<IActionResult> AddFood()
        {
            AddFoodViewModel model = new AddFoodViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddFood(AddFoodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            FoodViewModel food = new FoodViewModel()
            {
                Name = model.Name,
                Calories = model.Calories,
                Carbs = model.Carbs,
                Fat = model.Fat,
                Protein = model.Protein
            };
            await dbContext.AddAsync(food);
            await dbContext.SaveChangesAsync();
            //To do                  Foods
            return RedirectToAction("CalMacro", "Calculator");
        }
    }
}
